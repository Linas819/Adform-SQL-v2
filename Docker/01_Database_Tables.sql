-- Created customers table first as it's primary key will be needed in the orders table
CREATE TABLE customers (
  customer_id SERIAL PRIMARY KEY,
  first_name VARCHAR(50) NOT NULL, -- Read best practices that say varchar should be max at 50. Any longer, use TEXT.
  last_name VARCHAR(50) NOT NULL,
  email VARCHAR(50) NOT NULL,
  details JSONB NOT NULL -- Using JSONB instead of JSON to better search trough the format.
); 

-- Created products table second as it's primary key will be needed in the orderlines table
CREATE TABLE products (
product_id SERIAL PRIMARY KEY,
product_name VARCHAR(50) NOT NULL,
product_category VARCHAR(50) NOT NULL,
product_price FLOAT
);

CREATE TABLE  orders (
order_id SERIAL PRIMARY KEY,
order_name VARCHAR(50) NOT NULL,
customer_id SERIAL,
CONSTRAINT fk_customer
      FOREIGN KEY(customer_id)
        REFERENCES customers(customer_id)
        ON DELETE CASCADE -- Chosen to delete the entries if the customer entry is deleted.
);

CREATE INDEX orders_customer_id_idx on orders(customer_id); -- Creating an index on the orders.customer_id for better joining.

CREATE TABLE orderlines (
order_line_id SERIAL PRIMARY KEY,
order_id SERIAL,
product_id SERIAL,
product_quantity INT,
CONSTRAINT fk_order
    FOREIGN KEY(order_id)
    	REFERENCES orders(order_id)
        	ON DELETE CASCADE, -- Chosen to delete the entries if the order entry is deleted.
CONSTRAINT fk_product
    FOREIGN KEY(product_id)
    	REFERENCES products(product_id)
        	ON DELETE CASCADE, -- Chosen to delete the entries if the product entry is deleted.
CONSTRAINT check_quantity_not_0
	CHECK (product_quantity > 0) -- To ensure that there is no negative quantity.
);

CREATE INDEX orderlines_order_id_idx on orderlines(order_id);
CREATE INDEX orderlines_product_id_idx on orderlines(product_id);