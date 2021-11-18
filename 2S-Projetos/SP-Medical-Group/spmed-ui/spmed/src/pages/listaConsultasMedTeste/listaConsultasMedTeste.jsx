import { useEffect, useState } from "react"
import '../../assets/css/listaConsultaMed.css'
import Header from "../../components/header/header"
import Footer from "../../components/footer/footer"
import axios from "axios"

export default function Medico() {
    const [listaConsultas, setListaConsultas] = useState([])
    const [idConsultaAlterada, setIdConsultaAlterada] = useState(0)
    const [novaDescricao, setNovaDescricao] = useState('')

    function consultasMedico() {
        axios.get('http://localhost:5000/api/consultas/minhasMed', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

            .then(response => {
                if (response.status === 200) {
                    setListaConsultas(response.data)
                }
            })
            .catch(erro => console.log(erro))
    }

    function alterarDescricao(event) {
        event.preventDefault();
        axios.patch('http://localhost:5000/api/consultas/AlterarDescricao/' + idConsultaAlterada, {
            Descricao : novaDescricao
        },{
            headers : {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(response => {
            if (response.status === 200) {
                console.log('Descrição alterada')
            }
        })
        .catch(erro => console.log(erro))
        consultasMedico();
        
    }
    useEffect(consultasMedico, [])

    return (
        <div>
            <Header></Header>
            <main className='conteudoPrincipal'>
                <h2 className="conteudoPrincipal-cadastro-titulo">Consultas</h2>
                <div className="container" id="conteudoPrincipal-lista">
                    <table id="tabela-lista">
                        <thead>
                            <tr>
                                <th>Descrição</th>
                                <th>Paciente</th>
                                <th>Médico</th>
                                <th>Data</th>
                                <th>Instituição</th>
                            </tr>
                        </thead>

                        <tbody id="tabela-lista-corpo">
                            {

                                listaConsultas.map((event) => {
                                    return (

                                        <tr key={event.idConsulta}>
                                            <td>{event.descricao}</td>
                                            {/* <td>{event.idPacienteNavigation.idUsuarioNavigation.nomeUsuario}</td>
                                            <td>{event.idMedicoNavigation.idUsuarioNavigation.nomeUsuario}</td> */}
                                            {/* <td>
                                                {Intl.DateTimeFormat("pt-BR", {
                                                    year: 'numeric', month: 'short', day: 'numeric'
                                                }).format(new Date(event.dataConsulta))}
                                            </td>
                                            <td>{event.idMedicoNavigation.idInstituicaoNavigation.nomeFantasia}</td> */}
                                        </tr>
                                    )
                                })
                            }
                        </tbody>
                    </table>
                </div>
                <section className="conteudoPrincipal-cadastro">


                    <section className="container" id="conteudoPrincipal-cadastro">
                        <h2 className="conteudoPrincipal-cadastro-titulo">
                            Atualizar Descrição da consulta
                        </h2>
                        <form onSubmit={alterarDescricao}>
                            <div className="container">
                                
                                <select name="paciente" id="" onChange={(evt) => setIdConsultaAlterada(evt.target.value)}>
                                    <option value="#">Escolha um consulta</option>
                                    {
                                        listaConsultas.map((event) => {

                                            return (

                                                <option key={event.idConsulta} value={event.idConsulta}>{event.idPacienteNavigation.idUsuarioNavigation.nomeUsuario + ', ' + Intl.DateTimeFormat("pt-BR", {
                                                    year: 'numeric', month: 'short', day: 'numeric'
                                                }).format(new Date(event.dataConsulta)) }</option>
                                            )
                                        })
                                    }
                                </select>
                                <input type="text" name="" id="" placeholder="Insira a nova descrição" onChange={(evt) => setNovaDescricao(evt.target.value)}/>
                                <button
                                    type="submit"
                                    className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro"
                                >
                                    Atualizar
                                </button>
                            </div>
                        </form>
                    </section>
                </section>

            </main>
            <Footer></Footer>
        </div>
    )
}