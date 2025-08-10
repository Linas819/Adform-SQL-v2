-- Invoice data
-- Invoice order name query:
SELECT * FROM get_order_invoice_order_name(11001);

-- Invoice order products query:
SELECT * from get_order_invoice(11001);

-- Invoice total price
SELECT * from get_order_invoice_total_price(11001);

-- Order distribution by client's city (All cities, list ordered, which page, page size):
SELECT * FROM get_orders_by_city('', true, 2, 3);

-- Order distribution by client's city (Port Syble city selected, list not ordered, no pagination):
SELECT * FROM get_orders_by_city('Port Syble', false, null, null);