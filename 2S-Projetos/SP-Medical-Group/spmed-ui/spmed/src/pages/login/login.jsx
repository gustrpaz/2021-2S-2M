import { Component } from 'react';
import React from 'react'
import Footer from '../../components/footer/footer'
import logo from '../../assets/img/medgroup-hori.png'
import desenho from '../../assets/img/undraw_medicine_b1ol.svg'
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link } from 'react-router-dom';



import "../../assets/css/login.css"
import axios from 'axios';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            erroMensagem: '',
            isLoading: false
        }
    }

    // Função que faz a chamada para a API para realizar o login
        efetuaLogin = (event) => {
        //ignora o comportamento padrão do navegador (recarregar a página, por exemplo)
        event.preventDefault();

        this.setState({ erroMensagem: '', isLoading: true });

        axios.post('http://localhost:5000/api/Login', {
            email: this.state.email,
            senha: this.state.senha
        })

            // recebe todo o conteúdo da resposta da requisição na variável resposta
            .then(resposta => {
                console.log(resposta)
                // verifico se o status code dessa resposta é igual a 200
                if (resposta.status === 200) {
                    // se sim, exibe no console do navegador o token do usuário logado,
                    // salva o valor do token do localStorage
                    localStorage.setItem('usuario-login', resposta.data.token);
                    // e define que a requisição terminou
                    this.setState({ isLoading: false })

                    // define a variável base64 que vai receber o payload do token
                    let base64 = localStorage.getItem('usuario-login').split('.')[1];
                    //exibe no console o valor em base64
                    console.log(base64);

                    // exibe as propriedades da página
                    console.log(this.props);

                    // verifica se o usuário logado é do tipo administrador
                    if (parseJwt().role === '1') {
                        this.props.history.push('/');
                        console.log('estou logado: ' + usuarioAutenticado())
                    }


                    else {
                        this.props.history.push('/')
                    }
                }
            })

            // Caso haja um erro,
            .catch(() => {
                // define o valor do state erroMensagem com uma mensagem personalizada
                this.setState({ erroMensagem: 'E-mail e/ou senha inválidos!', isLoading: false })
            })
    };

    atualizaStateCampo = (campo) => {
        // quando estiver digitando no campo username 
        // email : adm@adm.com

        // quando estiver digitando no campo password
        //  senha : 123
        this.setState({ [campo.target.name]: campo.target.value })
    }

    render() {
        return (

            <div>

                <main className="main_login">
                    <div className="background_login">
                        <img src={desenho} />
                    </div>

                    <div className="criar_conta_login">
                        <Link to="/"><img src={logo} alt="" /></Link>

                        <form onSubmit={this.efetuaLogin}>
                            <div className="form-group_login">
                                <h1>Login</h1>

                                <div className="container_input_login">

                                    <label className="txt-form_login">Email</label>
                                    <input className="input-form_login"
                                        type="text"
                                        name="email"
                                        value={this.state.email}
                                        onChange={this.atualizaStateCampo}
                                    />

                                    <label className="txt-form_login">Senha</label>
                                    <input className="input-form_login"
                                        type="password"
                                        name="senha"
                                        value={this.state.senha}
                                        onChange={this.atualizaStateCampo}
                                    />

                                    <div className="box_botao_login">
                                        {/* Exibe a mensagem de erro ao tentar logar com credenciais inválidas */}
                                        <p style={{ color: 'red' }} >{this.state.erroMensagem}</p>

                                        {/* 
                                          Verifica se a requisição está em andamento
                                          Se estiver, desabilita o click do botão
                                        */}

                                        {
                                            // Caso seja true, renderiza o botão desabilitado com o texto 'Loading...'
                                            this.state.isLoading === true &&
                                            <button type="submit" disabled className="botao_login">
                                                Loading...
                                            </button>
                                        }
                                       {
                                            // Caso seja false, renderiza o botão habilitado com o texto 'Login'
                                            this.state.isLoading === false &&
                                            <button 
                                                className="botao_login"
                                                type="submit"
                                                disabled={ this.state.email === '' || this.state.senha === '' ? 'none' : '' }>
                                                Login
                                            </button>
                                        }

                                </div>

                                </div>
                            </div>
                        </form>
                    </div>

                </main>

                <Footer />

            </div>


        );
    }
}
