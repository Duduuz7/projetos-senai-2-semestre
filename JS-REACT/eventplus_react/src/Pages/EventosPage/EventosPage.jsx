import React, { useState, useEffect } from 'react';
import './EventosPage.css'
import Title from '../../Components/Title/Title';
import MainContent from '../../Components/MainContent/MainContent';
import ImageIllustrator from '../../Components/ImageIllustrator/ImageIllustrator';
import Notification from '../../Components/Notification/Notification';
import api from '../../Services/Services';
import Spinner from '../../Components/Spinner/Spinner'

import { dateFormatDbToView1 } from '../../Utils/stringFunctions'

import eventImage from '../../assets/images/images/evento.svg'
import Container from '../../Components/Container/Container';

//form
import { Input, Button, Select } from '../../Components/FormComponents/FormComponents'

//table
import TableEv from './TableEv/TableEv';

const EventosPage = () => {

    // SPINNER E NOTIFICATION
    const [notifyUser, setNotifyUser] = useState({});
    const [showSpinner, setShowSpinner] = useState(false);

    //Formulário de edição
    const [frmEdit, setFrmEdit] = useState(false);

    // *****************************************************

    const [evento, setEvento] = useState([]);
    const [nome, setNome] = useState([]);
    const [descricao, setDescricao] = useState([]);
    const [tiposEvento, setTiposEvento] = useState([]);
    const [dataEvento, setDataEvento] = useState("");

    const [instituicao, setInstituicao] = useState([]);
    const [selecionado, setSelecionado] = useState("");

    // *****************************************************

    const [idEvento, setIdEvento] = useState(null); //edição

    // *****************************************************

    useEffect(() => {

        //chamar a api
        async function getAll() {

            setShowSpinner(true)

            try {

                const promise = await api.get("/Evento")
                const promiseTiposEvento = await api.get("/TiposEvento")
                const promiseInstituicao = await api.get("/Instituicao")

                console.log(promise.data);

                setEvento(promise.data)
                setInstituicao(promiseInstituicao.data[0].idInstituicao)
                setTiposEvento(promiseTiposEvento.data)

            } catch (error) {
                setNotifyUser({
                    titleNote: "Erro",
                    textNote: `Deu ruim na API.`,
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

        getAll()
    }, []);



    // ********************* CADASTRAR *****************************

    async function handleSubmit(e) {

        e.preventDefault();

        // VALIDAÇÕES
        if (nome.trim().length < 4) {
            setNotifyUser({
                titleNote: "Aviso",
                textNote: `O nome deve ter no mínimo 4 caracteres.`,
                imgIcon: "warning",
                imgAlt:
                    "Imagem de ilustração de aviso.",
                showMessage: true,
            });
            return;
        }

        else if (descricao.trim().length < 5) {
            setNotifyUser({
                titleNote: "Aviso",
                textNote: `A descrição deve ter no mínimo 5 caracteres.`,
                imgIcon: "warning",
                imgAlt:
                    "Imagem de ilustração de aviso.",
                showMessage: true,
            });
            return;
        }

        else if (tiposEvento == null) {
            setNotifyUser({
                titleNote: "Aviso",
                textNote: `O evento deve ter um tipo.`,
                imgIcon: "warning",
                imgAlt:
                    "Imagem de ilustração de aviso.",
                showMessage: true,
            });
            return;
        }

        else if (evento.dataEvento == null) {
            setNotifyUser({
                titleNote: "Aviso",
                textNote: `O evento deve ter uma data.`,
                imgIcon: "warning",
                imgAlt:
                    "Imagem de ilustração de aviso.",
                showMessage: true,
            });
            
            return;
        }

        try {

            const retorno = await api.post('/Evento',
                {
                    nomeEvento: nome,
                    descricao: descricao,
                    dataEvento: dataEvento,
                    idTipoEvento: selecionado,
                    idInstituicao: instituicao
                }
            );

            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Cadastrado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });


            //limpar variáveis/campos
            setNome("")
            setDescricao("")
            // setTiposEvento([])
            setSelecionado("")
            setDataEvento("")

            //retorno

            const retornoGet = await api.get('/Evento');
            setEvento(retornoGet.data)

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

    // ********************* EDITAR **********************************

    async function showUpdateForm(id) {

        setFrmEdit(true)

        try {

            const retornoGetById = await api.get(`/Evento/${id}`);

            //para edição
            setIdEvento(retornoGetById.data.idEvento)

            setNome(retornoGetById.data.nomeEvento)
            setDescricao(retornoGetById.data.descricao)
            setDataEvento(retornoGetById.data.dataEvento)
            setSelecionado(retornoGetById.data.titulo)

        } catch (error) {

            setNotifyUser({
                titleNote: "Erro",
                textNote: `Erro ao mostrar o formulário de edição.`,
                imgIcon: "danger",
                imgAlt:
                    "Imagem de ilustração de erro.",
                showMessage: true,
            });

            console.log(error);

        }
    }

    async function handleUpdate(e) {

        e.preventDefault()

        try {

            const retorno = await api.put('/Evento/' + idEvento, {
                nomeEvento: nome,
                descricao: descricao,
                dataEvento: dataEvento,
                idTipoEvento: selecionado,
                idInstituicao: instituicao
            })

            const retornoGet = await api.get('/Evento');

            setEvento(retornoGet.data)

            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Atualizado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });

            //limpa os campos e volta
            editActionAbort()

        } catch (error) {

            setNotifyUser({
                titleNote: "Erro",
                textNote: `Erro ao atualizar`,
                imgIcon: "danger",
                imgAlt:
                    "Imagem de ilustração de erro.",
                showMessage: true,
            });

            console.log(error);
        }

    }

    function editActionAbort() {
        setFrmEdit(false);
        setNome("")
        setDescricao("")
        setTiposEvento([])
        setDataEvento("")
        setSelecionado("")
    }

    // ******************** DELETAR ***********************************

    async function handleDelete(id) {
        try {

            const retorno = await api.delete(`/Evento/${id}`)

            const retornogGet = await api.get('/Evento')

            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Registro apagado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });

            setEvento(retornogGet.data)

        } catch (error) {

            setNotifyUser({
                titleNote: "Erro",
                textNote: `Erro ao deletar`,
                imgIcon: "danger",
                imgAlt:
                    "Imagem de ilustração de erro.",
                showMessage: true,
            });

            console.log(error)
        }
    }


    // ***************** RETURN COMPONENTES ***************************

    return (
        <MainContent>

            {<Notification {...notifyUser} setNotifyUser={setNotifyUser} />}

            {showSpinner ? <Spinner /> : null}

            <section className='cadastro-evento-section'>

                <Container>

                    <div className='cadastro-evento__box'>

                        <Title titleText={"Cadastro Eventos"} />

                        <ImageIllustrator
                            alterText={"??"}
                            imageRender={eventImage}
                        />

                        <form className='ftipo-evento' onSubmit={frmEdit ? handleUpdate : handleSubmit}>
                            {!frmEdit ?
                                (<>

                                    <Input
                                        id={"nome"}
                                        name={"nome"}
                                        type={"text"}
                                        required={"required"}
                                        placeholder={"Nome"}
                                        value={nome}
                                        manipulationFunction={
                                            (e) => {
                                                setNome(e.target.value)
                                            }
                                        }
                                    />

                                    <Input
                                        id={"descricao"}
                                        name={"descricao"}
                                        type={"text"}
                                        required={"required"}
                                        placeholder={"Descrição"}


                                        value={descricao}
                                        manipulationFunction={
                                            (e) => {
                                                setDescricao(e.target.value)
                                            }
                                        }
                                    />

                                    <Select
                                        dados={tiposEvento}
                                        id={"tiposEvento"}
                                        name={"tiposEvento"}
                                        manipulationFunction={
                                            (e) => {
                                                setSelecionado(e.target.value)
                                            }
                                        }
                                    />

                                    {/* <Select
                                        dados={instituicao}
                                        id={"instituicao"}
                                        name={"instituicao"}
                                        manipulationFunction={
                                            (e) => {
                                                setInstituicao(e.target.value)
                                            }
                                        }
                                    /> */}


                                    <Input
                                        id={"dataEvento"}
                                        name={"dataEvento"}
                                        type={"date"}
                                        required={"required"}
                                        placeholder={"dd//mm//aaaa"}
                                        value={dataEvento}
                                        manipulationFunction={
                                            (e) => {
                                                setDataEvento(e.target.value)
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
                                            id={"nome"}
                                            name={"nome"}
                                            type={"text"}
                                            required={"required"}
                                            placeholder={"Nome"}
                                            value={nome}
                                            manipulationFunction={
                                                (e) => {
                                                    setNome(e.target.value)
                                                }
                                            }
                                        />

                                        <Input
                                            id={"descricao"}
                                            name={"descricao"}
                                            type={"text"}
                                            required={"required"}
                                            placeholder={"Descrição"}
                                            value={descricao}
                                            manipulationFunction={
                                                (e) => {
                                                    setDescricao(e.target.value)
                                                }
                                            }
                                        />

                                        <Select
                                            dados={tiposEvento}
                                            id={"tiposEvento"}
                                            name={"tiposEvento"}
                                            manipulationFunction={
                                                (e) => {
                                                    setSelecionado(e.target.value)
                                                }
                                            }
                                        />

                                        <Input
                                            id={"data"}
                                            name={"data"}
                                            type={"date"}
                                            required={"required"}
                                            placeholder={"dd//mm//aaaa"}
                                            value={dateFormatDbToView1(dataEvento)}
                                            manipulationFunction={
                                                (e) => {
                                                    setDataEvento(e.target.value)
                                                }
                                            }
                                        />

                                        <div className='buttons-editbox'>
                                            <Button
                                                textButton={"Atualizar"}
                                                id={"atualizar"}
                                                name={"atualizar"}
                                                type={"submit"}
                                            />

                                            <Button
                                                textButton={"Cancelar"}
                                                id="cancelar"
                                                name="cancelar"
                                                manipulationFunction={editActionAbort}
                                            />
                                        </div>

                                    </>

                                )


                            }
                        </form>

                    </div>

                </Container>

            </section>

            <section className="lista-eventos-section">

                <Container>

                    <Title titleText={"Lista Eventos"} color="white" />

                    <TableEv
                        dados={evento}
                        fnUpdate={showUpdateForm}
                        fnDelete={handleDelete}
                    />

                </Container>

            </section>

        </MainContent>
    );
};

export default EventosPage;