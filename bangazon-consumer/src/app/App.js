import React, { Component } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import './App.scss';

class App extends Component {
  render() {
    return (
      <div className="App">
        <BrowserRouter>
          <Switch>
            <Route path="/" exact render={(p) => <h1>Product Landing</h1>} />
          </Switch>
        </BrowserRouter>
      </div>
    );
  }
}

export default App;
