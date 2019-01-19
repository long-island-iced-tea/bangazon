import React from 'react';
import './LoginForm.scss';

class LoginForm extends React.Component {
  state = {
    user : {
      email: '',
      password: ''
    }
  }
  onInputChange = (e) => {
    const {user} = {...this.state};
    user[e.target.name] = e.target.value;
    this.setState({user});
  }
  render () {
    return (
      <form className='LoginForm'>
        <div class="form-group">
          <label for="exampleInputEmail1">Email address</label>
          <input type="email" name="email" className="form-control" placeholder="Enter email" value={this.state.user.email} onChange={this.onInputChange} />
        </div>
        <div class="form-group">
          <label for="exampleInputPassword1">Password</label>
          <input type="password" name="password" className="form-control" placeholder="Password" value={this.state.user.password} onChange={this.onInputChange} />
        </div>
        <button type="submit" className="btn btn-primary">Submit</button>
      </form>
    );
  }
};

export default LoginForm;
