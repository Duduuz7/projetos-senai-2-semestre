import React, { useContext, useEffect, useState } from "react";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import Table from "./TableEvA/TableEvA";
import Container from "../../Components/Container/Container";
import { Select, SelectMyEvents } from "../../Components/FormComponents/FormComponents";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal";
// import Toggle from "../../components/Toggle/Toggle";
import Notification from '../../Components/Notification/Notification';

import api, {
  eventsResource,
  myEventsResource,
  presencesEventResource,
  commentaryEventResource,
} from "../../Services/Services";

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
  const [idComentario, setIdComentario] = useState(null);

  const [comentario, setComentario] = useState("");

  const [idEvento, setIdEvento] = useState([])
  // const [presenca, setPresenca] = useState(false);


  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);

  // FUNCAO DOMUSE EFFECT, GET

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
          arrayEventos.push({
            ...e.evento,
            situacao: e.situacao,
            idPresencaEvento: e.idPresencaEvento
          })
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

  // USE EFFECT

  useEffect(() => {

    loadEventsType();

  }, [tipoEvento, userData.userId]); //colocando o userId nas dependencias do useeffect para quando dar reload na página nao dar ruim


  //PARA CADA EVENTO DE TODOS, VOU VERIFICAR A CORRESPONDÊNCIA DELE NO MEUS EVENTOS
  const verificaPresenca = (arrAllEvents, eventsUSer) => {
    for (let x = 0; x < arrAllEvents.length; x++) { //PARA CADA EVENTO (TODOS)

      for (let y = 0; y < eventsUSer.length; y++) { // VERIFICA NO MEUS EVENTOS
        if (arrAllEvents[x].idEvento === eventsUSer[y].idEvento) {
          arrAllEvents[x].situacao = true;
          arrAllEvents[x].idPresencaEvento = eventsUSer[y].idPresencaEvento; //traz o id da presenca evento tambem, para usar no desconectar do evento(toggle)
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

  const showHideModal = async (idEvent) => {
    setShowModal(showModal ? false : true);

    // const promise = await api.get("/Evento")

    setIdEvento(idEvent)

    console.log(idEvento);
  };

  // ler um comentário - get
  const loadMyCommentary = async (idUsuario, idEvento) => {
    // console.log("fui chamado");

    try {
      // api está retornando sempre todos os comentários do usuário
      const promise = await api.get(
        `${commentaryEventResource}?idUsuario=${idUsuario}&idEvento=${idEvento}`
      );

      const myComm = await promise.data.filter(
        (comm) => comm.idEvento === idEvento && comm.idUsuario === idUsuario
      );

      // console.log("QUANTIDADE DE DADOS NO ARRAY FILTER");
      // console.log(myComm.length);
      // console.log(myComm);

      setComentario(myComm.length > 0 ? myComm[0].descricao : "");
      setIdComentario(myComm.length > 0 ? myComm[0].idComentarioEvento : null);
    } catch (error) {
      console.log("Erro ao carregar o evento");
      console.log(error);
    }
  };

  // cadastrar um comentário = post
  const postMyCommentary = async (descricao, idUsuario, idEvento) => {
    try {
      const promise = await api.post(commentaryEventResource, {
        descricao: descricao,
        exibe: true,
        idUsuario: idUsuario,
        idEvento: idEvento,
      });

      if (promise.status === 200) {
        alert("Comentário cadastrado com sucesso");
      }
    } catch (error) {
      console.log("Erro ao cadastrar o comentário");
      console.log(error);
    }
  };

  // remove o comentário - delete
  const commentaryRemove = async (idComentario) => {
    // alert("Remover o comentário " + idComentario);

    try {
      const promise = await api.delete(
        `${commentaryEventResource}/${idComentario}`
      );
      if (promise.status === 200) {
        alert("Comentário excluído com sucesso!");
      }
    } catch (error) {
      console.log("Erro ao excluir ");
      console.log(error);
    }
  };

  // FUNÇÃO CONNECT, PARA FUNCIONAR TOGGLE CERTINHO.

  async function handleConnect(idEvent, whatTheFunction, idPresencaEvento = null) {

    if (whatTheFunction === "connect") {

      try {

        const promisePost = await api.post("/PresencasEvento", {

          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvent

        });

        if (promisePost.status === 201) {
          // alert("Presença confirmada, parabéns !!")
          loadEventsType()

          setNotifyUser({
            titleNote: "Sucesso",
            textNote: `Presenca confirmada !`,
            imgIcon: "success",
            imgAlt:
              "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
            showMessage: true,
          });
        }

      } catch (error) {
        setNotifyUser({
          titleNote: "Erro",
          textNote: `Erro ao confirmar a presença !!`,
          imgIcon: "danger",
          imgAlt:
            "Imagem de ilustração de erro.",
          showMessage: true,
        });

        console.log(error);
      }
      return;
    }

    try { //desconectar

      const promiseUnconnect = await api.delete(`/PresencasEvento/${idPresencaEvento}`)



      if (promiseUnconnect.status === 204) {
        // alert("Desconectado do evento !!!")
        loadEventsType()

        setNotifyUser({
          titleNote: "Sucesso",
          textNote: `Presenca cancelada com sucesso !`,
          imgIcon: "success",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });
      }

    } catch (error) {

      setNotifyUser({
        titleNote: "Erro",
        textNote: `Erro ao cancelar a presença !!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de erro.",
        showMessage: true,
      });

      console.log(error);
    }

  }

  // RETURN GERAL

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
          fnGet={loadMyCommentary}
          fnPost={postMyCommentary}
          fnDelete={commentaryRemove}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
