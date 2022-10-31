DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS suppliers;
DROP TABLE IF EXISTS categories;

CREATE TABLE categories (
    id int IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(20) NOT NULL,
    department VARCHAR(20) NOT NULL,
    description VARCHAR(100) NOT NULL,
);

CREATE TABLE suppliers (
    id int IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(20) NOT NULL,
    description VARCHAR(100) NOT NULL,
);

CREATE TABLE products (
    id int IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    defaultprice DECIMAL(20) NOT NULL,
    currency VARCHAR(20) NOT NULL,
    description VARCHAR(200) NOT NULL,
    category_id int NOT NULL,
    supplier_id int NOT NULL,
    CONSTRAINT fk_category_id FOREIGN KEY (category_id)
    REFERENCES categories (id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
    CONSTRAINT fk_supplier_id FOREIGN KEY (supplier_id)
    REFERENCES suppliers (id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

INSERT INTO categories(name, department, description) VALUES('Shirt', 'Shirt', 'Best clothes for biggest fans, for low price');
INSERT INTO categories(name, department, description) VALUES('Mug', 'Mug', 'Best gift for your family members');

INSERT INTO suppliers(name, description) VALUES('Marci', 'Marci collection made by UristenVery.Co');
INSERT INTO suppliers(name, description) VALUES('Hajni', 'Hajni collection made by UristenVery.Co');
INSERT INTO suppliers(name, description) VALUES('Gergő', 'Gergő collection made by UristenVery.Co');
INSERT INTO suppliers(name, description) VALUES('Robi', 'Robi collection made by UristenVery.Co');
INSERT INTO suppliers(name, description) VALUES('Zoárd', 'Zoárd collection made by UristenVery.Co');
INSERT INTO suppliers(name, description) VALUES('Fülöp', 'Fülöp collection made by UristenVery.Co');

INSERT INTO products (name, defaultprice, currency, description, category_id, supplier_id)
VALUES ('Madafakin'' Marcell T-Shirt', 12500, 'HUF', 'Special for Gudmon fans, Fantastic price. 100% Cotton, very confortable', 1, 1);

INSERT INTO products (name, defaultprice, currency, description, category_id, supplier_id)
VALUES ('Freaky Fülöp T-Shirt', 10000, 'HUF', 'Great as a gift for your sister, mother, daughter. Only the highest quality cotton. Comfortable, stylish.', 1, 6);

INSERT INTO products (name, defaultprice, currency, description, category_id, supplier_id)
VALUES('Gorgeous Gergő T-Shirt', 12000, 'HUF','Compliment your beauty with this wonderful piece of clothing. Catch the eye of everyone on the street. High-quality fabric.',1, 3);

INSERT INTO products (name, defaultprice, currency, description, category_id, supplier_id)
VALUES('Rockin'' Robi T-Shirt', 11000, 'HUF', 'Go to any concert and be the coolest audience member there. All while staying comfortable in this high quality clothing.', 1, 4);

INSERT INTO products (name, defaultprice, currency, description, category_id, supplier_id)
VALUES('Happy Hajni T-Shirt', 12000, 'HUF', 'Have a cheerful day, look in the mirror and smile with this joyous t-shirt.', 1, 2);

INSERT INTO products (name, defaultprice, currency, description, category_id, supplier_id)
VALUES('Zany Zoárd T-Shirt', 13000, 'HUF', 'Feel stylish and carefree wearing the hottest article of fashion. Only 100% cotton!', 1, 5);

INSERT INTO products (name, defaultprice, currency, description, category_id, supplier_id)
VALUES('Szipi szupi Gergő bögre', 6500, 'HUF', 'The perfect Cup of <T> for C# devs', 2, 3);

INSERT INTO products (name, defaultprice, currency, description, category_id, supplier_id)
VALUES('Gudmon A KFT bögre', 8500, 'HUF', 'Forget your simple glass of water days. The mugs are where it''s at now.', 2, 1);

INSERT INTO products (name, defaultprice, currency, description, category_id, supplier_id)
VALUES('T Error a házba Hajni bögre', 8500, 'HUF', 'It hasn''t got a spout but you can sure bet it has a handle! Ain''t that great?', 2, 2);

INSERT INTO products (name, defaultprice, currency, description, category_id, supplier_id)
VALUES('Salt Daddy Fülöp bögre', 3000, 'HUF', 'Coffee lovers unite: pour your favorite substance into this lavish cup.', 2, 6);

INSERT INTO products (name, defaultprice, currency, description, category_id, supplier_id)
VALUES('BugBuster Zoárd bögre', 10000, 'HUF', 'Drink your daily choice of poison from this lovely ceramic mug.', 2, 5);