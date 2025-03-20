-- TASK 1
--Database Creation
Create Database TechShop;
use TechShop;

Create Table Customers(
CustomerID int identity(1,1) Primary key,
FirstName varchar(30) not null,
LastName varchar(30),
Email varchar(30) unique not null,
Phone varchar (15) unique not null,
[Address] Text not null,
);

Create Table Products(
ProductID int identity(1,1) primary key,
ProductName varchar(30) not null,
[Description] Text ,
Price decimal(10,3) not null
);

create table Orders(
OrderID int identity(1,1) primary key,
CustomerID int not null,
foreign key (CustomerID) references Customers(CustomerID),
OrderDate DATETIME default GETDATE(),
TotalAmount decimal(10,2) 
);

create table OrderDetails(
OrderDetailID int identity(1,1) primary key,
OrderID int not null,
Foreign key (OrderID) references Orders(OrderID),
ProductID int not null,
Foreign key (ProductID) references Products(ProductID),
Quantity int 
);

create table Inventory(
InventoryID int identity(1,1) Primary key,
ProductID int not null,
Foreign key (ProductID) references Products(ProductID),
QuantityInStock int ,
LastStockUpdate datetime default GETDATE()
);

--Inserting Values into customers
insert into Customers (FirstName, LastName, Email, Phone, [Address])values
('Mohan', 'Prabu', 'mohanprabu.g12@gmail.com', '8056050242', 'Kolathur, Chennai'),
('Sindhiya', 'Rani', 'sindhiya221080@gmail.com', '8838753551', 'Kolathur, Chennai'),
('Luffy', 'Monkey', 'luffy@gmail.com', '6677889900', '1000, Sunny Way, Grand Line'),
('Zoro', 'Roronoa', 'zoro@gmail.com', '5566778899', 'Shimotsuki Village, East Blue'),
('Nami', 'Cat Burglar', 'nami@gmail.com', '4455667788', 'Cocoyasi Village, East Blue'),
('Sanji', 'Vinsmoke', 'sanji@gmail.com', '3344556677', 'Baratie, North Blue'),
('Chopper', 'Tony', 'chopper@gmail.com', '2233445566', 'Drum Island, Grand Line'),
('Nico', 'Robin', 'robin@gmail.com', '7788990011', 'Ohara, West Blue'),
('Franky', 'Cyborg', 'franky@gmail.com', '8899001122', 'Water 7, Grand Line'),
('Jinbe',null, 'jinbe@gmail.com', '1314151617', 'Fisherman Island');

--Inserting Values into products

insert into Products (ProductName, Description, Price)values
('Smartphone', 'Latest model', 999.99),
('Laptop','High-performance laptop', 5999.99),
('Tablet', 'Portable tablet', 5000),
('Smartwatch', 'Water-resistant smartwatch',200),
('Headphones', 'Noise-cancelling wireless headphones', 249.99),
('Smart TV', '4K Ultra HD Smart TV', 899.99),
('Portable Charger', 'Compact portable charger', 29.99),
('Bluetooth Speaker', 'Wireless Bluetooth speaker', 79.99),
('VR Headset', 'Virtual reality headset', 399.99),
('Gaming Console', '4K gaming console', 499.99);


--inserting into orders
insert into orders(CustomerID,TotalAmount)values
(1,999.99),
(2,200),
(3,500),
(4,1000),  
(5, 2000), 
(6,3000),  
(7,599.99),  
(8,699.99),  
(9,7000), 
(10,8000);

--inserting into orderdetails
insert into OrderDetails(OrderID,ProductID,Quantity)values
(1,1,1),
(2,4,1),
(3,4,2),
(4,10,1),
(5, 2, 1),
(6, 6, 1),
(7, 7, 2),
(8, 8, 1),
(9, 9, 1),
(10, 10, 1);

--inserting into inventory
insert into Inventory(ProductID,LastStockUpdate,QuantityInStock)values
(1,'2025-03-01',5),
(2,'2025-03-01',3),
(3,'2025-03-01',2),
(4,'2025-03-01',2),
(5,'2025-03-01',8),
(6,'2025-03-01',4),
(7,'2025-03-01',10),
(8,'2025-03-01',2),
(9,'2025-03-01',7),
(10,'2025-03-01',5);

select * from Customers
select * from Products
select * from orders
select * from OrderDetails
select * from Inventory

