import React from 'react';
import { Link } from 'react-router-dom';

const NotFoundPage = () => {
    return (
        <>
            <h1>
                Página não encontrada
            </h1>
            <Link to="/">Home</Link>
        </>
    )
};

export default NotFoundPage;