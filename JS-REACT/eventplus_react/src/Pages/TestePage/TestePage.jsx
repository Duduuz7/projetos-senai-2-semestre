import React from 'react';
import Button from '../../Components/Button/Button';
import Input from '../../Components/Input/Input';
import Header from '../../Components/Header/Header';

const TestePage = () => {
    return (
        <>
            <Header />
            <h1>Página de Testes</h1>
            <h2>Calculator</h2>
            <form >
                <Input />
                <Input />

                <Button />
            </form>
        </>

    );
};

export default TestePage;