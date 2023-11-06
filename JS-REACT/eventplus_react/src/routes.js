import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

//import dos componentes de página
import HomePage from "./Pages/HomePage/HomePage";
import EventosPage from "./Pages/EventosPage/EventosPage";
import TipoEventosPage from "./Pages/TipoEventosPage/TipoEventosPage";
import LoginPage from "./Pages/LoginPage/LoginPage";
import TestePage from "./Pages/TestePage/TestePage";

import Header from "./Components/Header/Header";

const Rotas = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} path="/" exact />
        <Route element={<TipoEventosPage />} path="/tipo-eventos" />
        <Route element={<EventosPage />} path="/eventos" />
        <Route element={<LoginPage />} path="/login" />
        <Route element={<TestePage />} path="/testes" />
      </Routes>
    </BrowserRouter>
  );
};

export default Rotas;