import { Component } from "react";

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

            <div>
                <main>
                    {/* Lista de Usuarios */}
                    <section>
                        <form onSubmit={this.consultarPerfil} >
                            <div>

                                {/**   //valor do state é o input */}
                                <input type="text"

                                    id="input_user"
                                    placeholder="nome do usuário"
                                    value={this.state.nomeUsuario}
                                    onChange={this.atualizaEstadoNome}
                                //cada vez que tiver uma mudanca, (por tecla)                                                                  
                                />
                                <button type="submit">Buscar</button>
                                {/* <button onClick={() => this.consultarPerfil(user)} >Buscar</button> */}

                            </div>
                        </form>
                        <h2>Lista de Usuarios</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>Nome </th>
                                    <th>Descrição</th>
                                    <th>Id</th>
                                    <th>Data de criação</th>
                                    <th>Tamanho</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaUsuarios.map((user) => {
                                        //console.log(user)
                                        return (
                                            <tr>
                                                <td>{user.name}</td>
                                                <td>{user.description}</td>
                                                <td>{user.id}</td>
                                                <td>{user.created_at}</td>
                                                <td>{user.size}</td>
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
