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
[Status] varchar(50) not null CHECK([Status] in ('Scheduled', 'In Progress', 'Completed', 'Cancelled')),
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
[Status] varchar(50) not null check([Status] in ('Confirmed', 'Cancelled', 'Completed')),
foreign key (TripID) references Trips(TripID),
foreign key (PassengerID) references Passengers(PassengerID)
);




select * from Vehicles