import React from 'react';
import './HomePage.css'
import MainContent from '../../Components/MainContent/MainContent';
import Title from '../../Components/Title/Title';
import Banner from '../../Components/Banner/Banner';
import VisionSection from '../../Components/VisionSection/VisionSection';
import NextEvent from '../../Components/NextEvent/NextEvent';
import Container from '../../Components/Container/Container';
import ContactSection from '../../Components/ContactSection/ContactSection';

const HomePage = () => {
    return (
        <MainContent>
            <Banner />

            {/* Próximos Eventos */}
            <section className="proximos-eventos">
                <Container>
                    <Title titleText={"Próximos Eventos"} />

                    <div className="events-box">

                        <NextEvent
                            title={"Happy Hour Event"}
                            description={"Evento Legal :)"}
                            eventDate={"14/11/2023"}
                            idEvent={"sdafjkghsakdjfhkjdfshfkhk"}
                        />

                        <NextEvent
                            title={"Happy Hour Event"}
                            description={"Evento Legal :)"}
                            eventDate={"14/11/2023"}
                            idEvent={"sdafjkghsakdjfhkjdfshfkhk"}
                        />

                        <NextEvent
                            title={"Happy Hour Event"}
                            description={"Evento Legal :)"}
                            eventDate={"14/11/2023"}
                            idEvent={"sdafjkghsakdjfhkjdfshfkhk"}
                        />

                        <NextEvent
                            title={"Happy Hour Event"}
                            description={"Evento Legal :)"}
                            eventDate={"14/11/2023"}
                            idEvent={"sdafjkghsakdjfhkjdfshfkhk"}
                        />
                    </div>

                </Container>
            </section>

            <VisionSection />
            <ContactSection />
        </MainContent>
    );
};

export default HomePage;