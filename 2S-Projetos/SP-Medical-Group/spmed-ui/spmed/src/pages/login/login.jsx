import React from 'react'
import Footer from '../../components/footer/footer'
import logo from '../../assets/img/medgroup-hori.png'
import desenho from '../../assets/img/undraw_medicine_b1ol.svg'


import "../../assets/css/login.css"

export default function Login() {

    return (

        <div>

            <main>
                <div className="background">
                    <img src={desenho} />
                </div>

                <div className="criar_conta">
                    <img src={logo} alt="" />

                    <div className="form-group">
                        <h1>Login</h1>

                        <div className="container_input">

                            <label className="txt-form">Email</label>
                            <input className="input-form" type="text" />

                            <label className="txt-form">Senha</label>
                            <input className="input-form" type="text" />

                            <div className="box_botao">
                                <button type="button" className="botao">Login</button>

                            </div>

                        </div>
                    </div>
                </div>

            </main>

            <Footer />

        </div>


    );
}
