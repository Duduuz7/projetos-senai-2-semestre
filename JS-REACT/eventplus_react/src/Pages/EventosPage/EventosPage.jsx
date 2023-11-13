import React from 'react';
import './EventosPage.css'
import Title from '../../Components/Title/Title';
import MainContent from '../../Components/MainContent/MainContent';
import ImageIllustrator from '../../Components/ImageIllustrator/ImageIllustrator';

import eventImage from '../../assets/images/images/evento.svg'
import Container from '../../Components/Container/Container';

//form
import { Input } from '../../Components/FormComponents/FormComponents'

const EventosPage = () => {
    return (
        <section className='cadastro-evento-section'>

            <MainContent>

                <Container>

                    <div className='cadastro-evento__box'>

                        <Title titleText={"Cadastro Eventos"} />

                        <ImageIllustrator
                            alterText={"??"}
                            imageRender={eventImage}
                        />

                        <form onSubmit={""}>

                            <p>Componente de Formulário</p>

                            <Input
                                type={"text"}
                                required={"required"}
                                placeholder={"Nome"}
                            />

                            {/* select */}

                        </form>


                    </div>

                </Container>

            </MainContent>

        </section>
    );
};

export default EventosPage;