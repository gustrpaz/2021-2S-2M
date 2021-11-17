import { React, Component } from 'react';
//import { Link } from 'react-router-dom';

import Footer from '../../components/footer/footer'
import Header from '../../components/header/header'


export default class Descricao extends Component{
    constructor(props){
        super(props);
        this.state = {
            idConsultaAlterada : 0,
            descricaoAtualizada : ''
        }
    }

    //Busca a consulta pelo ID da mesma e atualiza os states
    buscarConsultaPorId = () => {

        this.setState({ idConsulta : localStorage.getItem('descricao').idConsultaAlterada,
                        descricao : localStorage.getItem('descricao').descricaoAtualizada })
    }

    atualizarDescricao = (x) => {

        x.preventDefault();

        fetch('http://localhost:5000/api/consultas/'+this.state.idConsultaAlterada+'/descricao', {
            
            //Define o método da requisição
            method: 'PATCH',

            //Define o corpo da requisição convertendo um objeto JS em JSON
            body: JSON.stringify({ descricao : this.state.descricaoAtualizada }),

            //Define o cabeçalho da requisição
            headers : {
                "Content-type" : "application/json",
                'Authorization' : 'Bearer ' + localStorage.getItem('login')
            }
        })

        //Define que a resposta da requisição será em JSON
        .then(resposta => resposta.json())

        //Atualiza o state listaConsultas com os dados obtidos
        .then(dados => this.setState({ listaConsultas : dados }))

        //Caso acorra algum erro, mostra ele no console do navegador
        .catch((erro) => console.log(erro))

        console.log(this.state.listaConsultas)

        .then(this.buscarConsultas)
    }

    //Função genérica que atualiza o state de acordo com o input, pode ser ultilizada em vários inputs diferentes
    atualizaState = (x) => {
        this.setState({ [x.target.name] : x.target.value })
    }

    render()
    {
        return(
            <div className=''>

                <Header />

                <main className=''>
                    <div className="">
                        <div className="">
                            <h2>Nova Consulta</h2>
                            <div className="">
                                <form className="" onSubmit={this.atualizarDescricao}>
                                    <div className="">
                                        <p>Nova descrição</p>
                                        <input 
                                            type="text"
                                            name="descricaoAtualizada"
                                            //Define que o input senha vai receber o valor do state senha
                                            value={this.state.descricaoAtualizada}
                                            //Chama a função que atualiza o state
                                            onChange={this.atualizaState} />
                                    </div>
                                    <button type='submit'>Atualizar</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </main>

                <Footer />

            </div>
        )
    }
}