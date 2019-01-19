import React from 'react';
import {Link} from 'react-router-dom';
import './Product.scss';

class Product extends React.Component {
  render () {
    const {product} = this.props;
    return (
      <div className='Product card' onClick={this.showDetails}>
        <div className="price">{product.price}</div>
        <Link to={'product/' + product.id}>
          <h3 className="name">{product.name}</h3>
        </Link>
        <small className="category">{product.category}</small>
      </div>
    );
  }
};

export default Product;
