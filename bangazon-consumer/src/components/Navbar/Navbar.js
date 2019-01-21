import React from 'react';
import {Link} from 'react-router-dom';
import './Navbar.scss';
import fb from '../../firebase/index';

class Navbar extends React.Component {

    signOut = (e) => {
        e.preventDefault();
        fb.auth.logoutUser();
        this.props.logOff();
    }

    render () {
        return (
            <div>
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                <Link to="/" className="navbar-brand">Bangazon</Link>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                    <li className="nav-item active">
                        <Link to="/products" className="nav-link">All Products <span class="sr-only">(current)</span></Link>
                    </li>
                    <li className="nav-item active">
                        <Link to="/products/categories" className="nav-link">Product Categories <span class="sr-only">(current)</span></Link>
                    </li>
                    </ul>
                    <form className="form-inline my-2 my-lg-0">
                    <input className="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search"/>
                    {
                        this.props.auth ? (
                            <div>
                                <Link to="/cart" className="btn btn-outline-success my-2 my-sm-0">Cart</Link>
                                <button className="btn btn-outline-success my-2 my-sm-0" onClick={this.signOut}>Logout</button>
                            </div>
                        ) : (
                            <Link className="btn btn-outline-success my-2 my-sm-0" to="/login">Login</Link>
                        )
                    }
                    </form>
                </div>
                </nav>
            </div>
        );
    }
}
export default Navbar;