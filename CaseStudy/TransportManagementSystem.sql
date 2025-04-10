create database TransportManagementSystem;

create table Vehicles(
VehicleID int Identity(1,1) Primary Key,
Model varchar(255),
Capacity decimal(10,2),
[Type] varchar(255),
[Status] varchar(255) default'Available' CHECK ([Status] IN ('Available', 'On Trip', 'Maintenance'))
);

create table [Routes](
RouteID int Identity(1,1) Primary key,
StartDestination varchar(255),
EndDestination varchar(255),
Distance decimal(10,2)
);

create table Trips(
TripID int identity(1,1) Primary Key,
VehicleID int not null,
RouteID int not null,
DepartureDate datetime not null,
ArrivalDate datetime not null,
[Status] varchar(50) not null default'Scheduled' CHECK([Status] in ('Scheduled', 'In Progress', 'Completed', 'Cancelled')),
TripType varchar(50) default 'Freight' CHECK (TripType IN ('Freight', 'Passenger')),
MaxPassengers int CHECK(MaxPassengers > 0),
foreign key (VehicleID) references Vehicles(VehicleID),
foreign key (RouteID) references [Routes](RouteID)
);


create table Passengers(
PassengerID int identity(1,1) primary key,
FirstName varchar(255) not null,
gender varchar(255) not null check(gender in ('Male','Female','Others')),
age int not null,
Email varchar(255) unique,
PhoneNumber varchar(50)
);

create table Bookings(
BookingID int identity(1,1) primary key,
TripID int not null,
PassengerID int not null,
BookingDate datetime,
[Status] varchar(50) not null default'Confirmed' check([Status] in ('Confirmed', 'Cancelled', 'Completed')),
foreign key (TripID) references Trips(TripID),
foreign key (PassengerID) references Passengers(PassengerID)
);

CREATE TABLE Drivers (
DriverID int Identity(1,1) Primary Key,
FirstName varchar(255) not null,
LastName varchar(255) ,
LicenseNumber varchar(100) unique NOT NULL,
PhoneNumber varchar(50),
Email varchar(255) unique,
[Status] varchar(50) not null default 'Available' CHECK (Status in ('Available', 'Assigned', 'On Leave'))
);

alter table Trips
add DriverID int;

alter table Trips
add constraint fk_Trips_Drivers foreign key (DriverID)
references Drivers(DriverID);

insert into Drivers (FirstName, LastName, LicenseNumber, PhoneNumber, Email, Status)values 
('Sonu', 'M', 'MH12AB1234', '9876543210', 'sonu@gmail.com', 'Available'),
('Anita', 'Sharma', 'DL09CD5678', '9123456789', 'anita.sharma@gmail.com', 'Available'),
('sekar', 'Doss', 'KA03EF9012', '9988776655', 'sekardoss@gmail.com', 'On Leave'),
('Priya', 'Verma', 'TN22GH3456', '9876512345', 'priya@gmail.com', 'Assigned'),
('Virat', 'Kohli', 'GJ01JK7890', '9001234567', 'virat@gmail.com', 'Available');


INSERT INTO Passengers (FirstName, gender, age, Email, PhoneNumber)
VALUES
('Rohit Sharma', 'Male', 28, 'rohit.sharma@gmail.com', '9876543210'),
('Priya Sharma', 'Female', 25, 'priya.verma@gmail.com', '9123456780'),
('Amit Patel', 'Male', 34, 'amit.patel@gmail.com', '9988776655'),
('Sneha Reddy', 'Female', 30, 'sneha.reddy@gmail.com', '9090909090');

insert into [Routes] (StartDestination, EndDestination, Distance)
values
('Delhi', 'Mumbai', 1415.00),
('Bangalore', 'Hyderabad', 575.50),
('Chennai', 'Kolkata', 1675.00),
('Pune', 'Ahmedabad', 660.25),
('Jaipur', 'Lucknow', 570.00),
('Kochi', 'Thiruvananthapuram', 200.00),
('Indore', 'Bhopal', 195.75),
('Nagpur', 'Raipur', 285.40),
('Surat', 'Vadodara', 150.20),
('Patna', 'Ranchi', 325.60);

select * from Vehicles
select * from [Routes]
select * from Bookings
select * from Trips
select * from Passengers
select * from drivers

-- Insert Bookings
INSERT INTO Bookings (TripID, PassengerID, BookingDate, Status)
VALUES 
(1, 1, '2025-04-01', 'Confirmed'),
(1, 2, '2025-04-02', 'Cancelled'),
(1, 1, '2025-04-03', 'Confirmed');

