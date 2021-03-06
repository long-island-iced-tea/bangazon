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
- `api/customers?active=true`
  - Returns all customers that have an order associated with them
  - `active=false` will return customers without orders
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
- `api/PaymentType`
  - Able to add another payment type to the database
#### PUT
- `api/PaymentType`
  - Update an existing payment type by id
#### DELETE
- `api/PaymentType/id`
  - Payment Type will delete by payment type ID

### Order
#### GET
- `api/orders`
  - Returns all orders in the database.
  - Parameters:
    - `?completed=true` or `completed=false`: Filters the returned orders by the Completed attribute.
    - `?include=products`: Returned objects will also include the products associated with each order.
    - `?include=customers`: Returned objects will also include the customer associated with each order.
- `api/orders/{id}`
  - Returns the matching single order, or a `BadRequest` response if not found.
  - Parameters:
    - `?include=products`: Returned object will also include the associated products.
    - `?include=customers`: Returned object will also include the associated customer.
#### POST
- `api/orders`
  - Accepts an Order object and inserts it into the database, and returns the Order object including its assigned id.
#### PUT
- `api/orders/{id}`
  - Accepts an Order object (ignoring the `id` attribute on the object, if present) and updates the URL-indicated order with the properties in it, then returns the modified order.
#### DELETE
- `api/orders/{id}`
  - Attempts to delete the indicated order in the DB, then returns `Ok` or `BadRequest` along with an object with a `rowsDeleted` attribute indicating the number of rows affected.

### ProductType
#### GET
- `api/producttypes`
  - Returns all product types.
- `api/producttypes/{id}`
  - Returns the product type with the matching id.
#### POST
- `api/producttypes`
  - Returns the product type just inserted
  - Takes a body of
  ```json
  {
    "name": "Product Type"
  }
  ```
#### PUT
- `api/producttypes`
  - Updates the product type name and returns the updated type
  - Takes a body of
  ```json
  {
    "id": 1,
    "name": "Edited name"
  }
  ```
#### DELETE
- `api/producttypes/{id}`
  - Deletes the product type by id
  - Returns 200 if successful

### Employee
#### GET
- `api/Employee`
  - All Employees returned with department name and computer object
- `api/Employee/id`
  - Single Employee is returned with department name and computer object
#### POST
- `api/Employee`
  - Able to add an employee
#### PUT
- `api/Employee`
  - able to update an employees information
#### DELETE
- `api/Employee/id`
  - able to delete an employee by employee id.

### Department
#### GET
- `api/department`
  - Gets all departments
- `api/department/id`
  - Gets single department by id
- `api/department?include=employees`
  - Returns all departments with the list of employees.
#### POST
- `api/department`
  - Adds new department to database, return 200 if successful
  - Takes a body of
  ```json
  {
    "name": "New Department",
    "budget": 800.43,
    "supervisorId": 4
  }
  ```
#### PUT
- `api/department`
  - Updates the department with the given id
  - Takes a body of
  ```json
  {
    "id": 3,
    "name": "Updated Department",
    "budget": 99.99,
    "supervisorId": 2
  }
  ```
### Computer
#### GET
- `api/computer`
  - Gets all computers
- `api/computer/id`
  - Gets computer by id
#### POST
- `api/computer/computer`
  - Posts new computer
#### PUT
- `api/computer/computer`
  - Updates computer

#### DELETE
- `api/computer/id`
  - Deletes by id
- `api/controller`
  - description and details

### TrainingProgram
#### GET
- `api/trainingprogram`
  - Retrieves a list of all training programs including attending employees.
  - Supported parameters:
    - `?completed=true` or `false`: Filters the list by whether or not the Start Date has already passed.
- `api/trainingprogram/{id}`
  - Retrieves the specific Training Program including attending employees.
#### POST
- `api/trainingprogram`
  - Inserts a new Training Program into the database.
    - If the start or end dates are not specified, they will default to the current day.
#### PUT
- `api/trainingprogram/{id}`
  - Updates the specified Training Program with the properties on the submitted one, then returns the modified TrainingProgram.
      - Any `id` property on the submitted object is ignored in favor of the one in the URL.
#### DELETE
- `api/trainingprogram/{id}`
  - Deletes and returns the specified Training Program from the database.
    - If the start date of the specified program is in the past, the program will not be deleted and an error message will be returned stating this.

