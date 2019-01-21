import React from 'react';
import CartItem from '../CartItem/CartItem';
import './CartPage.scss';

class CartPage extends React.Component {
  calculateTotal = () => {
    const {cart} = this.props;
    const cartTotal = cart.reduce((total, product) => {
      return total + product.price;
    }, 0);

    return cartTotal.toFixed(2);
  }
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
          <div className="card-body">
            {
              cart.map(product => <CartItem product={product} />)
            }
            <div className="row">
              <div className="col-8"></div>
              <div className="col-4">
                <h3>Total: ${this.calculateTotal()}</h3>
              </div>
            </div>
          </div>
        </div>
        <h2 className="text-center">Choose a payment type</h2>
        {/* Payment type selector should go here */}
      </div>
    );
  }
};

export default CartPage;
