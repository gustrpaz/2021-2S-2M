import React from 'react'
import logo_branca from '../../assets/img/logo_branca.png'

export default function Footer() {

    return (

        <div>
            <footer>
                <div className="container_footer">
                    <div className="box_footer">
                        <div className="links_uteis">
                            <ul className="none">
                                <li> <a href="/">Serviços</a></li>
                                <li> <a href="mailto:grezendepaz@gmail.com">Contatar</a></li>
                            </ul>
                        </div>

                        <a href="#home"><img className="logo_branca" src={logo_branca} alt="logo do site" /></a>

                        <div className="Copyright">
                            <span>Copyright © 2021 - SPmedicalGroup</span>
                        </div>
                    </div>

                </div>

            </footer>
        </div>
    )

}