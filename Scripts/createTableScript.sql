create table Payments
(
	PaymentId int identity(1,1) primary key,
	Description varchar(1000)
);

create table Orders
(
	OrderId int identity(1,1) primary key,
	CustomerId int not null,
	StoreId int not null,
	PaymentId int foreign key references Payments(PaymentId),
	OrderDate date not null	
);

create table CustomerProfileDescriptions
(
	CustomerProfileDescId int identity(1,1) primary key,
	Description varchar(250) not null
);

create table Customers
(
	CustomerId int identity(1,1) primary key,
	Name varchar(50) not null,
	LastName varchar(50) not null,
	BirthDate date not null,
	Address varchar(100) not null,
	Gender varchar(2) not null,
	CustomerProfileDescriptionId int foreign key references CustomerProfileDescriptions(CustomerProfileDescId) on delete cascade
);


Create table Stores
(
	StoreId int identity(1,1) primary key,
	Name varchar(100) not null,
	Street varchar(50) not null,
	City varchar(50) not null,
	Voivodeship varchar(50) not null,
);

Create table StoreHouses
(
	StoreHouseId int identity(1,1) primary key,
	Street varchar(50) not null,
	City varchar(50) not null,
	Voivodeship varchar(50) not null,
);

Create table StoresToStoreHouses
(
	StoreId int identity(1,1) foreign key references Stores(StoreId),
	StoreHouseId int identity(1,1) foreign key references StoreHouses(StoreHouseId),

	primary key(StoreId, StoreHouseId)
);

Create table ProductTypes
(
	TypeId int identity(1,1) primary key,
	Name varchar(30) not null
)

Create table Products
(
	ProductId int identity(1,1) primary key,
	Name varchar(100) not null,
	Description varchar(500) not null,
	ProductTypeId int foreign key references ProductTypes(TypeId),
	Price decimal not null,
);

create table OrderDetails
(
	OrderId int foreign key references Orders(OrderId),
	ProductId int foreign key references Products(ProductId),

	primary key(OrderId, ProductId)
);

Create table StoreHousesToProduct
(
	StoreHouseId int foreign key references StoreHouses(StoreHouseId),
	ProductId  int foreign key references Products(ProductId),

	primary key(StoreHouseId, ProductId)
)

Create table Discounts
(
	DiscountId int identity(1,1) primary key,
	Name varchar(100) not null,
	DateFrom date not null,
	DateTo date not null,
	StoreId int foreign key references Stores(StoreId),
	Value decimal not null
);


drop table Orders;
drop table Payments;
drop table Discounts;
drop table StoreHousesToProduct;
drop table OrderDetails;
drop table Products;
drop table ProductTypes;
drop table StoresToStoreHouses;
drop table StoreHouses;
drop table Stores;
drop table Customers;
drop table CustomerProfileDescriptions;