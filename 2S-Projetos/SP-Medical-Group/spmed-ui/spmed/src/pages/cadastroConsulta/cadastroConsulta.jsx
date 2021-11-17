import React from 'react'
import axios from 'axios';

import { Component } from 'react';
import Footer from '../../components/footer/footer'
import Header from '../../components/header/header'
import "../../assets/css/cadastroConsulta.css"

import background_section from '../../assets/img/background section.png'


export default class Cadastrar extends Component {
    constructor(props) {
        super(props)
        this.state = {
            idPaciente: 0,
            idMedico: 0,
            idSituacao: 0,
            idClinica: 0,
            dataHora: new Date(),
            descricao: '',

            listaPacientes: [],
            listaMedicos: [],
            listaClinicas: [],
            listaSituacao: [],
            isLoading: false,
        }
    }
    

    buscarPacientes = () => {
        axios('http://localhost:5000/api/pacientes', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaPacientes: resposta.data })
                console.log(resposta.data)
            }
        }).catch((erro) => console.log(erro))
    }

    buscarMedico = () => {
        axios('http://localhost:5000/api/medicos', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaMedicos: resposta.data })
                console.log(resposta.data)
            }
        }).catch((erro) => console.log(erro))
    }

    buscarClinica = () => {
        axios('http://localhost:5000/api/clinicas', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaClinicas: resposta.data })
            }
        }).catch((erro) => console.log(erro))
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

    cadastrarConsulta = (evento) => {
        evento.preventDefault();

        let consulta = {
            idPaciente: this.state.idPaciente,
            idMedico: this.state.idMedico,
            idSituacao: this.state.idSituacao,
            idClinica: this.state.idClinica,
            dataHora: this.state.dataHora,
            descricao: this.state.descricao
        }
        this.setState({ isLoading: true })
        axios.post('http://localhost:5000/api/consultas', consulta, {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Consulta Cadastrada')
                    this.setState({ isLoading: false })
                    this.setState({
                        idPaciente: 0,
                        idMedico: 0,
                        idSituacao: 0,
                        idClinica: 0,
                        dataHora: new Date(),
                        descricao: ''
                    })
                }
            })
            .catch((erro) => {
                if (erro.toJSON().status === 401) {
                    this.props.history.push('/login')
                }
                else console.log(erro)
            })
    }

    componentDidMount() {
        this.buscarClinica();
        this.buscarMedico();
        this.buscarPacientes();
        this.buscarSituacao();
    }

    render() {
        return (
            <div>
                <Header />
                <main>
                    <div className="consultas_cadastro">
                        <img src={background_section} alt="máscaras de hospital" />
                        <div className="box_conteudo_cadastro">
                            <h1>Consultas</h1>
                        </div>
                    </div>
                    <section className="corpo_consulta_cadastro">

                        <div className="form-group_cadastro">

                            <div>
                                <h1>Agende uma consulta</h1>
                            </div>

                            <form action="" className="container_input1_cadastro" onSubmit={this.cadastrarConsulta}>
                                <select className="input-form_cadastro" name="idPaciente" value={this.state.idPaciente} onChange={this.atualizaStateCampo}>
                                    <option value="0" selected disabled>
                                        Selecione o Paciente
                                    </option>

                                    {this.state.listaPacientes.map((tema) => {
                                        return (
                                            <option key={tema.id} value={tema.idPaciente}>
                                                {tema.nome}
                                            </option>
                                        );
                                    })}
                                </select>

                                <select className="input-form_cadastro" name="idMedico" value={this.state.idMedico} onChange={this.atualizaStateCampo}>
                                    <option value="0" selected disabled>
                                        Selecione o Médico
                                    </option>

                                    {this.state.listaMedicos.map((tema) => {
                                        return (

                                            <option key={tema.idMedico} value={tema.idMedico}>
                                                {tema.nomeMedico}
                                            </option>
                                        );
                                    })}
                                </select>


                                <select className="input-form_cadastro" name="idClinica" value={this.state.idClinica} onChange={this.atualizaStateCampo}>
                                    <option value="0" selected disabled>
                                        Selecione a Clínica
                                    </option>

                                    {this.state.listaClinicas.map((tema) => {
                                        return (
                                            <option key={tema.idClinica} value={tema.idClinica}>
                                                {tema.nomeClinica}
                                            </option>
                                        );
                                    })}
                                </select>


                                <select className="input-form_cadastro" name="idSituacao" value={this.state.idSituacao} onChange={this.atualizaStateCampo}>
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


                                <input type="datetime-local" className="input-form_cadastro" name="dataHora" value={this.state.dataHora} onChange={this.atualizaStateCampo} />


                            <input placeholder="Descrição" name="descricao" value={this.state.descricao} className="Adc_descricao" onChange={this.atualizaStateCampo}>
                                 
                            </input>

                                <div className="box_button_cadastro">
                                    <button type="submit" className="botao_cadastro">
                                        Agendar
                                    </button>

                                    {/* <button className="ver_todas_cadastro" onClick={redirecionar}>Ver todas consultas</button> */}
                                </div>
                            </form>
                        </div>
                    </section>
                </main >

                <Footer />
            </div>
        )
    }
}
