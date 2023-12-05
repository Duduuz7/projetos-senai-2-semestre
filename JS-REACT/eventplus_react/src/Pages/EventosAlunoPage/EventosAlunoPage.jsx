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
import Notification from '../../Components/Notification/Notification';

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
  const [notifyUser, setNotifyUser] = useState({});

  // const [presenca, setPresenca] = useState(false);


  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);


  useEffect(() => {

    async function loadEventsType() {

      setShowSpinner(true)

      if (tipoEvento === "1") { //todos os eventos

        try {

          const promiseAllEvents = (await api.get('/Evento'));

          const promiseMyEvents = (await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`));

          const dadosMarcados = verificaPresenca(promiseAllEvents.data, promiseMyEvents.data);

          console.clear();

          console.log("DADOS MARCADOS: ");

          console.log(dadosMarcados);

          setEventos(promiseAllEvents.data)

        } catch (error) {

          // alert("Erro ao carregar os eventos ")
          console.log(error)

        }

      }

      else if (tipoEvento === "2") { //meus eventos

        try {

          let arrayEventos = [];

          const promiseMyEvents = (await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`));

          promiseMyEvents.data.forEach((e) => {
            arrayEventos.push({...e.evento, situacao : e.situacao})
          })

          setEventos(arrayEventos)

          console.log(promiseMyEvents);

        } catch (error) {

          alert("Erro em carregar os eventos do aluno")

          console.log(error);

        }

      }

      else {

        setEventos([])

      }

      setShowSpinner(false)

    }

    console.log(tipoEvento);

    loadEventsType();

  }, [tipoEvento, userData.userId]); //colocando o userid nas dependencias do useeffect para quando dar reload na página nao dar ruim


  //PARA CADA EVENTO DE TODOS, VOU VERIFICAR A CORRESPONDÊNCIA DELE NO MEUS EVENTOS
  const verificaPresenca = (arrAllEvents, eventsUSer) => {
    for (let x = 0; x < arrAllEvents.length; x++) { //PARA CADA EVENTO (TODOS)

      for (let y = 0; y < eventsUSer.length; y++) { // VERIFICA NO MEUS EVENTOS
        if (arrAllEvents[x].idEvento === eventsUSer[y].idEvento) {
          arrAllEvents[x].situacao = true;
          break;
        }
      }
    }
    return arrAllEvents;
  }



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

      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />

      <MainContent>
        <Container>
          <Title titleText={"Eventos"} additionalCLass="custom-title" />

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
