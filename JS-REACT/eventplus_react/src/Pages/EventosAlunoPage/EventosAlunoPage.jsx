import React, { useContext, useEffect, useState } from "react";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import Table from "./TableEvA/TableEvA";
import Container from "../../Components/Container/Container";
import { Select, SelectMyEvents } from "../../Components/FormComponents/FormComponents";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal";
// import Toggle from "../../components/Toggle/Toggle";
import api from "../../Services/Services";

import "./EventosAlunoPage.css"
import { UserContext } from "../../context/AuthContext";

const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // const [presenca, setPresenca] = useState(false);
  

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);


  useEffect(() => {

    async function loadEventsType() {

      setShowSpinner(true)

      if (tipoEvento === "1") { //todos os eventos
        try {

          const promiseAllEvents = (await api.get('/Evento'));

          setEventos(promiseAllEvents.data)

        } catch (error) {

          alert("Erro ao carregar os eventos ")

        }
      }
      else { //meus eventos
        try {

          let arrayEventos = [];

          const promiseMyEvents = (await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`));

          promiseMyEvents.data.forEach((e) => {
            arrayEventos.push(e.evento)
          })

          setEventos(arrayEventos)

          console.log(promiseMyEvents);

        } catch (error) {

          alert("Erro em carregar os eventos do aluno")

          console.log(error);

        }
      }
      setShowSpinner(false)
    }

    console.log(tipoEvento);

    loadEventsType();


  }, [tipoEvento]);

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  async function loadMyComentary(idComentary) {
    return "????";
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  function handleConnect() {
    alert("Desenvolver a função conectar evento");
  }
  return (
    <>
      <MainContent>
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <SelectMyEvents
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            options={quaisEventos} // aqui o array dos tipos
            manipulatorFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
