create table [dbo].Payments
(
	PaymentId int  identity(1,1) primary key,
	Description varchar(1000)
);

create table [dbo].Orders
(
	OrderId int identity(1,1) primary key,
	CustomerId int not null,
	StoreId int not null,
	PaymentId int foreign key references Payments(PaymentId),
	OrderDate date not null	
);

create table [dbo].CustomerProfileDescriptions
(
	CustomerProfileDescId int identity(1,1) primary key,
	Description varchar(250) not null
);

create table [dbo].Customers
(
	CustomerId int identity(1,1) primary key,
	Name varchar(50) not null,
	LastName varchar(50) not null,
	BirthDate date not null,
	Address varchar(100) not null,
	Gender varchar(2) not null,
	CustomerProfileDescriptionId int foreign key references CustomerProfileDescriptions(CustomerProfileDescId) on delete cascade
);


Create table [dbo].Stores
(
	StoreId int identity(1,1) primary key,
	Name varchar(100) not null,
	Street varchar(50) not null,
	City varchar(50) not null,
	Voivodeship varchar(50) not null,
);

Create table [dbo].StoreHouses
(
	StoreHouseId int identity(1,1) primary key,
	Street varchar(50) not null,
	City varchar(50) not null,
	Voivodeship varchar(50) not null,
);

Create table [dbo].StoresToStoreHouses
(
	StoreId int foreign key references Stores(StoreId),
	StoreHouseId int foreign key references StoreHouses(StoreHouseId),

	primary key(StoreId, StoreHouseId)
);

Create table [dbo].ProductTypes
(
	TypeId int identity(1,1) primary key,
	Name varchar(30) not null
)

Create table [dbo].Products
(
	ProductId int identity(1,1) primary key,
	Name varchar(100) not null,
	Description varchar(500) not null,
	ProductTypeId int foreign key references ProductTypes(TypeId),
	Price decimal not null,
);

create table [dbo].OrderDetails
(
	OrderId int foreign key references Orders(OrderId),
	ProductId int foreign key references Products(ProductId),
	primary key(OrderId, ProductId)
);

Create table [dbo].StoreHousesToProduct
(
	StoreHouseId int foreign key references StoreHouses(StoreHouseId),
	ProductId  int foreign key references Products(ProductId),

	primary key(StoreHouseId, ProductId)
)

Create table [dbo].Discounts
(
	DiscountId int identity(1,1) primary key,
	Name varchar(100) not null,
	DateFrom date not null,
	DateTo date not null,
	Value decimal(4,2) not null
);


--drop table [dbo].Payments;
--drop table [dbo].Orders;
--drop table [dbo].Discounts;
--drop table [dbo].StoreHousesToProduct;
--drop table [dbo].OrderDetails;
--drop table [dbo].ProductTypes;
--drop table [dbo].Products;
--drop table [dbo].StoresToStoreHouses;
--drop table [dbo].StoreHouses;
--drop table [dbo].Stores;
--drop table [dbo].Customers;
--drop table [dbo].CustomerProfileDescriptions;