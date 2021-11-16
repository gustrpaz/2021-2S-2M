import React from 'react'
import { Link } from 'react-router-dom'
import Footer from '../../components/footer/footer'
import Header from '../../components/header/header'
import "../../assets/css/home.css"

export default function Especialidade() {
    return (
        <div>
            <Header />
            <main>
                <div className="especialidade">
                    <img src="./assets/background section.png" alt="" />
                    <div className="box_conteudo_especialidade">
                        <h1>Especialidades</h1>
                    </div>
                </div>
                <section className="corpo_especialidades">

                    <div className="form-group_especialidade">
                        <div>
                            <h1>Todas especialidades</h1>
                        </div>
                        <div className="container_especialidades">

                            <div className="card_especialidade">
                                <span>Acupuntura</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Anestesiologia</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Angiologia</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Cardiologia</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Cirurgia Cardiovascular</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Cirurgia da Mão</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Cirurgia da Aparelho</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Digestivo</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Cirurgia Geral</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Cirurgia Pediátrica</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Cirurgia Torácica</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Cirurgia Vascular</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Dermatologia</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Radioterapia</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Urulogia</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Pediatria</span>
                            </div>

                            <div className="card_especialidade">
                                <span>Psiquiatria</span>
                            </div>

                        </div>

                    </div>

                </section>

            </main>

            <Footer />
        </div>
    )
}