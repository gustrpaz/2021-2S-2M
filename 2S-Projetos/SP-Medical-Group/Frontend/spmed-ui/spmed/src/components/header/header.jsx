import React from 'react'
import logo from '../../assets/img/medgroup-hori.png'
import logo_branca from '../../assets/img/logo_branca.png'

import email from '../../assets/img/email.png'
import twitter from '../../assets/img/twitter.png'
import instagram from '../../assets/img/instagram.png'
import youtube from '../../assets/img/youtube.png'

import { Link } from 'react-router-dom';
import UsuarioAutenticado from '../funcao login/funcao'


export default function Header() {
    function BotaoDoMenu() {
        var menu = document.getElementById("links");
        if (menu.style.display == "flex") {
            // Esconda o menu 
            menu.style.display = "none";
        } else {
            //Mostre o menu
            menu.style.display = "flex"
        }
    }

    return(
        <div>

            <header>
                <div className="container container_header">
                    <div className="first_nav">
                        <div className="container_first">
                            <div className="box_email">
                                <span>Entre em contato:</span>
                                <a href="mailto:grezendepaz@gmail.com">grezendepaz@gmail.com</a>
                            </div>
                            <div className="redes_sociais">
                                <a href="mailto:grezendepaz@gmail.com"><img className="email" src={email} alt="email" /></a>
                                <a href="https://twitter.com/Guhrezendin"><img className="twitter" src={twitter} alt="twitter" /></a>
                                <a href="https://www.instagram.com/slv.rezende/"><img className="instagram" src={instagram} alt="instagram" /></a>
                                <a href="https://www.youtube.com/channel/UCcPa9DHu3VKhiV9RQLXLhjw"><img className="youtube"src={youtube} alt="youtube" /></a>
                            </div>
                        </div>
                    </div>
                    <a href="#home"><img className="logo_site" src={logo} alt="logo do site" /></a>
                    <div className="menu_header_mobile">

                        <a className="btn_menu" href="#" onClick={BotaoDoMenu}>
                            <i className="fas fa-bars"></i>
                        </a>
                        <a href="#home"><img className="logo_site" src={logo} alt="logo do site" /></a>
                        <a href="#home"><img className="logo_branca_mobile" src={logo_branca} alt="logo site branco" /></a>
                    </div>
                    <div>
                        <nav id="links" className="menu_header">
                            <Link to="/"><button >Home</button></Link>
                            {/* Agendamento irá redirecionar para a tela de cadastro de consulta  */}
                            <Link to="/cadastroConsulta"><button>Agendamento</button></Link>
                            <a href="#quemsomos">Quem somos</a>
                            <UsuarioAutenticado />
                            <a className="fechar" href="#" onClick={BotaoDoMenu}>Fechar</a>
                        </nav>
                    </div>
                </div>
                
            </header>

        </div>
    )

}