create database TechShop;

use TechShop;

create table Customers(
CustomerID int primary Key,
FirstName varchar(30),
LastName varchar(20),
Email varchar(30),
Phone varchar(10),
[Address] varchar(40),
);

create table Products(
ProductId int primary key,
ProductName varchar(30),
[Description] varchar(30),
Price int 
);

create table Orders(
OrderId int primary key,
CustomerID int ,
Foreign key(CustomerID) references Customers(CustomerID),
OrderDate date,
TotalAmount int
);

create table OrderDetails(
OrderDetailID int primary key,
OrderID int ,
Foreign key (OrderID) references Orders(OrderId),
ProductID int,
Foreign key (ProductID) references Products(ProductID),
Quantity int 
);

create table Inventory(
InventoryID int primary key,
ProductID int,
Foreign key (ProductID) references Products(ProductID),
QuantityInStock int ,
LastStockUpdate datetime
);