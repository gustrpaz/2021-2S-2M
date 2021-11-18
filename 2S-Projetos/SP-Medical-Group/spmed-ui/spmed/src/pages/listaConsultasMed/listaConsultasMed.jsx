import { useEffect, useState } from "react"
import '../../assets/css/listaConsultaMed.css'
import Header from "../../components/header/header"
import Footer from "../../components/footer/footer"
import background_section from '../../assets/img/background section.png'
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
        console.log('console log do saulo')
        axios.patch('http://localhost:5000/api/consultas/AlterarDescricao/' + idConsultaAlterada, {
            Descricao: novaDescricao
        }, {
            headers: {
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

                        <div className="bodyConsultasMed" id="">
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

                                <tbody id="">
                                    {

                                        listaConsultas.map((event) => {
                                            return (

                                                <tr key={event.idConsulta}>
                                                    <td>{event.descricao}</td>
                                                    <td>{event.idPacienteNavigation.nome}</td>
                                                    <td>{event.idMedicoNavigation.nomeMedico}</td>
                                                    <td>
                                                        {Intl.DateTimeFormat("pt-BR", {
                                                            year: 'numeric', month: 'short', day: 'numeric'
                                                        }).format(new Date(event.dataHora))}
                                                    </td>
                                                    <td>{event.idMedicoNavigation.idClinicaNavigation.nomeClinica}</td>
                                                </tr>
                                            )
                                        })
                                    }
                                </tbody>
                            </table>
                        </div>
                        <section className="conteudoPrincipal-cadastro">


                            <section className="" id="conteudoPrincipal-cadastro">
                                <h2 className="conteudoPrincipal-cadastro-titulo">
                                    Atualizar Descrição da consulta
                                </h2>
                                <form onSubmit={alterarDescricao}>
                                    <div className="box_editarDesc">

                                        <select name="paciente" id="" onChange={(evt) => setIdConsultaAlterada(evt.target.value)}>
                                            <option value="#">Escolha uma consulta</option>
                                            {
                                                listaConsultas.map((event) => {

                                                    return (

                                                        <option key={event.idConsulta} value={event.idConsulta}>{event.idPacienteNavigation.nome + ', ' + Intl.DateTimeFormat("pt-BR", {
                                                            year: 'numeric', month: 'short', day: 'numeric'
                                                        }).format(new Date(event.dataHora))}</option>
                                                    )
                                                })
                                            }
                                        </select>
                                        <input type="text" name="" id="" placeholder="Insira a nova descrição" onChange={(evt) => setNovaDescricao(evt.target.value)} />
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
                    </div>
                </section>
            </main>
            <Footer></Footer>
        </div>
    )
}