import React, { useContext, useEffect, useState } from 'react';
import './HomePage.css'
import MainContent from '../../Components/MainContent/MainContent';
import Title from '../../Components/Title/Title';
import Banner from '../../Components/Banner/Banner';
import VisionSection from '../../Components/VisionSection/VisionSection';
import NextEvent from '../../Components/NextEvent/NextEvent';
import Container from '../../Components/Container/Container';
import ContactSection from '../../Components/ContactSection/ContactSection';
import api from '../../Services/Services';
import { UserContext } from '../../context/AuthContext';

const HomePage = () => {

    const { userData } = useContext(UserContext)

    console.log("DADOS GLOBAIS:");
    console.log(userData);

    useEffect(() => {
        //chamar a api
        async function getProximosEventos() {
            try {

                const promise = await api.get("/Evento/ListarProximos")

                console.log(promise.data);

                setNextEvents(promise.data)

            } catch (error) {
                console.log("Deu Ruim !!!")
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
                                        key={e.idEvento}
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