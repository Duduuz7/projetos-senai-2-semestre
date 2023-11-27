import React, { useContext } from 'react';
import { ThemeContext } from '../../context/ThemeContext';

const HomePage = () => {

    const { theme } = useContext(ThemeContext)

    return (
        <div>
            <h1>Página Home</h1>
            <span>Tema Atual: {theme}</span>
        </div>
    );
};

export default HomePage;