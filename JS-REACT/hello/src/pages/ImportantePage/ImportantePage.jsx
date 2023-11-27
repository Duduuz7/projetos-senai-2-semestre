import React, { useContext } from 'react';
import { ThemeContext } from '../../context/ThemeContext';
import './ImportantePage.css'

const ImportantePage = () => {

    const { theme } = useContext(ThemeContext)

    return (

       <div>
             <h1>Página de dados importantes</h1>
             <span>Tema Atual: {theme}</span>
       </div>
    );
};

export default ImportantePage;