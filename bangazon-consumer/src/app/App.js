import React, { Component } from 'react';
// import Browserouter from 'react-router-dom';
import Navbar from '../components/Navbar/Navbar';
import './App.scss';

class App extends Component {
  render() {
    return (
      <div>
        <Navbar/>
        {/* <Browserouter/> */}
      </div>
    );
  }
}

export default App;
