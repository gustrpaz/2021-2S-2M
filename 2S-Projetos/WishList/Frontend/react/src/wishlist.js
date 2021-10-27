import { Component } from "react";
import "./style.css";


export default class Wishlist extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaDesejos: [],
            idUsuario: 0,
            idDesejo: 0,
            tituloDesejo: "",
            descricaoDesejo: ""
        }
    };

    limparCampos = () => {
        this.setState({
            idUsuario: 0,
            idDesejo: 0,
            tituloDesejo: "",
            descricaoDesejo: ""
        })
        console.log('Os states foram resetados!')
    };

    buscarDesejos = () => {
        console.log("Vamos fazer a chamada para a API")

        // //talvez mudar a rota, a confirmar
        fetch("http://localhost:5000/api/Desejos")

            .then(resposta => resposta.json())

            .then(dados => this.setState({ listaDesejos : dados }))

            .catch(erro => console.log(erro))
    }

    //onChange vai disparar por tecla e invocar essa funcao.
    atualizaEstadoUsuario = async (event) => {
        //console.log('acionou essa funcao')

        await this.setState({
            //dizendo que o target (alvo) do evento ,  vamos pegar o value(valor) 
            idUsuario: event.target.value,
        });

    };
    atualizaEstadoTitulo = async (event) => {
        //console.log('acionou essa funcao')

        await this.setState({
            //dizendo que o target (alvo) do evento ,  vamos pegar o value(valor) 
            tituloDesejo: event.target.value,
        });

    };
    atualizaEstadoDescricao = async (event) => {
        //console.log('acionou essa funcao')

        await this.setState({
            //dizendo que o target (alvo) do evento ,  vamos pegar o value(valor) 
            descricaoDesejo: event.target.value,
        });

    };

    cadastrarDesejo = (submit_formulario) => {
        submit_formulario.preventDefault();

        fetch('http://localhost:5000/api/Desejos', {
            method: 'POST',
            body: JSON.stringify({
                IdUsuario: this.state.idUsuario,
                titulo: this.state.tituloDesejo,
                descricao: this.state.descricaoDesejo
            }),
            headers: {
                "Content-Type": "application/json"
            }
        })

            .then(console.log("Desejo cadastrado"))
            .catch(erro => console.log(erro))
            .then(this.buscarDesejos)
            .then(this.limparCampos)
    }

    componentDidMount() {
        this.buscarDesejos()
    }

    render() {
        return (
            <div>
                <header>
                    <div className="header">
                        <h1>WishList</h1>
                    </div>
                </header>

                <main>
                    <div className="fundoDiv">
                        <div className="cadastrarDesejos">
                            <form onSubmit={this.cadastrarDesejo} className="questionario">
                                <label className="textoForm">Seu Id</label>
                                <input value={this.state.idUsuario} onChange={this.atualizaEstadoUsuario} className="idUsuario" type="text" name="Usuario" placeholder="Digite Seu Id" />
                                <label className="textoForm">Desejo</label>
                                <input value={this.state.tituloDesejo} onChange={this.atualizaEstadoTitulo} className="nomeDesejo" type="text" name="Desejo" placeholder="Digite Seu Desejo" />
                                <label className="textoForm">Descrição do Desejo</label>
                                <textarea value={this.state.descricaoDesejo} onChange={this.atualizaEstadoDescricao} className="descDesejo" placeholder="Descreva Seu Desejo..."></textarea>
                                <button type="submit" className="botao">Enviar</button>
                            </form>
                        </div>
                    </div>
                    <div className="mostrarDesejos">
                        <h2>DESEJOS</h2>
                        {
                            this.state.listaDesejos.map((desejo) => {
                                return (
                                    <div key={desejo.idDesejo}>
                                        <div className="caixaDesejo" >
                                            <div className="inputDiv">
                                                <p>{desejo.titulo}</p>
                                                <input type="checkbox" className="check" />
                                            </div>
                                            <p className="descCaixa" >
                                                {desejo.descricao}
                                            </p>
                                        </div>
                                    </div>
                                )
                            })
                        }
                        
                    </div>
                </main>
            </div>
        )
    }
}
