import React, { Component } from 'react';
import Product from '../Product/Product';
import apiAccess from '../../api-access/api';

import './Search.scss';

class Search extends Component {
  state = {
    products: []
  }

  componentDidMount() {
    this.getProducts(this.props.searchTerm);
  }

  getProducts = (query) => {
    apiAccess.apiGet()
      .then(res => {
        var filteredResults = res.filter(val => {
          return val.data.contains({query})
        })
        this.setState({products: filteredResults});
      });

  }

 render() {
   return (
     <div>
        <h1 className="bangazon text-center">Welcome to Bangazon!</h1>
        <h2 className="title text-center">Newest Products</h2>
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
   )
 }
}

export default Search

























