--TASK 2
use TechShop

--Q1. Write an SQL query to retrieve the names and emails of all customers.
select FirstName,LastName,email from Customers

--Q2. Write an SQL query to list all orders with their order dates and corresponding customer names.
select o.OrderID,o.OrderDate,c.FirstName,c.LastName from Orders o
join Customers c on c.CustomerID=o.CustomerID;

--Q3. Write an SQL query to insert a new customer record into the "Customers" table. Include customer information such as name, email, and address.
insert into Customers(FirstName,LastName,Email,Phone,Address)values
('sudharsan','M','sudharsan.prabu05@gmail.com','7604875003','Kolathur,Chennai');

--Q4. Write an SQL query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%.
update Products
set Price = price + (price * 0.1);

--Q5. Write an SQL query to delete a specific order and its associated order details from the "Orders" and "OrderDetails" tables. Allow users to input the order ID as a parameter.
delete from OrderDetails
where OrderDetailID=10;
delete from Orders
where OrderID=10;

--Q6. Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, order date, and any other necessary information.
insert into orders(CustomerID,OrderDate,TotalAmount)values
(10,'2025-03-20',1500);

--Q7. Write an SQL query to update the contact information (e.g., email and address) of a specific customer in the "Customers" table. Allow users to input the customer ID and new contact information.
update Customers
set email = 'sudharsan.m.2021.ece@gmail.com' , Phone='9444705542'
where CustomerID=11;

--Q 8. Write an SQL query to recalculate and update the total cost of each order in the "Orders" table based on the prices and quantities in the "OrderDetails" table.
update Orders 
set TotalAmount = (
   select sum(od.quantity * p.price)
   from OrderDetails od
   join Products p on od.ProductID=p.ProductID
   where od.OrderID=Orders.OrderID
   );

--Q 9. Write an SQL query to delete all orders and their associated order details for a specific customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID as a parameter.
delete from OrderDetails
where OrderID in (select OrderID from Orders where CustomerID=4);
delete from Orders
where CustomerID=4;

--Q 10. Write an SQL query to insert a new electronic gadget product into the "Products" table, including product name, category, price, and any other relevant details.
insert into Products(ProductName,Description,Price)values
('Wireless Earbuds','Noise cancelling',600);

--Q 11. Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from "Pending" to "Shipped"). Allow users to input the order ID and the new status.
update orders
set status = 'Shipped'
where OrderID = 5;

--Q12. Write an SQL query to calculate and update the number of orders placed by each customer in the "Customers" table based on the data in the "Orders" table.
update customers
set orderCount = (
     select count(*)
     from orders
	 where Orders.CustomerID=Customers.CustomerID
	 )
