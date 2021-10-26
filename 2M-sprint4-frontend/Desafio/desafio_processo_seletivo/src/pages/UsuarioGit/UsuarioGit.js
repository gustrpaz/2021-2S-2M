import { Component } from "react";
import './UsuarioGit.css';

export default class UsuarioGit extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaUsuarios: [],
            nomeUsuario: ''
        }
    };

    // GET /users/{username}/repos

    consultarPerfil = (element) => {
        element.preventDefault();
        console.log('realizando a chamada para a API')

        fetch('https://api.github.com/users/' + this.state.nomeUsuario + '/repos?per_page=10&sort=author-date-desc')
            .then(resposta => (resposta.json()))
            .then(dados => this.setState({ listaUsuarios: dados }))
            .catch(erro => console.log(erro))
        console.log(this.state.listaUsuarios)
    }

    //onChange vai disparar por tecla e invocar essa funcao.
    atualizaEstadoNome = async (event) => {
        //console.log('acionou essa funcao')

        await this.setState({
            //dizendo que o target (alvo) do evento ,  vamos pegar o value(valor) 
            nomeUsuario: event.target.value
        });
        console.log(this.state.nomeUsuario);
    };

    render() {
        return (

            <div class="Body">
                <main>
                    {/* Lista de Usuarios */}
                    <section class="Corpo">
                        <form onSubmit={this.consultarPerfil} >
                            <div class="Container_Input">

                                {/**   //valor do state é o input */}
                                <input type="text"

                                    id="input_user"
                                    placeholder=" Nome de usuário"
                                    value={this.state.nomeUsuario}
                                    onChange={this.atualizaEstadoNome}
                                //cada vez que tiver uma mudanca, (por tecla)                                                                  
                                />
                                <button class="btn-app" type="submit">Buscar</button>
                                {/* <button onClick={() => this.consultarPerfil(user)} >Buscar</button> */}

                            </div>
                        </form>
                        <h2>Usuário encontrado</h2>
                        <table>
                            <thead>
                                <div class="box_coluna">
                                    <tr class="colunas">
                                        <th class="name_">Nome </th>
                                        <th class="descricao_">Descrição</th>
                                        <th class="id_">Id</th>
                                        <th class="criacao_">Data de criação</th>
                                        <th class="size_">Tamanho</th>
                                    </tr>
                                </div>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaUsuarios.map((user) => {
                                        //console.log(user)
                                        return (
                                            <tr class="Lista">
                                                <td class="name">{user.name}</td>
                                                <td class="descricao">{user.description}</td>
                                                <td class="id">{user.id}</td>
                                                <td class="criacao">{user.created_at}</td>
                                                <td class="size">{user.size}</td>
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>

                </main>
            </div>
        )
    }
};
