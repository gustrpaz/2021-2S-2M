import React from 'react'
import { Component } from 'react';
import Footer from '../../components/footer/footer'
import Header from '../../components/header/header'

import background_section from '../../assets/img/background section.png'
import background_body from '../../assets/img/raiox.png'

import "../../assets/css/listaConsultaMed.css";
import { render } from '@testing-library/react';
import axios from 'axios';

export default class ListaConsultaMed extends Component {
    constructor(props) {
        super(props);
        this.state = {
            erroMensagem: '',
            listaConsultas: [],
            isLoading: false,
        }
    }

    // atualizarDescricao = () => {
    //     //id e descricao
    //     axios.put('https://localhost:5001/api/consultas/' + idConsulta),
    //     {}
    // }

   

// ---------------------------------------------------------------------------------
// ---------------------------------------------------------------------------------

    buscarConsultas = () => {
        console.log('salve agora vamos fazer a chamada para a api.');

        //funcao nativa JS, ele é uma API com métodos.

        //dentro dos parenteses vamos informar qual é o end point.
        fetch('http://localhost:5000/api/consultas/minhasMed', {
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
                    <div className="medico_ListaMed">
                        <img src={background_section} alt="" />
                        <div className="box_conteudo_ListaMed">
                            <h1>Médico</h1>
                        </div>
                    </div>
                    <section className="corpo_consultas_ListaMed">
                        <div className="container_consultas_ListaMed">
                            <h1>consultas</h1>

                            {this.state.listaConsultas.map((consulta) => {
                                return (
                                    <div className="box_consultas_ListaMed">
                                        <div className="info_consulta_ListaMed">
                                            <div>
                                                <span>Nome do Paciente: {consulta.idPacienteNavigation.nome}</span>

                                                <span>Data da consulta: {Intl.DateTimeFormat("pt-BR", {
                                                    year: "numeric", month: "numeric", day: "numeric", hour: "numeric", minute: "numeric"
                                                }).format(new Date(consulta.dataHora))}</span>

                                                <span>Especialidade: {consulta.idMedicoNavigation.idEspecialidadeNavigation.especialidades} </span>
                                                <span>Situação: {consulta.idSituacaoNavigation.situacao1} </span>
                                                <span>Clínica: {consulta.idMedicoNavigation.idClinicaNavigation.nomeClinica} </span>

                                                <div className="box_botao_ListaMed">
                                                    <button className="botao_ListaMed" type="button">Editar descrição</button>
                                                </div>
                                            </div>
                                        </div>

                                        <div className="desc_consulta_ListaMed">
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