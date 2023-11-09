import React, { useEffect, useState } from 'react';
import './HomePage.css'
import MainContent from '../../Components/MainContent/MainContent';
import Title from '../../Components/Title/Title';
import Banner from '../../Components/Banner/Banner';
import VisionSection from '../../Components/VisionSection/VisionSection';
import NextEvent from '../../Components/NextEvent/NextEvent';
import Container from '../../Components/Container/Container';
import ContactSection from '../../Components/ContactSection/ContactSection';
import axios from 'axios';

const HomePage = () => {

    const endereco = "http://localhost:5000/api/Evento/ListarProximos"

    useEffect(() => {
        //chamar a api
        async function getProximosEventos() {
            try {

                const promise = await axios.get("http://localhost:5000/api/Evento/ListarProximos")

                console.log(promise.data);

                setNextEvents(promise.data)

            } catch (error) {
                alert("Deu Ruim !!!")
            }
        }

        console.log("A HOME FOI MONTADA");

        getProximosEventos()
    }, []);

    // fake mock - api mocada
    const [nextEvents, setNextEvents] = useState([]);

    return (
        <MainContent>
            <Banner />

            {/* Próximos Eventos */}
            <section className="proximos-eventos">
                <Container>
                    <Title titleText={"Próximos Eventos"} />

                    <div className="events-box">
                        {
                            nextEvents.map((e) => {
                                return (
                                    <NextEvent
                                        title={e.nomeEvento}
                                        description={e.descricao}
                                        eventDate={e.dataEvento}
                                        idEvent={e.idEvento}
                                    />
                                );
                            })
                        }
                    </div>

                </Container>
            </section>

            <VisionSection />
            <ContactSection />
        </MainContent>
    );
};

export default HomePage;