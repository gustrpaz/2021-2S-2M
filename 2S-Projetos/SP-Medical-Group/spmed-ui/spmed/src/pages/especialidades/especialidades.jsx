import React from 'react'
import { Link } from 'react-router-dom'
import Footer from '../../components/footer/footer'
import Header from '../../components/header/header'
import "../../assets/css/especialidades.css"

import background_section from '../../assets/img/background section.png'

export default function Especialidade() {
    return (
        <div>
            <Header />
            <main>
                <div className="especialidadeES">
                    <img src={background_section} alt="" />
                    <div className="box_conteudo_especialidadeES">
                        <h1>Especialidades</h1>
                    </div>
                </div>
                <section className="corpo_especialidadesES">

                    <div className="form-group_especialidadeES">
                        <div>
                            <h1>Todas especialidades</h1>
                        </div>
                        <div className="container_especialidadesES">

                            <div className="card_especialidadeES">
                                <span>Acupuntura</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Anestesiologia</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Angiologia</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Cardiologia</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Cirurgia Cardiovascular</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Cirurgia da Mão</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Cirurgia da Aparelho</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Digestivo</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Cirurgia Geral</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Cirurgia Pediátrica</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Cirurgia Torácica</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Cirurgia Vascular</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Dermatologia</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Radioterapia</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Urulogia</span>
                            </div>

                            <div className="card_especialidadeES">
                                <span>Pediatria</span>
                            </div>

                            <div className="card_especialidadeES">
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