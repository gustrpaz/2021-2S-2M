import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Redirect, Switch } from 'react-router-dom';

import './index.css';

import Home from './pages/home/Home';
import TiposEventos from './pages/tiposEventos/TiposEventos';
import NotFound from './pages/notFound/NotFound';

import reportWebVitals from './reportWebVitals';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} /> {/* Home */}
        <Route path="/tiposEventos" component={TiposEventos} /> {/* Tipos Eventos */}
        <Route path="/notFound" component={NotFound} /> {/* Not found*/}
        <Redirect to="/notFound" /> {/* Redireciona para notFound caso não encontre nenhuma rota */}
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
