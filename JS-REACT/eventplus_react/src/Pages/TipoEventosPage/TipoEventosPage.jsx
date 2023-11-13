import React from 'react';
import './TipoEventosPage.css'
import Title from '../../Components/Title/Title';
import MainContent from '../../Components/MainContent/MainContent';
import Container from '../../Components/Container/Container';
import ImageIllustrator from '../../Components/ImageIllustrator/ImageIllustrator';
import eventTypeImage from '../../assets/images/images/tipo-evento.svg'

//form

import { Input } from '../../Components/FormComponents/FormComponents'

const TipoEventosPage = () => {

    return (

        <MainContent>

            <section className='cadastro-evento-section'>

                <Container>

                    <div className='cadastro-evento__box'>

                        <Title titleText={"Cadastro Tipo de Eventos"} />

                        <ImageIllustrator
                            alterText={"??"}
                            imageRender={eventTypeImage}
                        />

                        <form onSubmit={""}>

                            <p>Componente de Formulário</p>

                            <Input
                                type={"text"}
                                required={"required"}
                                placeholder={"Título"}          
                            />

                        </form>

                    </div>

                </Container>

            </section>

        </MainContent>

    );
};

export default TipoEventosPage;