import React from 'react';
import CartItem from '../CartItem/CartItem';
import './CartPage.scss';

class CartPage extends React.Component {
  render () {
    const {cart} = this.props;
    return (
      <div className='CartPage'>
        <h2 className="text-center">My Cart</h2>
        <div className="cart card">
          <div className="card-header">
            <div className="row">
              <div className="col">Product</div>
              <div className="col">Price</div>
              <div className="col">Quantity</div>
            </div>
          </div>
          {
            cart.map(product => <CartItem product={product} />)
          }
        </div>
      </div>
    );
  }
};

export default CartPage;
