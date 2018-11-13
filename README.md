# Bangazon Inc.

## Description
A backend service for a platform for customers to buy and sell products.
Includes employee and company data.

## Resources

### Customer
#### GET
- `api/customer`
  - Returns a list of every customer in the database
- `api/customers?id=5`
  - Returns a single customers information by id
- `api/customers?include=products
  - Returns all customers with their products
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

### Product
#### GET
- `api/product`
  - Reads all products from database
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

#### PUT
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

