-- Creating a view as one query to get all information about the orders (Product and client details)
create view order_details as 
select o.order_id as "Order ID",
	o.order_name as "Order name",
	c.first_name as "Client first name",
	c.last_name as "Client last name", 
	c.details as "Client details", 
	p.product_name as "Product name", 
	p.product_price as "Product price", 
	ol.product_quantity as "Product quantity" 
from orders o 
join orderlines ol on ol.order_id = o.order_id
join customers c on c.customer_id = o.customer_id
join products p on p.product_id = ol.product_id