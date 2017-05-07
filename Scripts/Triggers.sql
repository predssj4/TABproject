CREATE SEQUENCE [dbo].[identityInt] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 CACHE 
GO

--napisac wyzwalacz ktory bedzie korzystal z 
--sekwencji przed stawianiem nowego wiersza do tabeli


CREATE TRIGGER C_CustomerProfile ON CustomerProfileDescription
  for INSERT 
as
BEGIN
  SELECT CustomerProfileIdInt.nextval
    INTO :new.CustomerProfileDescId
    FROM dual;
END;



CREATE TRIGGER C_Customers
  BEFORE INSERT ON Customers
  FOR EACH ROW
BEGIN
  SELECT  CustomerIdInt.nextval
    INTO :new.CustomerProfileDescId
    FROM dual;
END;

CREATE TRIGGER C_Discounts
  BEFORE INSERT ON Discounts
  FOR EACH ROW
BEGIN
  SELECT DiscountIntId.nextval
    INTO :new.DiscountId
    FROM dual;
END;

CREATE TRIGGER C_OrderDetails
  BEFORE INSERT ON OrderDetails
  FOR EACH ROW
BEGIN
  SELECT OrderDetailsInt.nextval
    INTO :new.OrderId
		 :new.ProductId
    FROM dual;
END;

CREATE TRIGGER C_Orders
  BEFORE INSERT ON Orders
  FOR EACH ROW
BEGIN
  SELECT OrdersIdInt.nextval
    INTO :new.OrderId
    FROM dual;
END;

CREATE TRIGGER C_Payments
  BEFORE INSERT ON Payments
  FOR EACH ROW
BEGIN
  SELECT PaymentIdInt.nextval
    INTO :new.PaymentId
    FROM dual;
END;

CREATE TRIGGER C_Products
  BEFORE INSERT ON Products
  FOR EACH ROW
BEGIN
  SELECT ProductIdInt.nextval
    INTO :new.ProductId
    FROM dual;
END;

CREATE TRIGGER C_ProductTypes
  BEFORE INSERT ON ProductTypes
  FOR EACH ROW
BEGIN
  SELECT ProductTypesIdInt.nextval
    INTO :new.TypeId
    FROM dual;
END;

CREATE TRIGGER C_StoreHouses
  BEFORE INSERT ON StoreHouses
  FOR EACH ROW
BEGIN
  SELECT StoreHousesIdInt.nextval
    INTO :new.StoreHousesId
    FROM dual;
END;

CREATE TRIGGER C_StoreHousesToProduct
  BEFORE INSERT ON StoreHousesToProduct
  FOR EACH ROW
BEGIN
  SELECT StoreHousesToProductIdInt.nextval
    INTO :new.StoreHouseId
		 :new.ProductId
    FROM dual;
END;

CREATE TRIGGER C_Stores
  BEFORE INSERT ON Stores
  FOR EACH ROW
BEGIN
  SELECT StoresIdInt.nextval
    INTO :new.StoreId
    FROM dual;
END;

CREATE TRIGGER C_StoresToStoreHouses
  BEFORE INSERT ON StoresToStoreHouses
  FOR EACH ROW
BEGIN
  SELECT StoresToStoreHousesInt.nextval
    INTO :new.StoreId
		 :new.StoreHouseId
    FROM dual;
END;




create table sub1(
	pkey int primary key,
	descr varchar(100)
);

drop table sub1;

CREATE TRIGGER sub_trg
ON sub1
INSTEAD OF INSERT
AS
BEGIN

  DECLARE @new_super TABLE (
    super_id int
  );

  INSERT INTO super (subtype_discriminator)
  OUTPUT INSERTED.super_id INTO @new_super (super_id)
  SELECT 'SUB1' FROM INSERTED;

  INSERT INTO sub1 (super_id)
  SELECT super_id FROM @new_super;
END;

drop trigger sub_trg;

insert into sub1(descr)
values('dddd');


CREATE TRIGGER myTriggerINSERT
ON sub1
FOR INSERT
AS
begin

	DECLARE @ID int, @Name nvarchar(30), @idToPrint int

	 print @@identity;

	 idToPrint = select * from sub1;
end;

drop trigger myTriggerINSERT;

insert into sub1(pkey, descr)
values(2,'dddd');


