import React from 'react'
import { Component } from 'react';
import Footer from '../../components/footer/footer'
import Header from '../../components/header/header'

import background_section from '../../assets/img/background section.png'

import "../../assets/css/listaConsulta.css"
import { render } from '@testing-library/react';

export default class ListaConsultaPac extends Component {
    constructor(props) {
        super(props);
        this.state = {
            erroMensagem: '',
            listaConsultas: [],
            isLoading: false
        }
    }

    buscarConsultas = () => {
        console.log('salve agora vamos fazer a chamada para a api.');

        //funcao nativa JS, ele é uma API com métodos.

        //dentro dos parenteses vamos informar qual é o end point.
        fetch('http://localhost:5000/api/consultas/minhas', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },

        })
            //por padrao ele sempre inicia como GET.
           
            .then((resposta) => resposta.json())

            //.then( dados => console.log(dados.json()))

            // quando vc tiver uma retorno, vc vai trazer essa resposta em json.

            // Define o tipo de dados do retorno da requisicao como JSON.

            // .then( resposta => resposta.json())

            // Atualiza o state listaTiposEventos com os dados obtidos em formato json.
            .then((dados) => this.setState({ listaConsultas: dados }))
         
            //caso ocorre algum erro, mostra no console do navegador

            .catch((erro) => console.log(erro));
    };

    componentDidMount() {
        this.buscarConsultas();
    }

    render() {

        return (
            <div>

                <Header />
                <main>
                    <div className="consultas_Lista">
                        {/* <img src={background_section} alt="" /> */}
                        <div className="box_conteudo_Lista">
                            <h1>Consultas</h1>
                        </div>
                    </div>
                    <section className="corpo_consultas_Lista">
                        <div className="container_consultas_Lista">
                            <h1>Todas as consultas</h1>

                            {this.state.listaConsultas.map((consulta) => {
                                return (
                                    console.log('chegou'),
                                    <div className="box_consultas_Lista">
                                        <div className="info_consulta_Lista">
                                            <div>                                              
                                               <span>Data da consulta: {Intl.DateTimeFormat("pt-BR",{
                                                year: "numeric", month: "numeric", day: "numeric", hour: "numeric", minute: "numeric"
                                            }).format(new Date(consulta.dataHora))}</span>
                                                <span>Especialidade: {consulta.idMedicoNavigation.idEspecialidadeNavigation.especialidades} </span>
                                                <span>Médico: {consulta.idMedicoNavigation.nomeMedico} </span>
                                                <span>Situação: {consulta.idSituacaoNavigation.situacao1} </span>
                                                <span>Clínica: {consulta.idMedicoNavigation.idClinicaNavigation.nomeClinica} </span>
                                            </div>
                                        </div>

                                        <div className="desc_consulta_Lista">
                                            <div className="span_da_Descricao">
                                                <span>Descrição:</span>
                                                <div className="box_da_Descricao">
                                                    <span>{consulta.descricao}</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                )
                            })}

                        </div>
                    </section>

                </main>

                <Footer />

            </div>

        );

    }

}