import React from 'react'
import axios from 'axios';
import { Component } from 'react';
import Footer from '../../components/footer/footer'
import Header from '../../components/header/header'

import "../../assets/css/listaConsulta.css"

export default class ListaConsulta extends Component {
    constructor(props) {
        super(props);
        this.state = {
            erroMensagem: '',
            listaConsultas: [],
            idSituacao: 0,
            idConsultaAlterada: 0,
            listaSituacao: [],
            isLoading: false
        }
    }

    buscarConsultas = () => {
        console.log('salve agora vamos fazer a chamada para a api.');

        //funcao nativa JS, ele é uma API com métodos.

        //dentro dos parenteses vamos informar qual é o end point.
        fetch('http://localhost:5000/api/consultas', {
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

    alterarSituacao = (consulta) => {
        console.log(consulta.idConsulta)
        axios.patch('https://localhost:5001/api/consultas/' + consulta.idConsulta, {
            idSituacao: this.state.idSituacao
        }, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(response => {
                if (response.status === 204) {
                    console.log('Situação alterada');
                    this.buscarConsultas();
                }
            })
            .catch(erro => console.log(erro))
        
    }

    buscarSituacao = () => {
        axios('https://localhost:5001/api/situacoes', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaSituacao: resposta.data })
            }
        }).catch((erro) => console.log(erro))
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    };

    // atualizaStateTudo = (campo) => {
    //     console.log("akiiii");
    //     this.setState({ [campo.target.name]: campo.target.value });
    //     this.alterarSituacao();
        
    // };


    componentDidMount() {
        this.buscarConsultas();
        this.buscarSituacao();
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
                                    <div className="box_consultas_Lista">
                                        <div className="info_consulta_Lista">
                                            <div>
                                                <span>Data da consulta:{Intl.DateTimeFormat("pt-BR", {
                                                    year: "numeric", month: "numeric", day: "numeric", hour: "numeric", minute: "numeric"
                                                }).format(new Date(consulta.dataHora))}</span>

                                                <span>Especialidade: {consulta.idMedicoNavigation.idEspecialidadeNavigation.especialidades} </span>
                                                <span>Médico: {consulta.idMedicoNavigation.nomeMedico} </span>
                                                <span>Situação: {consulta.idSituacaoNavigation.situacao1} </span>
                                                <span>Clínica: {consulta.idMedicoNavigation.idClinicaNavigation.nomeClinica} </span>

                                                <select className="input_situacao" name="idSituacao" value={this.state.idSituacao} onChange={this.atualizaStateCampo}>
                                                    <option value="0" selected disabled>
                                                        Selecione a Situação
                                                    </option>

                                                    {this.state.listaSituacao.map((tema) => {
                                                        return (
                                                            <option key={tema.idSituacao} value={tema.idSituacao}>
                                                                {tema.situacao1}
                                                            </option>
                                                        );
                                                    })}
                                                </select>

                                                <div className='boxSalvar'>
                                                    <button className="BtnSalvar" onClick={() => this.alterarSituacao(consulta)}>Salvar</button>
                                                </div>

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

