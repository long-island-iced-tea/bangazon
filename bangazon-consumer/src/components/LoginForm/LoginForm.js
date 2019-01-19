import React from 'react';
import { Link } from 'react-router-dom';
import './LoginForm.scss';

class LoginForm extends React.Component {

  state = {
    user: {
      email: '',
      password: ''
    }
  }

  onInputChange = (e) => {
    const { user } = { ...this.state };
    user[e.target.id] = e.target.value;
    this.setState({ user });
  }

  submitLogin = (e) => {
    e.preventDefault();
    const { user } = this.state;

    // Send user to firebase auth method
    console.log(user);

  }

  render() {
    return (
      <div className='LoginForm'>
        <h2>Login to Bangazon!</h2>
        <div className="container">
          <div className="row justify-content-center">
            <form className='card' onSubmit={this.submitLogin}>
              <div class="form-group">
                <label for="email">Email address</label>
                <input type="email" id="email" className="form-control" placeholder="Enter email" value={this.state.user.email} onChange={this.onInputChange} />
              </div>
              <div class="form-group">
                <label for="password">Password</label>
                <input type="password" id="password" className="form-control" placeholder="Password" value={this.state.user.password} onChange={this.onInputChange} />
              </div>
              <button type="submit" className="btn btn-primary">Login</button>
              <small><Link to="/register">Don't have an account?</Link></small>
            </form>
          </div>
        </div>
      </div>
    );
  }
};

export default LoginForm;
