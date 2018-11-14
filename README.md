# Bangazon Inc.

## Description
A backend service for a platform for customers to buy and sell products.
Includes employee and company data.

## Resources

### Customer
#### GET
- `api/customers`
  - Returns a list of every customer in the database
- `api/customers?id=5`
  - Returns a single customers information by id
- `api/customers?include=products`
  - Returns all customers with their products
- `api/customers?include=payments`
  - Returns all customers with their payments
- `api/customers?q=search`
  - Returns customers whose name properties matches the search term
#### POST
- `api/customers`
  - Adds a new customer to the database
  - Returns 200 if successful
  - Takes a body of
  ```json
  {
    "firstName": "string",
    "lastName": "name"
  }
  ```
#### PUT
- `api/customers`
  - Updates the user provided in the body
  - Returns 200 if successful
  - Takes a body of
  ```json
  {
    "id": 1,
    "firstName": "Jim",
    "lastName": "James",
    "isActive": true
  }
  ```

### Product
#### GET
- `api/product`
  - Reads all products from database
- `api/product/{id}`
  - Reads single product by id
#### POST
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### PUT
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### DELETE
- `api/product/{id}`
  - Deletes Product By Id

### PaymentType
#### GET ALL PAYMENT TYPES
- `api/PaymentType`
  - Returns all payment types (id, customer id, account number, type)
#### GET SINGLE PAYMENT TYPES
- `api/PaymentType/id`
  - Returns payment type by  the payment type id
#### POST
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### PUT
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### DELETE
- `api/PaymentType/id`
  - Payment Type will delete by payment type ID

### Order
#### GET
- `api/orders`
  - Returns all orders in the database.
- `api/orders/{id}`
  - Returns the matching single order, or a `BadRequest` response if not found.
#### POST
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### PUT
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### DELETE
- `api/controller`
  - description and details
- `api/controller`
  - description and details

### ProductType
#### GET
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### POST
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### PUT
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### DELETE
- `api/controller`
  - description and details
- `api/controller`
  - description and details

### Employee
#### GET
- `api/Employee`
  - All Employees returned
- `api/Employee/id`
  - Single Employee is returned
#### POST
- `api/Employee`
  - description and details
#### PUT
- `api/Employee`
  - description and details
#### DELETE
- `api/Employee/id`
  - description and details

### Department
#### GET
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### POST
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### PUT
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### DELETE
- `api/controller`
  - description and details
- `api/controller`
  - description and details

### Computer
#### GET
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### POST
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### PUT
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### DELETE
- `api/controller`
  - description and details
- `api/controller`
  - description and details

### TrainingProgram
#### GET
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### POST
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### PUT
- `api/controller`
  - description and details
- `api/controller`
  - description and details
#### DELETE
- `api/controller`
  - description and details
- `api/controller`
  - description and details

