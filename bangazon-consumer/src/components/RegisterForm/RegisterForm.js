import React from 'react';
import './RegisterForm.scss';

class RegisterForm extends React.Component {

  state = {
    user: {
      email: '',
      password: '',
      firstName: '',
      lastName: ''
    }
  }

  onInputChange = (e) => {
    const { user } = { ...this.state };
    user[e.target.name] = e.target.value;
    this.setState({ user });
  }

  submitRegistration = (e) => {
    e.preventDefault();
    const { user } = this.state;

    // Send user to firebase auth method
    console.log(user);

  }
  render () {
    return (
      <div className='LoginForm'>
        <h2>Sign up for Bangazon!</h2>
        <div className="container">
          <div className="row justify-content-center">
            <form className='card' onSubmit={this.submitRegistration}>
              <div class="form-group">
                <label for="exampleInputEmail1">Email address</label>
                <input type="email" name="email" className="form-control" placeholder="Enter email" value={this.state.user.email} onChange={this.onInputChange} />
              </div>
              <div class="form-group">
                <label for="exampleInputPassword1">Password</label>
                <input type="password" name="password" className="form-control" placeholder="Password" value={this.state.user.password} onChange={this.onInputChange} />
              </div>
              <div className="form-row">
                <div class="form-group col">
                  <label for="exampleInputPassword1">First Name</label>
                  <input type="text" name="firstName" className="form-control" placeholder="John" value={this.state.user.firstName} onChange={this.onInputChange} />
                </div>
                <div class="form-group col">
                  <label for="exampleInputPassword1">Last Name</label>
                  <input type="text" name="lastName" className="form-control" placeholder="Smith" value={this.state.user.lastName} onChange={this.onInputChange} />
                </div>
              </div>
              <button type="submit" className="btn btn-primary">Register</button>
            </form>
          </div>
        </div>
      </div>
    );
  }
};

export default RegisterForm;
