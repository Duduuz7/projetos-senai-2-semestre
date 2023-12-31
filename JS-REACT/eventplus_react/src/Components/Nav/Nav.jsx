import React, { useContext } from "react";
import { Link } from 'react-router-dom';
import './Nav.css'

//imagens
import logoMobile from '../../assets/images/images/logo-white.svg'
import logoDesktop from '../../assets/images/images/logo-pink.svg'

//uses
import { UserContext } from "../../context/AuthContext";

//para tirar o props, fazer destructuring (passar so o nome)
const Nav = ({ setExibeNavbar, exibeNavbar }) => {

    const { userData } = useContext(UserContext)

    return (
        <nav className={`navbar ${exibeNavbar ? "exibeNavbar" : ""}`}>
            <span
                className='navbar__close'
                onClick={() => { setExibeNavbar(false) }}
            >
                x
            </span>

            <Link to="/">
                <img
                    className='eventlogo__logo-image'
                    src={window.innerWidth >= 992 ? logoDesktop : logoMobile}
                    alt="Event Plus Logo"
                />
            </Link>

            <div className='navbar__items-box'>

                <Link to="/" className="navbar__item">Home</Link>
                {userData.name && userData.role === "Administrador" ? (
                    <>
                        <Link to="/tipo-eventos" className="navbar__item">Tipo Eventos</Link>

                        <Link to="/eventos" className="navbar__item">Eventos</Link>
                    </>
                )
                    :
                    (
                        userData.role === "Aluno" ? (<Link to="/eventos-aluno" className="navbar__item">Eventos</Link>)
                            :
                            (null)
                    )}

                {/* <Link to="/login" className="navbar__item">Login</Link> */}
            </div>
        </nav>
    );
};

export default Nav;