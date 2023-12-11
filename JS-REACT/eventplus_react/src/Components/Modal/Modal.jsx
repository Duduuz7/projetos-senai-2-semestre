import React, { useEffect, useState } from "react";
import trashDelete from "../../assets/images/images/trash-delete-red.png";

import { Button, Input } from "../FormComponents/FormComponents";
import "./Modal.css";

const Modal = ({
  modalTitle = "Feedback",
  comentaryText = 'Não Informado !',
  userId = null,
  showHideModal = false,
  fnGet = null,
  fnPost = null,
  fnDelete = null,
  idEvento = null,
  idComentario = null,
}) => {

  const [comentarioDesc, setComentarioDesc] = useState("");

  useEffect( () => {
     fnGet(userId, idEvento)
   }, [])

  return (
    <div className="modal">
      <article className="modal__box">
        
        <h3 className="modal__title">
          {modalTitle}
          <span className="modal__close" onClick={()=> showHideModal(true)}>x</span>
        </h3>

        <div className="comentary">
          <h4 className="comentary__title">Comentário</h4>
          <img
            src={trashDelete}
            className="comentary__icon-delete"
            alt="Ícone de uma lixeira"
            onClick={async () => {
              await fnDelete(idComentario);
              await fnGet();
            }}
          />

          <p className="comentary__text">{comentaryText}</p>

          <hr className="comentary__separator" />
        </div>

        <Input
          placeholder="Escreva seu comentário..."
          additionalClass="comentary__entry"
          manipulationFunction={(e) => {
            setComentarioDesc(e.target.value);
          }}
        />

        <Button
          textButton="Comentar"
          additionalClass="comentary__button"
          manipulationFunction={async () => {
            if (idComentario !== null) {
                alert("Já existe um comentàrio cadastrado para o evento.");
              } else {
                
                await fnPost(comentarioDesc.trim(), userId, idEvento);
                await fnGet();
              }
              setComentarioDesc("");//;limpa o campo do input
          }}
        />
      </article>
    </div>
  );
};

export default Modal;
