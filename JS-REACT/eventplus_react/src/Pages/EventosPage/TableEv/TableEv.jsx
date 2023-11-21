import React from 'react';
import './TableEv.css'
import editPen from '../../../assets/images/images/edit-pen.svg'
import trashDelete from '../../../assets/images/images/trash-delete.svg'

const TableEv = ({ dados, fnUpdate = null, fnDelete = null }) => {



    return (
        <table className='table-data'>
            <thead className="table-data__head">
                <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--big">Título</th>
                    <th className="table-data__head-title table-data__head-title--little">Editar</th>
                    <th className="table-data__head-title table-data__head-title--little">Deletar</th>
                </tr>
            </thead>



            <tbody>
                {dados.map((e) => {
                    return (<tr className="table-data__head-row">
                        <td className="table-data__data table-data__data--big">
                            {e.titulo}
                        </td>

                        <td className="table-data__data table-data__data--little">
                            <img
                                className="table-data__icon"
                                src={editPen} alt=""
                                onClick={() => {
                                    fnUpdate(e.idTipoEvento)
                                }} />
                        </td>

                        <td className="table-data__data table-data__data--little">
                            <img
                                className="table-data__icon"
                                src={trashDelete} alt=""
                                onClick={() => {
                                    fnDelete(e.idTipoEvento)
                                }} />
                        </td>
                    </tr>
                    );
                })}
            </tbody>
        </table>
    );
};

export default TableEv;