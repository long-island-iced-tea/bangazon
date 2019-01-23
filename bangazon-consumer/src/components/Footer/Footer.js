import React from 'react';
import './Footer.scss';

class Footer extends React.Component {
    render () {
        return (
            <div>
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                <h5> &copy; Bangazon | 2019</h5>
                </div>
                </nav>
            </div>
        );
    }
}
export default Footer;