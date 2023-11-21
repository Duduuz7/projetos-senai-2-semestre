import React, { useState, useEffect } from 'react';
import './EventosPage.css'
import Title from '../../Components/Title/Title';
import MainContent from '../../Components/MainContent/MainContent';
import ImageIllustrator from '../../Components/ImageIllustrator/ImageIllustrator';
import Notification from '../../Components/Notification/Notification';

import eventImage from '../../assets/images/images/evento.svg'
import Container from '../../Components/Container/Container';

//form
import { Input, Button } from '../../Components/FormComponents/FormComponents'



const EventosPage = () => {

    const [notifyUser, setNotifyUser] = useState({})

    return (
        <MainContent>

            {<Notification {...notifyUser} setNotifyUser={setNotifyUser} />}

            <section className='cadastro-evento-section'>
                <Container>

                    <div className='cadastro-evento__box'>

                        <Title titleText={"Cadastro Eventos"} />

                        <ImageIllustrator
                            alterText={"??"}
                            imageRender={eventImage}
                        />

                        <form className='ftipo-evento'>

                            <Input
                                type={"text"}
                                required={"required"}
                                placeholder={"Nome"}
                            />

                            <Input
                                type={"text"}
                                required={"required"}
                                placeholder={"Descrição"}
                            />

                            <select className='select-tp-evento' name="" id="">

                            </select>

                            <Input
                                type={"date"}
                                required={"required"}
                                placeholder={"dd//mm//aaaa"}
                            />

                            <Button
                                textButton={"Cadastrar"}
                                id={"cadastrar"}
                                name={"cadastrar"}
                                type={"submit"}
                            />

                            {/* select */}

                        </form>


                    </div>

                </Container>
            </section>
        </MainContent>
    );
};

export default EventosPage;