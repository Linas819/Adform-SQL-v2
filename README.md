# AdForm-SQL-v2
An updated version of the original [AdForm-SQL task](https://github.com/Linas819/AdForm-SQL-API). Exercise: [Order Management SQL Exercise](https://github.com/erinev/order-management-sql-exercise)

## Instructions
1. In your docker terminal, navigate to the reposetory's folder (where docker compose.yaml file is located).
2. Run ``` docker compose up ``` command.</br>
**Note**: container initialization may take a while.
3. to test out the optional API, open ``` https://localhost:8080/swagger/index.html ```
4. To test using a CloudBeaver database manager open up ``` https://localhost:8978 ```
### Connect to Postgres in CloudBeaver
1. Set up the main server configuration using your made up credentials and click *NEXT*:</br>
![Server configuration](<Information screenshots/CloudBeaver initial server configuration.png>)
2. Once the configuration is complete (after clicking the *FINISH* button), log in with the credentials you created:</br>
![Authentication](<Information screenshots/CloudBeaver authentication.png>)
3. When logged in, navigate to the CloudBeaver's app by clicking on it's icon in the top left corner and start a connection, by clicking the **New Connection** button on the sidebar or **CloudBeaver Community** page:</br>
![CloudBeaver app](<Information screenshots/CloudBeaver app.png>)
4. Select *PostgreSQL* as your **New Connection**:</br>
![New connection](<Information screenshots/New connection.png>)
5. Put the credentials as configured in the docker-compose.yaml file:
**Host**: postgresdb</br>
**Posrt**: 5432</br>
**Database**: Adform</br>
**User name**: postgres</br>
**User password**: admin</br>
![Connection configuration](<Information screenshots/Connection configuration.png>)</br>
You can click **TEST** or **CREATE** to connect to the database.
5. Once the connection has been established, you can see it on the left sidebar:</br>
![Connection side bar](<Information screenshots/Connection done.png>)</br>

**NOTE**: Test queries can be found in SQL Scripts -> Get Data Queries.sql file.</br>
**IMPORTANT**: Data is being randomly generated. Some placeholder names, might not be valid.

## Problem Statement

A retailer company is looking to develop an order management system to streamline their order processing and products management.

Your task is to build a database that stores information related to customers, products and their orders. Additionally, the system should provide capabilities to generate reports about ordered products.

## Requirements

> **Hint**:  
Some requirements are open-ended so you can implement them in a way that you think would be most convenient for the database user or is considered a best practice.

### Functional

* As a retailer I need a **database table(s)** so I could manage **customers**. Each customer must have the following info: `first name`, `last name`, `email` and `details`;
    * `details` column contains data about customer location and must be stored using **JavaScript Object Notation** (JSON) e.g.: ``` { "country": "Lithuania", "city": "Kaunas" } ```
* As a retailer I need a **database table(s)** so I could manage **products**. Each product must have the following info: `name`, `category` and `price`;
* As a retailer I need a **database table(s)** so I could manage **orders**. Each order must contain the following info: `customer who made order`, `list of ordered products with quantity of each ordered item`;
* As a retailer I need an **SQL query** so I could retrieve an **order's invoice**. The invoice should contain a list of products where **each product** has `name`, `category`, `quantity`, `amount ($)` and additionally show `total amount ($)` to pay for all products.
* As a retailer I need an **SQL query** so I could retrieve a **report about orders distribution by customer location**. The report should show the `customer city`, `number of orders` that were made from this city and `total amount ($)` of ordered products from this city;
    * It should be possible to **filter** by `customer city` column;
    * It should be possible to **order** by `number of orders` column;

### Non-Functional

* The solution code must be in a **Git repository**;
* Use **PostgreSQL** database;
* Include prerequisites, steps to launch and provide SQL query examples in **README**;
* Your solution should follow **best practices in relational database design**.
* **Mock** data in the main input tables:
    * `customers` table: 10,000 rows;
    * `products` table: 8,000 rows; 
    * `orders` table: 100,000 rows;
        * Number of different products in a single order should vary from 1 to 100;
        * Amount of a single product inside a single order should vary from 1 to 50;
        * Make sure data integrity is not violated (e.g., an order should contain only existing products);
* **Performance optimization**;
    * Any type of optimization which would make queries (**reads**) complete faster;
    * Also think about implications for **writes** performance;

### Bonus Points

* **Docker-Compose** for easy local testing;
    * meaning that DB tables and mocks would be applied automatically and we could test queries without needing to install PostgreSQL server on our machine;
* **Pagination support**
* **Progress of your work** (hint - `commits strategy`);
* **Comments/thoughts** on the decisions you made;
* **Performance tests**;
* **Simple .NET API** which allows executing SQL queries for **order's invoice** and **report about orders distribution**;
    * Use `Swagger` for easier API request testing;
    * **Logging** (hint: Serilog);
    * Code is structured using some known **architecture** (e.g., NTier, Onion, etc.);
    * **REST**ful API;
* **Automated tests**;
  * **Continuous integration** (CI. hint - `GitHub Actions`);

## Time for Solution

Take as long as you need on the solution, but we suggest limiting yourself to 8 hours or less. Do let us know how much time it took you! 

The task is not made to be completed in the period of 8 hours and no one expects you to! 
However, knowing how much time you spent and seeing the solution you came up with allows for seeing what you prioritize and where you would consider cutting corners on a sharp deadline.

## Technology used
1. PostgreSQL 17.
2. DBeaver: a database management system.
3. Docker.
4. Visual Studio 2022.
5. .NET 8.0
6. JavaScript and [Faker](https://fakerjs.dev/) library for generating realistic mock data and SQL scripts to upload the data to PostgreSQL database.
7. Swagger API testing tool.
8. Serilog.

## Tasks and time duration
Database set up: 1 hour.</br>
Mock data generation and upload to database: 30 min.</br>
View, function set up and testing: 4 hour.</br>
API project set up and implementation: 4 hours</br>
Docker integration and testing : 2 hours.
