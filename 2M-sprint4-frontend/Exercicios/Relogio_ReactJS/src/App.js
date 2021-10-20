import React from 'react';
import './App.css';

function DataFormatada(props) {
  return <h2>Horário atual: {props.date.toLocaleTimeString()}</h2>
}

class Clock extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      //Definimos o estado date pegando a data atual
      date: new Date()
    }
  }

  //Fora do construtor, definidos os ciclos de vida

  //Ciclo de vida que ocorre quando Clock é inserido na DOM
  componentDidMount() {
    this.timeID = setInterval(() => {
      this.thick()
    }, 1000);
  }

  //Ciclo de vida que ocorre quando clock é removido da DOM
  componentWillUnmount() {
    clearInterval(this.timeID)
  }

  thick() {
    this.setState({
      date: new Date()
    })
  }

  stopThick() {
    clearInterval(this.timeID)
    return console.log(`Horário ${this.timeID} paused`)
  }


  startThick() {
    this.timeID = setInterval(() => {
      this.thick()
    }, 1000)

    return console.log(`Horário ${this.timeID} on`)

  }
  render() {
    return (
      <div>
        <h1>Relógio do Rezendão</h1>
        <DataFormatada date={this.state.date} />
        <div className="Botoes">
          <div>
            <button className="btn_off" onClick={() => this.stopThick()}>Pause</button>
          </div>
          <div>
            <button className="btn_on" onClick={() => this.startThick()}>On</button>
          </div>
        </div>
      </div>
    )
  }
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        {/* Faz a chamada de dois relogios para mostrar a independencia destes */}
        <Clock />
      </header>
    </div>
  );
}

export default App;
