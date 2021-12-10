// se estiver Logado o state do <a href="">Login></a> muda para Logout
// se tem algm coisa na localStorage, se estiver eu vou exibir logou, limpar local storage e voltar ele para a tela de login
// se não estiver nada no LocalStorage ele exibe 'Login'

import { Link } from "react-router-dom";
import { usuarioAutenticado } from "../../services/auth"


function analise() {


    return (

        // usuarioAutenticado() ? <Link to="/login"><button className="logout" onChange={this.logout()}>Logout</button></Link>  : <Link to="/login"><a href="">Login</a></Link>
        // usuarioAutenticado() ? <Link to="/login"><a href="">Logout</a></Link>  : <Link to="/login"><a href="">Login</a></Link>
        usuarioAutenticado() ? <Link to="/login"><button onClick={ () => localStorage.clear() } >Logout</button></Link>  : <Link to="/login"><button>Login</button></Link>
    )
}

export default analise