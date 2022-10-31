DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS categories;
DROP TABLE IF EXISTS suppliers;

CREATE TABLE categories (
    id int IDENTITY(1,1) PRIMARY KEY,
    department VARCHAR(20) NOT NULL,
    name VARCHAR(20) NOT NULL,
    description VARCHAR(100) NOT NULL,
);

CREATE TABLE suppliers (
    id int IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(20) NOT NULL,
    description VARCHAR(100) NOT NULL,
);

CREATE TABLE products (
    id int IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(20) NOT NULL,
    defaultprice DECIMAL(20) NOT NULL,
    currency VARCHAR(20) NOT NULL,
    description VARCHAR(100) NOT NULL,
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