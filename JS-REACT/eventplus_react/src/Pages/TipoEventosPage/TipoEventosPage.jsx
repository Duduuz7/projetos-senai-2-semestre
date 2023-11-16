import React, { useState } from 'react';
import './TipoEventosPage.css'
import Title from '../../Components/Title/Title';
import MainContent from '../../Components/MainContent/MainContent';
import Container from '../../Components/Container/Container';
import ImageIllustrator from '../../Components/ImageIllustrator/ImageIllustrator';
import eventTypeImage from '../../assets/images/images/tipo-evento.svg'
import api from '../../Services/Services';

//form

import { Input, Button } from '../../Components/FormComponents/FormComponents'

//table

import TableTp from './TableTp/TableTp';


const TipoEventosPage = () => {

    const [frmEdit, setFrmEdit] = useState(false);
    const [titulo, setTitulo] = useState("");

    const [tipoEventos, setTipoEventos] = useState([
        { idTipoEvento: "123", titulo: "Evento ABC" },
        { idTipoEvento: "555", titulo: "Evento xpto" },
        { idTipoEvento: "444", titulo: "Evento de JavaScript" }
    ]); //Array mocado

    //no state ja colocar tipo do dado no () do use, nesse caso array, acima string

    async function handleSubmit(e) {
        //parar o submit do formulário
        e.preventDefault();
        //validar pelo menos 3 caracteres
        if (titulo.trim().length < 3) {
            alert('O Titulo deve ter no minimo 3 caracteres')
            return;
        }
        //chamar API
        try {
            const retorno = await api.post('/TiposEvento', { titulo: titulo }) //transforma em json para passar para api/banco
            console.log("Cadastrado com sucesso !");
            console.log(retorno.data);
            setTitulo("");//limpa a variável após enter/cadastro
        } catch (error) {
            console.log("Deu ruim na API");
            console.log(error);
        }
    }

    //******************EDITAR CADASTRO******************

    function showUpdateForm() {
        alert('Mostrando a tela de update')
    }

    function handleUpdate() {
        alert('Bora atualizar')
    }

    function editActionAbort() {
        alert('Cancelar a tela de edição de dadps')
    }

    // ****************** DELETAR CADASTRO ***************

    function handleDelete() {
        alert('Bora lá apagar na api')
    }

    return (
        <MainContent>

            {/* CADASTRO DE TIPO DE EVENTOS */}

            <section className='cadastro-evento-section'>
                <Container>
                    <div className='cadastro-evento__box'>
                        <Title titleText={"Página Tipos de Eventos"} />
                        <ImageIllustrator
                            alterText={""}
                            imageRender={eventTypeImage}
                        />
                        <form className='ftipo-evento' onSubmit={frmEdit ? handleUpdate : handleSubmit}>
                            {!frmEdit ?
                                (<>

                                    <Input
                                        id={"titulo"}
                                        name={"titulo"}
                                        type={"text"}
                                        placeholder={"Titulo"}
                                        required={"required"}
                                        value={titulo}
                                        manipulationFunction={
                                            (e) => {
                                                setTitulo(e.target.value)
                                            }
                                        }
                                    />
                                    <Button
                                        textButton={"Cadastrar"}
                                        id={"cadastrar"}
                                        name={"cadastrar"}
                                        type={"submit"}
                                    />

                                </>)
                                :
                                (
                                    <>
                                        Tela de Login
                                    </>
                                )
                            }
                        </form>
                    </div>
                </Container>
            </section>

            {/* LISTAGEM DE TIPO DE EVENTOS */}

            <section className="lista-eventos-section">
                <Container>

                    <Title titleText={"Lista Tipo de Eventos"} color="white" />

                    <TableTp
                        dados={tipoEventos}
                        fnUpdate={showUpdateForm}
                        fnDelete={handleDelete}
                    />

                </Container>
            </section>

        </MainContent>
    );
};

export default TipoEventosPage;