import React, { Component } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import Navbar from '../components/Navbar/Navbar';
import Footer from '../components/Footer/Footer';
import LoginForm from '../components/LoginForm/LoginForm';
import RegisterForm from '../components/RegisterForm/RegisterForm';
import ProductLanding from '../components/ProductLanding/ProductLanding';
import * as FIREBASE from 'firebase';
import firebase from '../firebase/index';
import './App.scss';
import ProductDetails from '../components/ProductDetails/ProductDetails';
import CartPage from '../components/CartPage/CartPage';


firebase.init();

class App extends Component {

  state = {
    auth: false,
    user: {},
    cart: []
  }

  addToCart = (product) => {
    const { cart } = { ...this.state };
    // Try to find item in cart
    const itemInCart = cart.find(p => p.id === product.id) || null;
    // If item is already in cart, increment the quantity
    // Else, push to cart
    if (itemInCart !== null) {
      itemInCart.quantity++;
    }
    else {
      cart.push(product);
    }
    // Update state, then update localStorage
    this.setState({ cart, auth: this.state.auth }, this.updateCartStorage)
  }

  removeFromCart = (productId) => {
    let { cart } = { ...this.state };
    cart = cart.filter(p => p.id !== productId);
    this.setState({ cart }, this.updateCartStorage);

  }

  updateQuantity = (product) => {
    const { cart } = { ...this.state };
    const itemToUpdate = cart.find(p => p.id === product.id);
    itemToUpdate.quantity = product.quantity;
    this.setState({ cart }, this.updateCartStorage);
  }

  updateCartStorage = () => {
    const { cart } = this.state;
    localStorage.setItem('cart', JSON.stringify(cart));
  }

  loadCart = () => {
    const cart = localStorage.getItem('cart');
    if (cart !== null) {
      this.setState({ cart: JSON.parse(cart) });
    }
  }

  componentDidMount() {
    this.authListener = FIREBASE.auth().onAuthStateChanged(user => {
      if (user) {
        // If user is logged in, set token in localStorage
        localStorage.setItem('uid', user.uid);
        user.getIdToken().then(token => {
          localStorage.setItem('token', token);
          this.setState({ auth: true });
        });
      }
      else {
        this.setState({ auth: false });
        localStorage.removeItem('token');
        localStorage.removeItem('uid');
      }
    });

    // Load cart from localStorage
    this.loadCart();
  }

  componentWillUnmount() {
    this.authListener();
  }

  signOut = () => this.setState({ auth: false, user: null });

  signIn = (user) => this.setState({ auth: true, user: user });

  render() {
    return (
      <div className="App Site">
        <div className="Site-content">
          <BrowserRouter>
            <div>
              <Navbar auth={this.state.auth} logOff={this.signOut} cart={this.state.cart} />
              <Switch>
                <Route path="/" exact component={ProductLanding} />
                <Route path="/login" render={(props) => <LoginForm {...props} signin={this.signIn} />} />
                <Route path="/register" render={(props) => <RegisterForm {...props} signin={this.signIn} />} />
                <Route path="/product/:id" render={(props) => <ProductDetails auth={this.state.auth} addToCart={this.addToCart} {...props} />} />
                <Route path="/cart" render={(props) => <CartPage cart={this.state.cart} removeFromCart={this.removeFromCart} updateQuantity={this.updateQuantity} {...props} />} />
              </Switch>
            </div>
          </BrowserRouter>
        </div>
        <Footer />
      </div>
    );
  }
}

export default App;
