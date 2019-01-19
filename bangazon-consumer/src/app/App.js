import React, { Component } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import './App.scss';
import LoginForm from '../components/LoginForm/LoginForm';
import RegisterForm from '../components/RegisterForm/RegisterForm';
import ProductLanding from '../components/ProductLanding/ProductLanding';
import * as FIREBASE from 'firebase';
import firebase from '../firebase/index';
import ProductDetails from '../components/ProductDetails/ProductDetails';

firebase.init();

class App extends Component {
  state = {
    auth: false
  }

  componentDidMount() {
    this.authListener = FIREBASE.auth().onAuthStateChanged(user => {
      if (user) {
        // If user is logged in, set token in localStorage
        user.getIdToken().then(token => {
          localStorage.setItem('token', token);
          this.setState({auth: true});
        });
      }
      else {
        this.setState({auth: false});
      }
    });
  }

  componentWillUnmount() {
    this.authListener();
  }

  render() {
    return (
      <div className="App">
        <BrowserRouter>
          <Switch>
            <Route path="/" exact component={ProductLanding} />
            <Route path="/login" component={LoginForm} />
            <Route path="/register" component={RegisterForm} />
            <Route path="/product/:id" render={(props) => <ProductDetails auth={this.state.auth} {...props} />} />
          </Switch>
        </BrowserRouter>
      </div>
    );
  }
}

export default App;
