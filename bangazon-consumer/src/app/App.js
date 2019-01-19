import React, { Component } from 'react';
import logo from './logo.svg';
import './App.scss';
import LoginForm from '../components/LoginForm/LoginForm';

class App extends Component {
  render() {
    return (
      <div className="App">
        <LoginForm />
      </div>
    );
  }
}

export default App;
