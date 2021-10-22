import { Component } from "react";

export default class TiposEventos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaTiposEventos: [],
            titulo: '',
            idTipoEventoAlterado: 0
        }

    };

    buscarTipoEventos = () => {
        console.log('agora vamos fazer a chamada para a api.')

        //funcao nativa JS, ele é uma API com métodos.

        //dentro dos parenteses vamos informar qual é o end point.
        fetch('http://localhost:5000/api/tiposeventos')

            //por padrao ele sempre inicia como GET.

            .then(resposta => resposta.json())

            //.then( dados => console.log(dados.json()))

            //quando vc tiver uma retorno, vc vai trazer essa resposta em json.

            //Define o tipo de dados do retorno da requisicao como JSON.

            // .then( resposta => resposta.json())

            //Atualiza o state listaTiposEventos com os dados obtidos em formato json.
            .then(dados => this.setState({ listaTiposEventos: dados }))

            //caso ocorre algum erro, mostra no console do navegador

            .catch(erro => console.log(erro))
    }


    //onChange vai disparar por tecla e invocar essa funcao.
    atualizaEstadoTitulo = async (event) => {

        //console.log('acionou essa funcao')

        await this.setState({
            //dizendo que o target (alvo) do evento ,  vamos pegar o value(valor) 
            titulo: event.target.value

        })

        console.log(this.state.titulo);
    }



    manipularTipoEvento = (submit_formulario) => {
        submit_formulario.preventDefault();

        console.log(JSON.stringify({ tituloTipoEvento: this.state.titulo }))
        // Caso algum Tipo de Evento seja selecionado para edição
        if (this.state.idTipoEventoAlterado !== 0) {

            // Faz a chamada para a API usando fetch e passando o ID do tipo de evento que será atualizado na URL da requisição
            // http://localhost:5000/api/tipoeventos/5
            fetch('http://localhost:5000/api/tiposeventos/' + this.state.idTipoEventoAlterado, {

                // Define o método da requisição ( PUT )
                method: 'PUT',

                // Define o corpo da requisição especificando o tipo ( JSON )
                body: JSON.stringify({ tituloTipoEvento: this.state.titulo }),

                // Define o cabeçalho da requisição
                headers: {
                    "Content-Type": "application/json"
                }
            })

                .then(resposta => {
                    // Caso a requisição retorne um status code 204,
                    if (resposta.status === 204) {
                        console.log(
                            // Exibe no console do navegador a mensagem abaixo
                            'O Tipo de Evento ' + this.state.idTipoEventoAlterado + ' foi atualizado',

                            // e informa seu novo título
                            'Seu novo título agora é: ' + this.state.titulo
                        );
                    };
                })

                .catch(erro => console.log(erro))
                .then(this.buscarTipoEventos)

                .then(this.limparCampos);

        }
        else {
            fetch('http://localhost:5000/api/tiposeventos', {

                method: 'POST',

                body: JSON.stringify({ tituloTipoEvento: this.state.titulo }), //lembrado que aqui e um obj js e nao json.

                headers: {
                    "Content-Type": "application/json"
                }
            })
                //Exibe no console a msg "Tipo de evento cadastrado"
                .then(console.log("Tipo de evento cadastrado."))

                //caso ocorra algum erro, mostra no console do navegador.
                .catch(erro => console.log(erro))

                .then(this.buscarTipoEventos)
                .then(this.limparCampos);

        }

        
    }



    componentDidMount() {
        this.buscarTipoEventos()
    }

    // Recebe um tipo de evento da lista
    buscarTipoEventoPorId = (tipoEvento) => {
        this.setState({
            // Atualiza o state idTipoEventoAlterado com o valor do ID do Tipo de Evento recebido
            idTipoEventoAlterado: tipoEvento.idTipoEvento,
            // e o state titulo com o valor do título do Tipo de Evento recebido
            titulo: tipoEvento.tituloTipoEvento
        }, () => {
            console.log(
                'O Tipo de Evento ' + tipoEvento.idTipoEvento + ' foi selecionado, ',
                'agora o valor do state idTipoEventoAlterado é: ' + this.state.idTipoEventoAlterado,
                'e o  valor do state título é: ' + this.state.titulo
            );
        });
    };

    limparCampos = () => {
        this.setState({
            titulo: '',
            idTipoEventoAlterado: 0
        })
        console.log('Os states foram resetados')
    };

    render() {
        return (
            <div>
                <main>
                    {/* Lista de Tipos de Eventos */}
                    <section>
                        <h2>Lista de Tipos de Eventos</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Título</th>
                                    <th>Ações</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaTiposEventos.map((tipoEvento) => {
                                        //console.log(tipoEvento)
                                        return (
                                            <tr key={tipoEvento.idTipoEvento}>
                                                <td>{tipoEvento.idTipoEvento}</td>
                                                <td>{tipoEvento.tituloTipoEvento}</td>
                                                <td><button onClick={() => this.buscarTipoEventoPorId(tipoEvento)}>Editar</button></td>
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>

                    <section>
                        {/**Cadastro por tipo de evento */}
                        <h2>Cadastro de tipo de evento</h2>
                        <form onSubmit={this.manipularTipoEvento}  >
                            <div>
                                {/**   //valor do state é o input */}
                                <input

                                    type="text"
                                    value={this.state.titulo}
                                    placeholder="Título do Tipo de Evento"

                                    //cada vez que tiver uma mudanca, (por tecla)
                                    onChange={this.atualizaEstadoTitulo}

                                />

                                {/* <button type="submit" >Cadastrar</button> */}

                                {/* Altera o texto do botão de acordo com a operação ( edição ou cadastro ) 
                                usando if ternário */}

                                {/* Estrutura de um IF Ternário
                                
                                CONDIÇÃO ? Acontece ALGO CASO VERDADE : ACONTECE ALGO CASO FALSO
                                
                                */}

                                {/* {
                                    this.state.idTipoEventoAlterado === 0 ?
                                    <button type="submit" >Cadastrar</button> : 
                                    <button type="submit" >Atualizar</button>
                                } */}

                                {/* Uma outra forma, com IF Ternário e um disabled ao mesmo tempo*/}

                                {
                                    <button type="submit" disabled={this.state.titulo === '' ? 'none' : ''}>
                                        {this.state.idTipoEventoAlterado === 0 ? 'Cadastrar' : 'Atualizar'}
                                    </button>
                                }

                                {/* Faz a chamada da função limparCampos */}
                                <button type="button" onClick={this.limparCampos} style={{ display: 'none' }}>
                                    Cancelar
                                </button>

                                {/* 
                                   Caso algum Tipo de Evento tenha sido selecionado para edição,
                                   exibe uma mensagem de feedback ao usuário
                             */}

                                {
                                    this.state.idTipoEventoAlterado !== 0 &&
                                    <div>
                                        <p>O tipo de evento {this.state.tituloTipoEvento} está sendo editado.</p>
                                        <p>Clique em Cancelar caso queira cancelar a operação antes de Cadastrar
                                            um novo Tipo de Evento
                                        </p>
                                    </div>
                                }


                            </div>
                        </form>
                    </section>
                </main>
            </div>
        )
    }
};