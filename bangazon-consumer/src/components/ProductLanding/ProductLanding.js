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
    // provides dummy data, will replace with api call
    const products = [
      {
        id: 1,
        name: 'Super cool product',
        category: 'Cat1',
        price: 2.99,
      },
      {
        id: 2,
        name: 'Another awesome product',
        category: 'Category1',
        price: 9.99,
      },
      {
        id: 3,
        name: 'Yet another product',
        category: 'categoryyyyy',
        price: 0.83
      },
      {
        id: 4,
        name: 'Wowza',
        category: 'cattt',
        price: 0.99,
      },
      {
        id: 5,
        name: 'Long-named Product for your purchasing requirements',
        category: 'Category1',
        price: 4.99,
      },
      {
        id: 6,
        name: 'Yet another product',
        category: 'categoryyyyy',
        price: 2.01
      }
    ];

    this.setState({products})
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
