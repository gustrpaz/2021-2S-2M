import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Redirect, Switch } from 'react-router-dom';

import './index.css';

import Home from './pages/Home/Home';
import UsuarioGit from './pages/UsuarioGit/UsuarioGit';
import NotFound from './pages/notFound/NotFound';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} /> {/* Home */}
        <Route path="/usuariogit" component={UsuarioGit} /> {/* usuario git hub */}
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


