import React from 'react';
import './Product.scss';

class Product extends React.Component {
  render () {
    const {product} = this.props;
    return (
      <div className='Product card'>
        <div className="price">{product.price}</div>
        <h3 className="name">{product.name}</h3>
        <small className="category">{product.category}</small>
      </div>
    );
  }
};

export default Product;
