CREATE FUNCTION generate_customers()
RETURNS void as $$
DECLARE
    i INT;
    first_names TEXT[] := ARRAY['Kylie', 'Brando', 'Alverta', 'Gilbert', 'Merl', 'Abraham', 'Adrain', 'Sage', 'Rosendo', 'Toby', 
		'Olga', 'Jody', 'Kylie', 'Yasmin', 'Dulce', 'Haylee', 'Felton', 'Brandyn', 'Rudolph', 'Jarret', 
		'Allie', 'Ally', 'Brianne', 'Anita', 'Susan', 'Fritz', 'Nedra', 'Brody', 'Anais', 'Amber', 'Maida', 
		'Jonathon', 'Ralph', 'Jalon', 'Delphine', 'Lora', 'Shaina', 'Scotty', 'Dewitt', 'Providenci', 'Vito', 
		'Della', 'Mylene', 'Erick', 'Lyric', 'Kelley', 'Mozell', 'Lenore', 'Daphnee', 'Brennon', 'Elijah', 
		'Bernie', 'Rupert', 'Alvina', 'Vida', 'Ervin', 'Adrian', 'Margot', 'Arely', 'Rozella', 'Corrine', 
		'Rosemarie', 'Violet', 'Winnifred', 'Yoshiko', 'Verner', 'Kendrick', 'Joelle', 'Anderson', 'Reinhold', 
		'Rae', 'Aida', 'Vito', 'Dana', 'Mafalda', 'Noble', 'Carson', 'Jaqueline', 'Michel', 'Kira', 'Willa', 
		'May', 'Kyla', 'Antwon', 'Addison', 'Raymundo', 'Ned', 'Madie', 'Carson', 'Percival', 'Asa', 'Tavares', 
		'Myriam', 'Demario', 'Josiah', 'Maureen', 'Willa', 'Benedict', 'Tyreek', 'Evie', 'Sedrick'];

	last_names TEXT[] := ARRAY['Wolff', 'Braun', 'Rolfson', 'Armstrong', 'Dicki', 'Bahringer', 'Morissette', 'Rogahn', 'Spencer', 
		'Runolfsdottir', 'Goldner-Lind', 'Lockman', 'Ernser', 'Koch', 'Gulgowski', 'Mohr', 'Becker', 
		'Schultz', 'Gottlieb', 'Schmitt', 'Kassulke', 'Boyle', 'Schmidt', 'Conroy', 'Blick', 'Little', 
		'Heller-Wisozk', 'Kiehn', 'Abbott', 'Grant', 'Cronin', 'Johnson', 'Ondricka', 'Cremin', 'Kovacek', 
		'Heller', 'Wehner', 'Schimmel', 'Rolfson', 'Bauch', 'Lebsack', 'Crona', 'Gislason', 'Farrell', 'Rowe', 
		'Volkman', 'Gusikowski', 'Gerhold', 'Gibson', 'Kuhlman', 'Crist', 'Kulas', 'Lubowitz', 'Vandervort', 
		'Lockman', 'Herzog', 'Labadie', 'Parker', 'Ondricka', 'Hermiston', 'Johns', 'Waters', 'Waters', 'Rogahn', 
		'Prosacco', 'Oberbrunner', 'Lueilwitz', 'Gusikowski', 'Dickens', 'Kassulke', 'Wolf', 'Dibbert', 'Wilkinson', 
		'Ferry', 'Auer', 'Runte', 'Cronin-Schinner', 'Ondricka-Halvorson', 'McDermott', 'MacGyver', 'Fay', 'Leffler', 
		'Emmerich', 'Rippin', 'Stamm', 'Schuster', 'Reynolds', 'Turcotte', 'Reichel', 'Keebler', 'Romaguera', 'Prosacco', 
		'Spencer', 'Bergnaum', 'Keeling', 'Terry', 'Greenholt', 'Dooley', 'Hoeger', 'Beier'];

    domains     TEXT[] := ARRAY['gmail.com', 'hotmail.com', 'outlook.org', 'mail.net'];

    cities      TEXT[] := ARRAY['North Winfieldview', 'Jaylinstad', 'Louisville', 'South Carlottashire', 'Predovicchester', 
		'Amiraton', 'North Fredrickstad', 'Emardfurt', 'Fort Dwightview', 'Port Vilma', 'Boehmland', 
		'Delaneyfield', 'Raleighworth', 'West Kearafield', 'Lizziecester', 'East Zula', 'Gaithersburg', 
		'North Verlaport', 'Omaha', 'Josefinahaven', 'Colefield', 'West Jalon', 'East Dayne', 'Pittsburg', 
		'Waelchiberg', 'Constantinstad', 'Britneyboro', 'Fort Jessika', 'Conroyside', 'Lake Ezraview', 
		'Palm Coast', 'Las Vegas', 'Port Marianatown', 'Los Angeles', 'Mentor', 'Kasandraport', 'New Angeline', 
		'Doyletown', 'New Larue', 'Allen', 'McLean', 'McLean', 'Madisynfort', 'Dejuanview', 'Vedafort', 
		'Janiyacester', 'South Deontae', 'Port Manleyboro', 'Altenwerthview', 'Port Mario', 'New Mossie', 
		'Johnsonport', 'Hampton', 'Runolfssontown', 'Port Coltonland', 'West Leonie', 'North Lupe', 'Houston', 
		'Lake Bryceboro', 'South Joseph', 'Shawnchester', 'Fisherfield', 'East Sid', 'Champaign', 'Ernserside', 
		'Port Elvera', 'North Nehafurt', 'Botsfordstead', 'MacGyvertown', 'Willborough', 'Luettgenborough', 
		'Euclid', 'Frederick', 'Fresno', 'Ziemannboro', 'Hermannton', 'West Edyth', 'Dooleybury', 
		'Gutkowskiton', 'Treutelcester', 'Sterling Heights', 'Fort Kaylin', 'Pagacworth', 'Amparoburgh', 
		'West Sacramento', 'Langview', 'Xzaviercester', 'Sauerfurt', 'West Bryana', 'Emmerichtown', 
		'Heaneyport', 'Lindgrenstad', 'New Gildabury', 'Delphafort', 'Lambertside', 'Fort Donnellberg', 
		'South Lafayettemouth', 'North Jaynetown', 'South Carolland', 'Baton Rouge'];

    countries   TEXT[] := ARRAY['Venezuela', 'Anguilla', 'Indonesia', 'Rwanda', 'Moldova', 'Central African Republic', 
		'Thailand', 'Curacao', 'Turkey', 'Samoa', 'India', 'Romania', 'Haiti', 'Belgium', 'Lithuania', 
		'Democratic Republic of the Congo', 'Fiji', 'Panama', 'Albania', 'Venezuela', 'Democratic People Republic of Korea', 
		'Svalbard & Jan Mayen Islands', 'Egypt', 'Holy See (Vatican City State)', 'Curacao', 'Vanuatu', 'Jamaica', 'Austria', 
		'Eswatini', 'Cyprus', 'Guyana', 'Falkland Islands (Malvinas)', 'Taiwan', 'Switzerland', 'Congo', 'Antigua and Barbuda', 
		'Comoros', 'Slovenia', 'Liberia', 'Seychelles', 'Liberia', 'Comoros', 'Congo', 'Kenya', 'Republic of Korea', 
		'Mozambique', 'Oman', 'Paraguay', 'Maldives', 'Eswatini', 'Greece', 'Turkey', 'China', 'New Zealand', 
		'Norfolk Island', 'Antarctica', 'Cocos (Keeling) Islands', 'Slovenia', 'Qatar', 'Turks and Caicos Islands', 
		'Guinea-Bissau', 'Cyprus', 'Malaysia', 'Ukraine', 'Kuwait', 'Madagascar', 'Estonia', 'Cyprus', 'Ghana', 
		'Isle of Man', 'Bangladesh', 'Brunei Darussalam', 'Comoros', 'Taiwan', 'Algeria', 'France', 'Norfolk Island', 
		'Mayotte', 'Liechtenstein', 'Cuba', 'Belarus', 'Tanzania', 'Burundi', 'Christmas Island', 'Saint Pierre and Miquelon', 
		'Niger', 'Cape Verde', 'Ireland', 'Northern Mariana Islands', 'Micronesia', 'Isle of Man', 'Vanuatu', 'Guadeloupe', 
		'Slovenia', 'Zambia', 'Canada', 'Central African Republic', 'Burkina Faso', 'Finland', 'Zimbabwe'];

    random_first_name TEXT;
    random_last_name TEXT;
    random_email TEXT;
    random_details JSONB;
BEGIN
    FOR i IN 1..10000 LOOP  -- Generate 1000 mock customers
        random_first_name := first_names[ceil(random() * array_length(first_names, 1))];
        random_last_name := last_names[ceil(random() * array_length(last_names, 1))];
        random_email := lower(random_first_name || '.' || random_last_name || i || '@' || domains[ceil(random() * array_length(domains, 1))]);

        random_details := jsonb_build_object(
            'city', cities[ceil(random() * array_length(cities, 1))],
            'country', countries[ceil(random() * array_length(countries, 1))]
        );

        INSERT INTO customers (customer_id, first_name, last_name, email, details)
        VALUES (i, random_first_name, random_last_name, random_email, random_details);
    END LOOP;
END;
$$ LANGUAGE plpgsql;

CREATE FUNCTION generate_products()
RETURNS void as $$
DECLARE
	i INT;
	product_name text;
	product_category text;
	product_price float;
BEGIN
	FOR i in 1..8000 loop	
		product_name := 'product ' || i;
		product_category := 'category ' || floor(random() * 100 + 1)::int;
		product_price := ROUND((random() * 100)::numeric, 2);
		insert into products (product_id, product_name, product_category, product_price)
		values (i, product_name, product_category, product_price);
	END LOOP;
END;
$$ LANGUAGE plpgsql;

CREATE FUNCTION generate_orders()
RETURNS void as $$
DECLARE
	counter int := 1;
	i INT;
	order_name text;
	customer_id int;
BEGIN
	FOR i in 1..10000 loop	-- Makes sure that every customer has made an order
		order_name := 'order ' || counter;
		customer_id := i;
		insert into orders (order_name, customer_id)
		values (order_name, customer_id);
		counter := counter +1;
	END LOOP;
	FOR i in 1..90000 loop	
		order_name := 'order ' || counter;
		customer_id := floor(random() * 10000 + 1)::int;
		insert into orders (order_name, customer_id)
		values (order_name, customer_id);
		counter := counter + 1;
	END LOOP;
END;
$$ LANGUAGE plpgsql;

create FUNCTION generate_order_lines()
RETURNS void as $$
DECLARE
	i INT;
	j int;
	order_id int;
	product_id int;
	product_count int;
	product_quantity int;
BEGIN
	FOR i in 1..100000 loop
		product_count := floor(random() * 100 + 1)::int;
		for j in 1..product_count loop
			order_id := i;
			product_id := floor(random() * 8000 + 1)::int;
			product_quantity := floor(random() * 50 + 1)::int;
			insert into order_lines (order_id, product_id, product_quantity)
			values (order_id, product_id, product_quantity);
		end loop;
	END LOOP;
END;
$$ LANGUAGE plpgsql;