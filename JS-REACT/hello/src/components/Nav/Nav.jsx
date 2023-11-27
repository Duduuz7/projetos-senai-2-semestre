import React, { useContext } from 'react';
import { Link } from 'react-router-dom'
import { ThemeContext } from '../../context/ThemeContext';

const Nav = () => {

    const {theme, setTheme} = useContext(ThemeContext)
    const alter = ( theme === 'Light' ? 'Dark'  : 'Light' )

    function alterarTema() {
        setTheme( theme === 'Light' ? 'Dark'  : 'Light' );
    }

    return (
        
        <nav>
            <Link to="/">Home</Link> | &nbsp;
            <Link to="/produtos">Produtos</Link> | &nbsp;
            <Link to="/importante">Importante</Link> | &nbsp;
            <Link to="/meus-pedidos">Meus Pedidos</Link> | &nbsp;
            <Link to="/login">Login</Link> | &nbsp;

            <button onClick={alterarTema}>{alter}</button>
        </nav>
    );
};

export default Nav;