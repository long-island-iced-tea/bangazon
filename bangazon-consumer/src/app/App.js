import React, { Component } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import './App.scss';
import ProductLanding from '../components/ProductLanding/ProductLanding';
import firebase from '../firebase/index';

firebase.init();

class App extends Component {
  render() {
    return (
      <div className="App">
        <BrowserRouter>
          <Switch>
            <Route path="/" exact component={ProductLanding} />
          </Switch>
        </BrowserRouter>
      </div>
    );
  }
}

export default App;
