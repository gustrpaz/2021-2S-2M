import './index.css';
import React from 'react';
import ReactDOM from 'react-dom';
import reportWebVitals from './reportWebVitals';
import { parseJwt, usuarioAutenticado } from "../src/services/auth"

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

import ListaConsultaPac from './pages/listaConsultas_Pac/listaConsultas_pac.jsx';
import Especialidade from './pages/especialidades/especialidades';
import Medico from './pages/listaConsultasMed/listaConsultasMed';


const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const PermissaoMedico = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '2' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const PermissaoPaciente = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '3' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);


const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} /> {/* Home */}
        <Route path="/login" component={Login} /> {/* Login */}
        <Route path="/especialidade" component={Especialidade} /> {/* Especialidade */}
        <PermissaoAdm path="/listaConsulta" component={ListaConsulta} />  {/* Listar Consulta */}
        <PermissaoMedico path="/listaConsultasMed" component={Medico} /> {/* Listar Consultas Médicos */}
        <PermissaoPaciente path="/listaConsultaPac" component={ListaConsultaPac} /> {/* Listar Consultas paciente */}
        <PermissaoAdm path="/cadastroConsulta" component={CadastroConsulta} /> {/* Cadastrar consulta */}
        <Redirect to="/notFound" /> {/* Redireciona para Not Found caso não encontre nenhuma rota */}
        <Route path="/notFound" component={NotFound} /> {/* Not Found */}
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
