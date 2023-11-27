import React, { useContext } from 'react';
import { ThemeContext } from '../../context/ThemeContext';

const MeusPedidosPage = () => {

    const { theme } = useContext(ThemeContext)

    return (
        <div>
            <h1>Meus Pedidos</h1>
            <span>Tema Atual: {theme}</span>
        </div>
    );
};

export default MeusPedidosPage;