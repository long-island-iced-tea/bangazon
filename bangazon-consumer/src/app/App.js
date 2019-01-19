import React, { Component } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import './App.scss';
import LoginForm from '../components/LoginForm/LoginForm';
import RegisterForm from '../components/RegisterForm/RegisterForm';
import ProductLanding from '../components/ProductLanding/ProductLanding';
import firebase from '../firebase/index';
import ProductDetails from '../components/ProductDetails/ProductDetails';

firebase.init();

class App extends Component {
  render() {
    return (
      <div className="App">
        <BrowserRouter>
          <Switch>
            <Route path="/" exact component={ProductLanding} />
            <Route path="/login" component={LoginForm} />
            <Route path="/register" component={RegisterForm} />
            <Route path="/product/:id" component={ProductDetails} />
          </Switch>
        </BrowserRouter>
      </div>
    );
  }
}

export default App;
