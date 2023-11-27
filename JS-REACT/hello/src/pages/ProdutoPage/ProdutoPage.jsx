import React, { useContext } from 'react';
import { ThemeContext } from '../../context/ThemeContext';

const ProdutoPage = () => {

    const { theme } = useContext(ThemeContext)

    return (
        <div>
            <h1>Página de Produtos</h1>
            <span>Tema Atual: {theme}</span>
        </div>
    );
};

export default ProdutoPage;