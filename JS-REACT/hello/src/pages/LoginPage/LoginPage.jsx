import React, { useContext } from 'react';
import { ThemeContext } from '../../context/ThemeContext';

const LoginPage = () => {

    const { theme } = useContext(ThemeContext)

    return (
        <div>
            <h1>Página de Login</h1>
            <span>Tema Atual: {theme}</span>
        </div>
    );
};

export default LoginPage;