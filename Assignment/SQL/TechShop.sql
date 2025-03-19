-- TASK 1
--Database Creation
Create Database TechShop;
use TechShop;

Create Table Customers(
CustomerID int not null Primary key,
FirstName varchar(30) not null,
LastName varchar(30),
Email varchar(30) unique not null,
Phone varchar (15) unique not null,
[Address] Text not null,
);

Create Table Products(
ProductID int primary key,
ProductName varchar(30) not null,
[Description] Text ,
Price numeric(10,3) not null
);

create table Orders(
OrderID int primary key,
CustomerID int not null,
foreign key (CustomerID) references Customers(CustomerID),
OrderDate DATETIME default GETDATE(),
TotalAmount decimal(10,2) NOT NULL
);

create table OrderDetails(
OrderDetailID int primary key,
OrderID int not null,
Foreign key (OrderDetailID) references Orders(OrderID),
ProductID int not null,
Foreign key (ProductID) references Products(ProductID),
Quantity int not null
);

create table Inventory(
InventoryID int Primary key,
ProductID int not null,
Foreign key (ProductID) references Products(ProductID),
QuantityInStock int ,
LastStockUpdate datetime default GETDATE()
);

INSERT INTO Customers (CustomerID,FirstName, LastName, Email, Phone, Address) VALUES
(1,'Harry', 'Potter', 'harrypotter@gmail.com', '1234567890', '4,Privet Drive,surrey'),
(2,'Ron', 'Weasley', 'ron7@gmail.com', '0987654321', 'Ottery,St.Catchpole ,Devon'),
(3,'Hermoine', 'Granger', 'Hermoine@gmail.com', '1122334455', '8,Heathgate,London'),
(4,'Luffy','Monkey', 'luffy@gmail.com', '6677889900', '1000, Sunny Way, Grand Line'),
(5, 'Zoro', 'Roronoa', 'zoro@gmail.com', '5566778899', 'Shimotsuki Village, East Blue'),
(6, 'Nami', 'Cat Burglar', 'nami@gmail.com', '4455667788', 'Cocoyasi Village, East Blue'),
(7, 'Sanji', 'Vinsmoke', 'sanji@gmail.com', '3344556677', 'Baratie, North Blue'),
(8, 'Chopper', 'Tony', 'chopper@gmail.com', '2233445566', 'Drum Island, Grand Line'),
(9, 'Nico', 'Robin', 'robin@gmail.com', '7788990011', 'Ohara, West Blue'),
(10, 'Franky', 'Cyborg', 'franky@gmail.com', '8899001122', 'Water 7, Grand Line');


insert into Products (ProductID,ProductName, [Description], Price) values
(1,'Smartphone', 'Latest model ', 699.99),
(2,'Laptop', 'High-performance laptop', 1299.99),
(3,'Tablet', 'Portable tablet ', 499.99),
(4,'Smartwatch', 'Water-resistant smartwatch ', 199.99),
(5,'Headphones', 'Noise-cancelling wireless headphones', 249.99),
(6,'Smart TV', '4K Ultra HD Smart TV with', 899.99),
(7,'Portable Charger', 'Compact portable charger ', 29.99),
(8,'Bluetooth Speaker', 'Wireless Bluetooth speaker', 79.99),
(9,'VR Headset', 'Virtual reality headset ', 399.99),
(10,'Gaming Console', '4k gaming console ', 499.99);

INSERT INTO Orders (OrderID, CustomerID, TotalAmount) VALUES
(1, 4, 1000),  
(2, 5, 2000), 
(3, 6, 3000),  
(4, 7, 599.99),  
(5, 8, 699.99),  
(6, 9, 7000), 
(7, 10, 8000),
(8, 1, 9000),  
(9, 2, 1999.99), 
(10, 3, 650.99);

select * from Orders;


INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) 
VALUES
(1, 4, 1, 1),  
(2, 4, 7, 1),  
(3, 5, 2, 1),  
(4, 5, 4, 1),  
(5, 6, 3, 1),  
(6, 6, 5, 1),  
(7, 7, 1, 1),  
(8, 7, 8, 1),  
(9, 8, 3, 1),  
(10, 8, 7, 1);  

insert into Inventory (InventoryID, ProductID, QuantityInStock, LastStockUpdate) 
VALUES
(1, 1, 50, '2025-03-18 10:00:00'),  -- Smartphone stock
(2, 2, 30, '2025-03-18 10:15:00'),  -- Laptop stock
(3, 3, 40, '2025-03-18 10:30:00'),  -- Tablet stock
(4, 4, 25, '2025-03-18 10:45:00'),  -- Smartwatch stock
(5, 5, 60, '2025-03-18 11:00:00'),  -- Headphones stock
(6, 6, 20, '2025-03-18 11:15:00'),  -- Smart TV stock
(7, 7, 35, '2025-03-18 11:30:00'),  -- Portable Charger stock
(8, 8, 45, '2025-03-18 11:45:00'),  -- Bluetooth Speaker stock
(9, 9, 15, '2025-03-18 12:00:00'),  -- VR Headset stock
(10, 10, 18, '2025-03-18 12:15:00'); -- Gaming Console stock

/*
SELECT * FROM Customers;
SELECT * FROM Products;
SELECT * FROM Orders;
SELECT * FROM OrderDetails;
SELECT * FROM Inventory;
*/


--TASK 2
--Q1 Write an SQL query to retrieve the names and emails of all customers.
select FirstName , LastName , email from Customers

--Q2 Write an SQL query to list all orders with their order dates and corresponding customer names.
select O.orderid , o.orderdate,c.firstname,c.lastname from Orders O
join Customers c on c.CustomerID = O.CustomerID;

--Q3 Write an SQL query to insert a new customer record into the "Customers" table. Include customer information such as name, email, and address.
insert into Customers(CustomerID,FirstName,Email,Phone,[Address])values
(11,'Jinbe','jinbe@gmail.com',1213141516,'fisherman island');

--Q4 Write an SQL query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%.
update Products
set Price = Price*1.10;
--Q5 Write an SQL query to delete a specific order and its associated order details from the "Orders" and "OrderDetails" tables. Allow users to input the order ID as a parameter.

--Q6 Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, order date, and any other necessary information.
insert into Orders(OrderID,CustomerID,TotalAmount) values
(11,11,799.99);

--Q7 Write an SQL query to update the contact information (e.g., email and address) of a specific customer in the "Customers" table. Allow users to input the customer ID and new contact information.
Update Customers
set Email = 'ron07@gmail.com' , [Address] = 'Ottery,St.Catchpole ,England'
where CustomerID = 2;

select * from Orders