import React from 'react';
import './ProductDetails.scss';
import api from '../../api-access/api';

class ProductDetails extends React.Component {

  state = {
    product: {
      name: '',
      category: '',
      price: 0,
      description: ''
    },
    isAdded: false,
  }

  componentDidMount() {
    const id = this.props.match.params.id;
    api.apiGet('consumer/products/' + id)
      .then(product => {
        product = product.data;
        this.setState({product})
      });
  }
  addToCart = (e) => {
    const {product} = this.state;
    const {addToCart} = this.props;
    addToCart(product);
    this.showSuccess();
  }

  showSuccess = () => {
    const state = {...this.state};
    state.isAdded = true;
    this.setState(state, () => {
      setTimeout(() => {
        state.isAdded = false;
        this.setState(state);
      }, 2000);
    });
  }

  render () {
    const {product} = this.state;
    const {auth} = this.props;
    return (
      <div className='ProductDetails'>
        <div className="container">
          <h2 className="title">{product.name}</h2>
          <div className="category">
            <h4>{product.category}</h4>
          </div>
          <div className="desc card">
            <p>{product.description}</p>
          </div>
          {
            this.state.isAdded ? ( <div className="alert alert-success">{product.name} added to cart.</div> ) : null
          }
          <div className="product-footer">
            <div className="price">{product.price}</div>
            {
              auth ? (
                <button className="btn btn-primary" onClick={() => this.addToCart(product)}><i className="fas fa-cart-plus"></i></button>
              ) : null
            }
          </div>
        </div>
      </div>
    );
  }
};

export default ProductDetails;
