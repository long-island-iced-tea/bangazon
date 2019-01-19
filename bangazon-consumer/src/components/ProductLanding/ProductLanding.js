import React from 'react';
import './ProductLanding.scss';
import Product from '../Product/Product';

class ProductLanding extends React.Component {

  state = {
    products: []
  }

  componentDidMount() {
    this.getNewestProducts();
  }

  getNewestProducts = () => {
    apiAccess.apiGet('product')
      .then(res => {
        this.setState({products: res.data});
      });
  }

  render () {
    return (
      <div className='ProductLanding'>
        <h1 className="bangazon">Welcome to Bangazon!</h1>
        <h2 className="title">Newest Products</h2>
        <div className="container">
          <div className="row">
            {
              this.state.products.map(prod => (
                <div className="col-4">
                  <Product product={prod} />
                </div>
              ))
            }
          </div>
        </div>
      </div>
    );
  }
};

export default ProductLanding;
