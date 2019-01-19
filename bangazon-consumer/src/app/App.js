import React, { Component } from 'react';
import Navbar from '../components/Navbar/Navbar';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import LoginForm from '../components/LoginForm/LoginForm';
import RegisterForm from '../components/RegisterForm/RegisterForm';
import ProductLanding from '../components/ProductLanding/ProductLanding';
import firebase from '../firebase/index';
import './App.scss';

firebase.init();

class App extends Component {
  render() {
    return (
      <div className="App">
        <Navbar/>
        <BrowserRouter>
          <Switch>
            <Route path="/" exact component={ProductLanding} />
            <Route path="/login" component={LoginForm} />
            <Route path="/register" component={RegisterForm} />
          </Switch>
        </BrowserRouter>
        <Footer/>
      </div>
    );
  }
}

export default App;
