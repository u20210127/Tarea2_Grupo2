CREATE DATABASE TiendaEJKM
GO
USE TiendaEJKM
GO

CREATE TABLE tbl_Customers(
id_Customer INT PRIMARY KEY IDENTITY(1,1)NOT NULL,
Name_Customer VARCHAR(25)NOT NULL,
Address_Customer VARCHAR(50)NOT NULL,
Phone_Customer VARCHAR(20) NOT NULL
);

CREATE TABLE tbl_Employees(
id_Employee INT PRIMARY KEY IDENTITY(1,1)NOT NULL,
Name_Employee VARCHAR(25)NOT NULL,
Address_Employee VARCHAR(50)NOT NULL,
Phone_Employee VARCHAR(20) NOT NULL
);


CREATE TABLE tbl_Products(
id_Product INT PRIMARY KEY IDENTITY(1,1)NOT NULL,
Name_Product VARCHAR(25)NOT NULL,
Category_Product VARCHAR(50)NOT NULL,
Price_Product DECIMAL NOT NULL,
Availability_Product BIT NOT NULL
);

CREATE TABLE tbl_Sales(
id_Sales INT PRIMARY KEY IDENTITY(1,1)NOT NULL,
id_Customer INT NOT NULL,
id_Product INT NOT NULL,
id_Employee INT NOT NULL,
Date_Sale DATE NOT NULL,
Total_Paid DECIMAL (9,2)NOT NULL
CONSTRAINT fk_Customers FOREIGN KEY (id_Customer) REFERENCES tbl_Customers(id_Customer),
CONSTRAINT fk_Products FOREIGN KEY (id_Product) REFERENCES tbl_Products(id_Product),
CONSTRAINT fk_Employees FOREIGN KEY (id_Employee) REFERENCES tbl_Employees(id_Employee)
);

-- Inserción de datos en la tabla tbl_Customers
INSERT INTO tbl_Customers (Name_Customer, Address_Customer, Phone_Customer)
VALUES
    ('John Doe', '123 Main St', 55512345),
    ('Jane Smith', '456 Oak St', 55598765),
    ('Bob Johnson', '789 Maple St', 55587654),
    ('Alice Brown', '321 Pine St', 55523456),
    ('Charlie Wilson', '654 Birch St', 55534567);

-- Inserción de datos en la tabla tbl_Employees
INSERT INTO tbl_Employees (Name_Employee, Address_Employee, Phone_Employee)
VALUES
    ('Emily Davis', '789 Elm St', 55587654),
    ('Mike Miller', '987 Cedar St', 55523456),
    ('Sarah Wilson', '567 Walnut St', 55534567),
    ('Chris Turner', '432 Spruce St', 55545678),
    ('Olivia White', '876 Fir St', 55556789);

-- Inserción de datos en la tabla tbl_Products
INSERT INTO tbl_Products (Name_Product, Category_Product, Price_Product, Availability_Product)
VALUES
    ('Laptop', 'Electronics', 999.99, 1),
    ('T-shirt', 'Apparel', 19.99, 1),
    ('Coffee Maker', 'Appliances', 49.99, 1),
    ('Running Shoes', 'Footwear', 79.99, 1),
    ('Backpack', 'Accessories', 39.99, 1);

-- Inserción de datos en la tabla tbl_Sales
INSERT INTO tbl_Sales (id_Customer, id_Product, id_Employee, Date_Sale, Total_Paid)
VALUES
    (1, 1, 1, '2024-02-27', 999.99),
    (2, 2, 2, '2024-02-28', 19.99),
    (3, 3, 3, '2024-03-01', 49.99),
    (4, 4, 4, '2024-03-02', 79.99),
    (5, 5, 5, '2024-03-03', 39.99);
