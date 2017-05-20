USE predssj4_tab123
GO

CREATE PROCEDURE dbo.addProduct 
@Name varchar(100),
@Description varchar(500),
@ProductTypeId int,
@Price decimal(18,2)
AS

BEGIN
	IF @Price >= 100
		throw 510000, 'Cena nie moze byc wieksza niz 100 zl', @Price;

	IF NOT EXISTS (select 1 from dbo.ProductTypes where TypeId = @ProductTypeId)
		throw 51000, 'Nie ma takiego produktu', @ProductTypeId;


	insert into dbo.Products(Name, Description, ProductTypeId, Price)
	values (@Name, @Description, @ProductTypeId, @Price)
END;

--DROP procedure dbo.addProduct;
--EXEC dbo.addProduct @Name= 'Keczup Inny', @Description = 'Domowy', @ProductTypeId = 3, @Price = 3.32;

GO

CREATE PROCEDURE dbo.deleteProduct 
@productId int
AS
BEGIN

	IF NOT EXISTS (select 1 from dbo.Products  where ProductId = @productId)
		throw 51000, 'Nie ma takiego produktu', @productId;

	delete from dbo.Products
	where productId = @productId;

END;

GO

CREATE PROCEDURE dbo.editProduct
@Id int,
@Name varchar(100),
@Description varchar(500),
@ProductTypeId int,
@Price decimal(18,2)
AS

BEGIN
	IF NOT EXISTS (select 1 from dbo.Products where ProductId = @Id)
		THROW 510000, 'Produkt nie istnieje', @Id

	IF @Price >= 100
		throw 510000, 'Cena nie moze byc wieksza niz 100 zl', @Price;

	IF NOT EXISTS (select 1 from dbo.ProductTypes where TypeId = @ProductTypeId)
		throw 51000, 'Nie ma takiego produktu', @ProductTypeId;


	update dbo.Products
	set Name = @Name, Description = @Description, ProductTypeId =@ProductTypeId, Price = @Price
	where ProductId = @Id;

END;

GO

CREATE PROCEDURE dbo.getProductDetails
@Id int
AS
BEGIN
	
	Declare @rowNumber int;
	Set @rowNumber = (select count(productId) from OrderDetails where productId = @Id);
	Print @rowNumber;

	select  prod.ProductId,
			prod.Name,
			prod.Description,
			prod.ProductTypeId,
			prod.Price,
			(@rowNumber*prod.Price) as OrdersSum,
			@rowNumber as AmountOfOrders,
			(select typ.Name
			 from dbo.ProductTypes typ
			 where typ.TypeId = prod.ProductTypeId) as ProductType
	from dbo.Products prod
	where prod.ProductId = @Id
	
END;

--drop procedure dbo.getProductDetails

GO

CREATE PROCEDURE dbo.getProduct
@Id int
AS
BEGIN

	IF NOT EXISTS (select 1 from dbo.Products  where ProductId = @Id)
		throw 51000, 'Nie ma takiego produktu', @Id;

	Select *
	from dbo.Products
	where ProductId = @Id;

END;
--drop procedure dbo.getProduct

GO

CREATE PROCEDURE dbo.getProducts
AS
BEGIN
	SELECT prod.ProductId, prod.Name, prod.Description, prod.productTypeId, prod.Price, pt.Name
	FROM dbo.Products prod
	LEFT OUTER JOIN dbo.ProductTypes pt ON prod.ProductTypeId = pt.TypeID

END;

GO

CREATE PROCEDURE dbo.getStoresIncome
As
BEGIN
	
	SELECT st.StoreId, st.Name, ISNULL(sum(prod.Price), 0) as Income
	FROM dbo.Stores st
	left outer join dbo.orders ord ON st.StoreId = ord.StoreId
	left outer join dbo.OrderDetails det ON ord.OrderId = det.OrderId
	left outer join dbo.Products prod ON det.ProductId = prod.ProductId
	GROUP BY st.StoreId, st.Name

END;

--drop procedure dbo.getstoresincome

GO

CREATE PROCEDURE dbo.getIncomeDetailsForStore
@Id int
AS
BEGIN
	SELECT od.OrderId, prod.Name, prod.Price
	FROM dbo.OrderDetails od
	LEFT OUTER JOIN dbo.Orders ord ON od.OrderId = ord.OrderId
	LEFT OUTER JOIN dbo.Stores st ON ord.StoreId = st.StoreId
	LEFT OUTER JOIN dbo.Products prod ON od.ProductId = prod.ProductId

	WHERE ST.StoreId = @id

END;


--drop procedure dbo.getIncomeDetailsForStore

GO

CREATE PROCEDURE dbo.GetStores
As
BEGIN
	SELECT st.StoreId,
			st.Name,
			st.Street,
			st.City,
			st.voivodeship, 
			(select count(sh.StoreHouseId)
			from [dbo].[StoresToStoreHouses] sh
			where sh.StoreId = st.StoreId ) as AmountOfStoreHouses

	FROM dbo.Stores st
END;
GO

CREATE PROCEDURE dbo.addStore
@Name varchar(30),
@Street varchar(100),
@City varchar(50),
@Voivodeship varchar(50)
AS

BEGIN

	IF EXISTS (select 1 from dbo.Stores  where Name = @Name and Street = @Street and City = @City)
		throw 51000, 'Taki sklep ju¿ istnieje', @Name;

	Insert into dbo.Stores (Name, Street, City, Voivodeship)
	values (@Name, @Street, @City, @Voivodeship)

END;

GO

CREATE PROCEDURE dbo.bindStoreHouseToStore
@StoreId int,
@StoreHouseId int
AS
BEGIN
	IF NOT EXISTS (select 1 from dbo.Stores  where StoreId = @StoreId)
		throw 51000, 'Nie ma sklepu o podanym ID', 999;

	IF NOT EXISTS (select 1 from dbo.StoreHouses  where StoreHouseId = @StoreHouseId)
		throw 51000, 'Nie ma sklepu o podanym ID', 995;

	IF EXISTS (select 1 from dbo.StoresToStoreHouses where StoreHouseId = @StoreHouseId and StoreId = @StoreId)
		throw 51000, 'Powi¹zanie ju¿ istnieje', 1;

	INSERT INTO dbo.StoresToStoreHouses (StoreId, StoreHouseId)
	values (@StoreId, @StoreHouseId)

END;

--drop procedure dbo.bindStoreHouseToStore

GO

--drop procedure dbo.addDiscount
CREATE PROCEDURE dbo.addDiscount
@Name varchar(100),
@DateFrom date,
@DateTo date,
@Value decimal(4,2)
AS
BEGIN
	IF EXISTS (select 1 from dbo.Discounts
			   where dateFrom < @dateFrom and DateTo > @DateTo
			   )
		throw 51000, 'W danym okresie mo¿e istnieæ tylko jedna promocja', 1;

	INSERT INTO dbo.Discounts (Name, DateFrom, DateTo, Value)
	values (@Name, @DateFrom, @DateTo, @Value)

END;

GO

CREATE PROCEDURE dbo.getProductTypes
AS
BEGIN
	SELECT TypeId, Name
	FROM dbo.ProductTypes
END;

GO