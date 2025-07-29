CREATE FUNCTION get_order_products(order_id INT)
RETURNS TABLE (
    "Product name" varchar(50),
    "Product price" float,
    "Product quantity" INT
) AS $$
BEGIN
    RETURN QUERY
    SELECT 
		order_details."Product name",
		order_details."Product price",
		order_details."Product quantity"
    FROM order_details 
    WHERE order_details."Order ID" = order_id;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION get_orders_by_city(city varchar(50), orderBy boolean)
RETURNS TABLE (
    "City" varchar(50),
    "Order count"  int
) AS $$
BEGIN
	if orderBy then -- If the user need it orderd by order count
	    RETURN QUERY
	    SELECT 
			order_details."Client city"::varchar(50) as "City",
			count(distinct order_details."Order name")::int as "Order count" 
	    FROM order_details 
		where city = '' or order_details."Client city" = city
		group by order_details."Client city"
		order by "Order count" desc; -- to have the cities with the highes count be visible
	else
		RETURN QUERY
	    SELECT 
			order_details."Client city"::varchar(50) as "City",
			count(distinct order_details."Order name")::int as "Order count" 
	    FROM order_details 
		where city = '' or order_details."Client city" = city
		group by order_details."Client country", -- Incase there is a city that exists in several countries
			order_details."Client city";
	end if;
END;
$$ LANGUAGE plpgsql;