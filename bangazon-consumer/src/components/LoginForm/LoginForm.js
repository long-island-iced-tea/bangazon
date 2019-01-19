import React from 'react';
import './LoginForm.scss';

class LoginForm extends React.Component {
  state = {
    user : {
      email: '',
      password: ''
    }
  }

  render () {
    return (
      <form className='LoginForm'>
        <div class="form-group">
          <label for="exampleInputEmail1">Email address</label>
          <input type="email" name="email" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" />
        </div>
        <div class="form-group">
          <label for="exampleInputPassword1">Password</label>
          <input type="password" name="password" className="form-control" id="exampleInputPassword1" placeholder="Password" />
        </div>
        <button type="submit" className="btn btn-primary">Submit</button>
      </form>
    );
  }
};

export default LoginForm;
