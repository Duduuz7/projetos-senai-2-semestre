import React from "react";
import comentaryIcon from "../../../assets/images/images/comentary-icon.svg";
import trashDelete from "../../../assets/images/images/trash-delete.svg";
import { dateFormatDbToView, dateFormatDbToView1, dateFormatDbToView2 } from "../../../Utils/stringFunctions";
// importa a biblioteca de tootips ()
import "react-tooltip/dist/react-tooltip.css";
import { Tooltip } from "react-tooltip";



// import trashDelete from "../../../assets/images/trash-delete.svg";
import "./TableEvA.css";
import ToggleSwitch from "../../../Components/Toggle/Toggle";

const Table = ({ dados, fnConnect = null, fnShowModal = null }) => {
  return (
    <table className="tbal-data">
      <thead className="tbal-data__head">
        <tr className="tbal-data__head-row tbal-data__head-row--red-color">
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Evento
          </th>
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Data
          </th>
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Ações
          </th>
        </tr>
      </thead>
      <tbody>
        {dados.map((e) => {
          return (
            <tr className="tbal-data__head-row" key={Math.random()}>
              <td className="tbal-data__data tbal-data__data--big">
                {e.nomeEvento}
              </td>

              <td className="tbal-data__data tbal-data__data--big tbal-data__btn-actions">
                {/* {e.dataEvento} */}
                {dateFormatDbToView(e.dataEvento)}
              </td>

              <td className="tbal-data__data tbal-data__data--big tbal-data__btn-actions">
                <img
                  className="tbal-data__icon"
                  idevento={e.idEvento}
                  src={comentaryIcon}
                  alt=""
                  onClick={() => fnShowModal(e.idEvento)}
                />

                <ToggleSwitch 
                toggleActive={e.situacao} 
                manipulationFunction={() => {
                  fnConnect(
                    e.idEvento,
                    e.situacao ? "unconnect" : "connect", // primeira opcao se for true, ai realiza um unconnect, se for false realiza connect
                    e.idPresencaEvento
                    )
                }}/>

              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default Table;
