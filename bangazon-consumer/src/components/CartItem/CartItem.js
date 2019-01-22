import React from 'react';
import './CartItem.scss';

class CartItem extends React.Component {

  updateQuantity = (e) => {
    const {product, updateQuantity} = this.props;
    e.preventDefault();
    product.quantity = e.target.value * 1;
    if (product.quantity > 0) {
      updateQuantity(product);
    }
  }
  removeItem = (e) => {
    const {product, removeFromCart} = this.props;
    e.preventDefault();
    removeFromCart(product.id);
  }

  render () {
    const {product} = this.props;
    return (
      <div className='CartItem'>
        <div className="row">
          <div className="name col">{product.name}</div>
          <div className="price col">{product.price}</div>
          <div className="quantity col">
            <input className="form-control" type="number" name="quantity" value={product.quantity} onChange={this.updateQuantity}/>
          </div>
          <button className="close" onClick={this.removeItem}><i className="fas fa-trash-alt"></i></button>
        </div>
      </div>
    );
  }
};

export default CartItem;
