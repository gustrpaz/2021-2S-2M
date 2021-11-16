import React from 'react';
import ReactDOM from 'react-dom';
// import App from './App';
import reportWebVitals from './reportWebVitals';

import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';

import Home from './pages/home/Home';
import Login from './pages/login/login'
import ListaConsulta from './pages/listaConsulta_Adm/ListaConsulta'
import CadastroConsulta from './pages/cadastroConsulta/cadastroConsulta';
import NotFound from './pages/notFound/notFound'

import './index.css';
import ListaConsultaMed from './pages/listaConsultas_Med/listaConsultas_med.jsx';
import ListaConsultaPac from './pages/listaConsultas_Pac/listaConsultas_pac.jsx';
import Especialidade from './pages/especialidades/especialidades';
// ReactDOM.render(
//   <React.StrictMode>
//    <Login />
//     {/* <Home /> */}
//   </React.StrictMode>,
//   document.getElementById('root')
// );

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} /> {/* Home */}
        <Route path="/login" component={Login} /> {/* Login */}
        <Route path="/especialidade" component={Especialidade} /> {/* Especialidade */}
        <Route path="/listaConsulta" component={ListaConsulta} />  {/* Listar Consulta */}
        <Route path="/listaConsultaMed" component={ListaConsultaMed} /> {/* Listar Consultas médico */}
        <Route path="/listaConsultaPac" component={ListaConsultaPac} /> {/* Listar Consultas paciente */}
        <Route path="/cadastroConsulta" component={CadastroConsulta} /> {/* Cadastrar consulta */}
        <Route path="/notFound" component={NotFound} /> {/* Not Found */}
        <Redirect to="/notFound" /> {/* Redireciona para Not Found caso não encontre nenhuma rota */}
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
