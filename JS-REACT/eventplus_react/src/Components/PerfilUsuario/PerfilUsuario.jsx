import { useContext } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './PerfilUsuario.css'

import iconeLogout from '../../assets/images/images/icone-logout.svg'

import { UserContext } from '../../context/AuthContext';

const PerfilUsuario = () => {

    const { userData, setUserData } = useContext(UserContext);

    const navigate = useNavigate();

    function logout() {
        // Limpa o localStorage para remover o token de autenticação !!
        localStorage.clear();

        // Limpa os dados do usuário no contexto, o setando como vazio {}
        setUserData({});

        navigate("/");
    }

    return (
        <div className="perfil-usuario">
            {userData.name ? (

                <>
                    <span className="perfil-usuario__menuitem">{userData.name}</span>

                    <img
                        title="Deslogar"
                        className="perfil-usuario__icon"
                        src={iconeLogout}
                        alt="imagem ilustrativa de uma porta de saída do usuário "
                        onClick={logout}
                    />

                </>

            )

                :

                (

                    <Link to="/login" className="perfil-usuario__menuitem">Login</Link>

                )}

        </div>
    );
};

export default PerfilUsuario;