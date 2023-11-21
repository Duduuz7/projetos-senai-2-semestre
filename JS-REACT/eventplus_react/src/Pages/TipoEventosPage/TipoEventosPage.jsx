import React, { useState, useEffect } from 'react';
import './TipoEventosPage.css'
import Title from '../../Components/Title/Title';
import MainContent from '../../Components/MainContent/MainContent';
import Container from '../../Components/Container/Container';
import ImageIllustrator from '../../Components/ImageIllustrator/ImageIllustrator';
import eventTypeImage from '../../assets/images/images/tipo-evento.svg'
import api from '../../Services/Services';
import Notification from '../../Components/Notification/Notification';
import Spinner from '../../Components/Spinner/Spinner'

//form

import { Input, Button } from '../../Components/FormComponents/FormComponents'

//table

import TableTp from './TableTp/TableTp';



const TipoEventosPage = () => {

    const [notifyUser, setNotifyUser] = useState({})
    const [showSpinner, setShowSpinner] = useState(false)

    const [frmEdit, setFrmEdit] = useState(false);
    const [titulo, setTitulo] = useState("");
    const [idEvento, setIdEvento] = useState(null); //usar apenas para edição
    const [tipoEventos, setTipoEventos] = useState([]);

    //ao carregar a pagina
    useEffect(() => {

        //chamar a api
        async function getTipoEventos() {

            setShowSpinner(true)

            try {

                const promise = await api.get("/TiposEvento")

                console.log(promise.data);

                setTipoEventos(promise.data)

            } catch (error) {
                setNotifyUser({
                    titleNote: "Erro",
                    textNote: `Deu ruim na API`,
                    imgIcon: "danger",
                    imgAlt:
                        "Imagem de ilustração de erro.",
                    showMessage: true,
                });
                console.log(error);
            }

            setShowSpinner(false)
        }

        console.log("Deu Bom !!!");

        getTipoEventos()
    }, []);

    //  CADASTRAR
    async function handleSubmit(e) {
        //parar o submit do formulário
        e.preventDefault();
        //validar pelo menos 3 caracteres
        if (titulo.trim().length < 3) {
            setNotifyUser({
                titleNote: "Aviso",
                textNote: `O título deve ter no mínimo 3 caracteres`,
                imgIcon: "warning",
                imgAlt:
                    "Imagem de ilustração de aviso.",
                showMessage: true,
            });
            return;
        }
        //chamar API
        try {
            const retorno = await api.post('/TiposEvento', { titulo: titulo }); //transforma em json para passar para api/banco

            //notification
            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Cadastrado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });

            console.log(retorno.data);
            setTitulo("");//limpa a variável após enter/cadastro
            const retornoGet = await api.get('/TiposEvento');
            setTipoEventos(retornoGet.data)
        } catch (error) {

            setNotifyUser({
                titleNote: "Erro",
                textNote: `Erro ao cadastrar`,
                imgIcon: "danger",
                imgAlt:
                    "Imagem de ilustração de erro.",
                showMessage: true,
            });
            console.log(error);
        }
    }

    //******************EDITAR CADASTRO******************

    async function showUpdateForm(id) {
        setFrmEdit(true);

        //fazer um get pelo id
        try {
            const retornoGetById = await api.get(`/TiposEvento/${id}`);

            setTitulo(retornoGetById.data.titulo)

            setIdEvento(retornoGetById.data.idTipoEvento)
        } catch (error) {

            setNotifyUser({
                titleNote: "Erro",
                textNote: `Erro ao mostrar a tela de edição`,
                imgIcon: "danger",
                imgAlt:
                    "Imagem de ilustração de erro.",
                showMessage: true,
            });
            console.log(error);
        }
    }

    async function handleUpdate(e) {

        e.preventDefault();

        try {
            //salvar os dados
            const retorno = await api.put('/TiposEvento/' + idEvento, {
                titulo: titulo
            })

            //atualizar o state (api get)
            const retornoGet = await api.get('/TiposEvento');

            setTipoEventos(retornoGet.data) //atualiza o state da tabela

            //notification
            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Atualizado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });

            //limpar o state do titulo e do idEvento
            editActionAbort()

        } catch (error) {
            console.log(error);

            setNotifyUser({
                titleNote: "Erro",
                textNote: `Erro ao atualizar`,
                imgIcon: "danger",
                imgAlt:
                    "Imagem de ilustração de erro.",
                showMessage: true,
            });
        }
    }

    function editActionAbort() {
        setFrmEdit(false);
        setTitulo("");
        setIdEvento(null);
    }

    // ****************** DELETAR CADASTRO ***************

    async function handleDelete(id) {
        try {
            const retorno = await api.delete(`/TiposEvento/${id}`)

            const retornoGet = await api.get('/TiposEvento');

            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Registro apagado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de erro. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });

            setTipoEventos(retornoGet.data)
        } catch (error) {
            setNotifyUser({
                titleNote: "Erro",
                textNote: `Erro ao deletar`,
                imgIcon: "danger",
                imgAlt:
                    "Imagem de ilustração de erro.",
                showMessage: true,
            });
            console.log(error);
        }
    }

    return (
        <MainContent>

            {<Notification {...notifyUser} setNotifyUser={setNotifyUser} />}

            { showSpinner ? <Spinner /> : null }

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
                                        placeholder={"Título"}
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

                                        <Input
                                            id={"titulo"}
                                            name={"titulo"}
                                            type={"text"}
                                            placeholder={"Título"}
                                            required={"required"}
                                            value={titulo}
                                            manipulationFunction={
                                                (e) => {
                                                    setTitulo(e.target.value)
                                                }
                                            }
                                        />

                                        <div className='buttons-editbox'>
                                            <Button
                                                textButton={"Atualizar"}
                                                id={"atualizar"}
                                                name={"atualizar"}
                                                type={"submit"}
                                            // additionalClass="button-component--middle"
                                            />

                                            <Button
                                                textButton={"Cancelar"}
                                                id="cancelar"
                                                name="cancelar"
                                                manipulationFunction={editActionAbort}
                                            // additionalClass="button-component--middle"
                                            />
                                        </div>

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

        </MainContent >
    );
};

export default TipoEventosPage;