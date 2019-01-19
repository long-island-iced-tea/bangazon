import React, { Component } from 'react';
import logo from './logo.svg';
import './App.scss';
import LoginForm from '../components/LoginForm/LoginForm';
import RegisterForm from '../components/RegisterForm/RegisterForm';

class App extends Component {
  render() {
    return (
      <div className="App">
        <LoginForm />
        <RegisterForm />
      </div>
    );
  }
}

export default App;
