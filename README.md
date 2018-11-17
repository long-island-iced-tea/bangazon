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
- `api/product/product`
  - Posts new product

#### PUT
- `api/product/product`
  - Updates product 
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
<<<<<<< HEAD
- `api/controller`
  - description and details

#### PUT
- `api/controller`
  - description and details

=======
- `api/PaymentType`
  - Able to add another payment type to the database
#### PUT
- `api/PaymentType`
  - Update an existing payment type by id
>>>>>>> master
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
- `api/orders`
  - Accepts an Order object and inserts it into the database, and returns the object including its assigned id.
#### PUT
- `api/orders/{id}`
  - Accepts an Order object (ignoring the `id` attribute on the object, if present) and updates the URL-indicated order with the properties in it, then returns the modified order.
#### DELETE
- `api/orders/{id}`
  - Attempts to delete the indicated order in the DB, then returns `Ok` or `BadRequest` along with an object with a `rowsDeleted` attribute indicating the number of rows affected.

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

