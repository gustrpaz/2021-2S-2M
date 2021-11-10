import React from 'react'
import logo_branca from '../../assets/img/logo_branca.png'

export default function Footer() {

    return (

        <div>
            <footer>
                <div class="container_footer">
                    <div class="box_footer">
                        <div class="links_uteis">
                            <ul class="none">
                                <li> <a href="">Serviços</a></li>
                                <li> <a href="mailto:grezendepaz@gmail.com">Contatar</a></li>
                            </ul>
                        </div>

                        <a href="#home"><img class="logo_branca" src={logo_branca} alt="logo do site" /></a>

                        <div class="Copyright">
                            <span>Copyright © 2021 - SPmedicalGroup</span>
                        </div>
                    </div>

                </div>

            </footer>
        </div>
    )

}