import React from 'react'
import logo from '../../assets/img/medgroup-hori.png'
import logo_branca from '../../assets/img/logo_branca.png'

import email from '../../assets/img/email.png'
import twitter from '../../assets/img/twitter.png'
import instagram from '../../assets/img/instagram.png'
import youtube from '../../assets/img/youtube.png'

export default function Header() {

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

                        <a className="btn_menu" href="#" onclick="BotaoDoMenu()">
                            <i className="fas fa-bars"></i>
                        </a>
                        <a href="#home"><img className="logo_site" src={logo} alt="logo do site" /></a>
                        <a href="home"><img className="logo_branca_mobile" src={logo_branca} alt="logo site branco" /></a>
                    </div>
                    <div>
                        <nav id="links" className="menu_header">
                            <a href="#home">Home</a>
                            <a href="">Agendamento</a>
                            <a href="#quemsomos">Quem somos</a>
                            <a href="">Login</a>
                            <a className="fechar" href="#" onclick="BotaoDoMenu()">Fechar</a>
                        </nav>
                    </div>
                </div>
                
            </header>

        </div>
    )

}