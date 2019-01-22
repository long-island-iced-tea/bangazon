import React from 'react';
import './ProductCategories.scss';
import Product from '../Product/Product';

class ProductCategories extends React.Component {

    state = {
        productCats: []
    }

    componentDidMount () {
        this.getProductCategories();
    }

    getProductCategories = () => {
        //dummy data
        const productCats = [
            {
                id: 1,
                name: 'category1',
                products: [
                    {
                        "id": "1",
                        "name" : "product1",
                        "category" : "category1",
                        "price" : "9.99"
                    },
                    {
                        "id": "2",
                        "name" : "product2",
                        "category" : "category1",
                        "price" : "9.99"
                    },
                    {
                        "id": "3",
                        "name" : "product3",
                        "category" : "category1",
                        "price" : "9.99"
                    }
                ]
            },
            {
                id: 2,
                name: 'category2',
                products: [
                    {
                        "id": "1",
                        "name" : "product1",
                        "category" : "category2",
                        "price" : "9.99"
                    },
                    {
                        "id": "2",
                        "name" : "product2",
                        "category" : "category2",
                        "price" : "9.99"
                    },
                    {
                        "id": "3",
                        "name" : "product3",
                        "category" : "category2",
                        "price" : "9.99"
                    }
                ]
            },
            {
                id: 3,
                name: 'category3',
                products: [
                    {
                        "id": "1",
                        "name" : "product1",
                        "category" : "category3",
                        "price" : "9.99"
                    },
                    {
                        "id": "2",
                        "name" : "product2",
                        "category" : "category3",
                        "price" : "9.99"
                    },
                    {
                        "id": "3",
                        "name" : "product3",
                        "category" : "category3",
                        "price" : "9.99"
                    }
                ]
            },
            {
                id: 4,
                name: 'category4',
                products: [
                    {
                        "id": "1",
                        "name" : "product1",
                        "category" : "category4",
                        "price" : "9.99"
                    },
                    {
                        "id": "2",
                        "name" : "product2",
                        "category" : "category4",
                        "price" : "9.99"
                    },
                    {
                        "id": "3",
                        "name" : "product3",
                        "category" : "category4",
                        "price" : "9.99"
                    }
                ]
            },
        ];
        this.setState({productCats});
    }
    render () {
        return (
            <div className="ProductCategories">
                <h2 className="text-center"> Product Categories</h2>
                <div className="container">
                 <div className="row">
                    {
                        this.state.productCats.map(
                            cats=> 
                            <div  className="col-sm category-card">
                                <h2>{cats.name}</h2>
                                <h3>{cats.products.map((product =>{
                                    return (<li>{product.name}</li>)
                                }))}</h3>
                            </div>
                            )
                    }
                </div>
            </div>
            </div>
        );
    }
}

export default ProductCategories;