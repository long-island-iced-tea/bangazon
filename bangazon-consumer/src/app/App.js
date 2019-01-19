import React, { Component } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import Navbar from '../components/Navbar/Navbar';
import Footer from '../components/Footer/Footer';
import LoginForm from '../components/LoginForm/LoginForm';
import RegisterForm from '../components/RegisterForm/RegisterForm';
import ProductLanding from '../components/ProductLanding/ProductLanding';
import firebase from '../firebase/index';
import './App.scss';

firebase.init();

class App extends Component {
  render() {
    return (
      <div className="App Site">
      <div className="Site-content">
        <Navbar/>
        <BrowserRouter>
          <Switch>
            <Route path="/" exact component={ProductLanding} />
            <Route path="/login" component={LoginForm} />
            <Route path="/register" component={RegisterForm} />
          </Switch>
        </BrowserRouter>
        </div>
        <Footer/>
      </div>
    );
  }
}

export default App;
