import React from 'react'
import axios from 'axios';
import { Component } from 'react';
import Footer from '../../components/footer/footer'
import Header from '../../components/header/header'
import "../../assets/css/cadastroConsulta.css"

import background_section from '../../assets/img/background section.png'


export default class CadastroConsulta extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idPaciente: 0,
            idMedico: 0,
            idSituacao: 4,
            dataConsulta: new Date(),
            descricaoConsulta,

            listaPacientes: [],
            listaMedicos: [],
      
            isLoading: false,
        }
    }

    cadastrarConsultas(evento) {
        evento.preventDefault();
        axios.post("http://localhost:5000/api/consultas", {
            idPaciente: idPaciente,
            idMedico: idMedico,
            idSituacao: idSituacao,
            dataConsulta: new Date(dataConsulta)
        }, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log("consulta cadastrada");
                    buscarConsultas();


                }
            }).catch(erro => console.log(erro))
    }

    render() {
        return (
            <div>
            <Header />
            <main>
                <div className="consultas_cadastro">
                    <img src={background_section} alt="máscaras de hospital"/>
                    <div className ="box_conteudo_cadastro">
                    <h1>Consultas</h1>
                    </div>
                </div>
                <section className="corpo_consulta_cadastro">

                    <div className="form-group_cadastro">

                        <div>
                            <h1>Agende uma consulta</h1>
                        </div>


                        <form className="container_input1">
                            <label className="texto-form1_cadastro">Especialidade</label>
                            <input className="input-form_cadastro" type="text" />

                            <label className="texto-form_cadastro">Nome Completo</label>
                            <input className="input-form_cadastro" type="text" />

                            <label className="texto-form_cadastro">Data de Nascimento</label>
                            <input className="input-form_cadastro" type="text" />

                            <label className="texto-form_cadastro">Telefone (+55)</label>
                            <input className="input-form_cadastro" type="text" />

                            <label className="texto-form_cadastro">RG</label>
                            <input className="input-form_cadastro" type="text" />

                            <label className="texto-form_cadastro">CPF</label>
                            <input className="input-form_cadastro" type="text" />

                            <div className="box_button_cadastro">
                                <button type="button" className="botao_cadastro">Agendar</button>
                                <a href="">Ver todas consultas</a>
                            </div>
                        </form>
                    </div>
                </section>
            </main >

            <Footer/>
            </div>
        )
    }
}
