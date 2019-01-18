import React from 'react';
import './ProductLanding.scss';

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
        name: 'Super cool product',
        category: 'Cat1',
        price: 2.99,
      },
      {
        name: 'Another awesome product',
        category: 'Category1',
        price: 9.99,
      },
      {
        name: 'Yet another product',
        category: 'categoryyyyy',
        price: 0.83
      }
    ];

    this.setState({products})
  }

  render () {
    return (
      <div className='ProductLanding'>
        <h2>Newest Products</h2>
        <div className="container">
          <div className="row">
            {
              this.state.products.map(prod => <h3>{prod.name}</h3>)
            }
          </div>
        </div>
      </div>
    );
  }
};

export default ProductLanding;
