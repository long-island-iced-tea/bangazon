import React from 'react';
import './ProductDetails.scss';

class ProductDetails extends React.Component {

  state = {
    product: {
      name: 'Product Name',
      category: 'category name',
      price: 0.99,
      description: 'this is a description of the product.  it is a long description at that. with a lot of details and such.  weeeeeee'
    }
  }

  componentDidMount() {
    const id = this.props.match.params.id;
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
          <div className="desc">
            <p>{product.description}</p>
          </div>
          <div className="product-footer">
            <div className="price">{product.price}</div>
            {
              auth ? (
                <button className="btn btn-primary">Add to Cart</button>
              ) : null
            }
          </div>
        </div>
      </div>
    );
  }
};

export default ProductDetails;
