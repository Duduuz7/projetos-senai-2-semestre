import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

//import dos componentes de página
import HomePage from "../Pages/HomePage/HomePage";
import EventosPage from "../Pages/EventosPage/EventosPage";
import EventosAlunoPage from "../Pages/EventosAlunoPage/EventosAlunoPage";
import TipoEventosPage from "../Pages/TipoEventosPage/TipoEventosPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import TestePage from "../Pages/TestePage/TestePage";

import Header from "../Components/Header/Header";
import Footer from "../Components/Footer/Footer";

import { PrivateRoute } from "./PrivateRoute";

const Rotas = () => {

  return (

    // Ordem: BrowserRouter > Routes > Route

    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} path="/" exact />

        <Route path="/tipo-eventos" element={
          <PrivateRoute redirectTo="/login">
            <TipoEventosPage />
          </PrivateRoute>
        } />

        <Route path="/eventos" element={
          <PrivateRoute redirectTo="/login">
            <EventosPage />
          </PrivateRoute>} />


        <Route path="/eventos-aluno" element={
          <PrivateRoute redirectTo="/login">
            <EventosAlunoPage />
          </PrivateRoute>} />

        <Route element={<LoginPage />} path="/login" />

        <Route element={<TestePage />} path="/testes" />

      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;
