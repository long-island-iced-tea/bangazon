import React from 'react';
import './CartItem.scss';

class CartItem extends React.Component {
  render () {
    const {product} = this.props;
    return (
      <div className='CartItem'>
        <div className="row">
          <div className="name col">{product.name}</div>
          <div className="price col">{product.price}</div>
          <div className="quantity col">{product.quantity}</div>
        </div>
      </div>
    );
  }
};

export default CartItem;