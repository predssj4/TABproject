drop table Payments;
drop table Orders;


create table Payments
(
	PaymentId int primary key,
	Description varchar(1000)
);

create table Orders
(
	OrderId int primary key,
	CustomerId int,
	StoreId int,
	PaymentId int,
	OrderDate date	
);

create table Customers
(
	CustomerId int primary key,
	Name varchar(50) not null,
	LastName varchar(50) not null,
	BirthDate date not null,
	Address varchar(100) not null,
	Gender varchar(2) not null,
	CustomerProfileDescriptionId int not null
);

create table CustomerProfileDescriptions
(
	CustomerProfileDescId int primary key,
	Description varchar(250) not null
);

Create table Stores
(
	StoreId int primary key,
	Name varchar(100) not null,
	Street varchar(50) not null,
	City varchar(50) not null,
	Voivodeship varchar(50) not null,
);

Create table StoresToStoreHouses
(
	StoreId int,
	StoreHouseId int

	primary key(StoreId, StoreHouseId)
);

Create table StoreHouses
(
	StoreHouseId int primary key,
	Street varchar(50) not null,
	City varchar(50) not null,
	Voivodeship varchar(50) not null,
);

Create table StoreHousesToProduct
(
	StoreHouseId int,
	ProductId int,

	primary key(StoreHouseId, ProductId)
)

Create table Products
(
	ProductId int primary key,
	Name varchar(100) not null,
	Description varchar(500) not null,
	ProductTypeId int not null,
	Price decimal not null,
);

Create table ProductTypes
(
	TypeId int primary key,
	Name varchar(30)
)


