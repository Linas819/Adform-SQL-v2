-- Creating a view as one query to get all information about the orders (Product and client details)

CREATE VIEW public.order_details_view
AS SELECT o.order_id AS "Order ID",
    o.order_name AS "Order name",
    c.first_name AS "Client first name",
    c.last_name AS "Client last name",
    c.details AS "Client details",
    c.details ->> 'city'::text AS "Client city",
    c.details ->> 'country'::text AS "Client country",
    p.product_name AS "Product name",
    p.product_price AS "Product price",
    p.product_category AS "Product category",
    ol.product_quantity AS "Product quantity"
   FROM orders o
     JOIN orderlines ol ON ol.order_id = o.order_id
     JOIN customers c ON c.customer_id = o.customer_id
     JOIN products p ON p.product_id = ol.product_id;