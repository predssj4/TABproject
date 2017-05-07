insert into [dbo].[Payments] (Description)
values 
('Gotówka'),
('Przelew'),
('PayPal');

GO

insert into [dbo].Customers (Name, LastName, BirthDate, Address, Gender, CustomerProfileDescriptionId)
values
('Adam', 'Kurek', '1995-02-22', 'Bia³ystok', 'M',1),
('Pawe³', 'Kubacki', '1975-12-12', 'Bia³owie¿a', 'M',2),
('Aleksandra', 'Barcka', '1977-07-21', 'P³ock', 'F',3),
('Marcin', 'Fr¹czak', '1995-02-22', 'Piotrków', 'M',4),
('Piotr', 'Adamik', '1995-02-22', 'Warszawa', 'M',5),
('Krzysztof', 'Rejtam', '1995-02-22', 'Grañsk', 'M',6),
('Emil', 'Kopik', '1995-02-22', 'Choroszcz', 'M',7),
('Natalia', 'Mro¿ek', '1995-02-22','Wroc³aw', 'F',8),
('Dorota', 'Plecha', '1995-02-22', 'Zakopane', 'F',9),
('Bartosz', 'Robert', '1995-02-22', 'Czêstochowa', 'M',10);

GO

insert into dbo.CustomerProfileDescriptions (Description)
values
('Opis1'),
('Opis2'),
('Opis3'),
('Opis4'),
('Opis5'),
('Opis6'),
('Opis7'),
('Opis8'),
('Opis9'),
('Opis10')

Go

Insert into dbo.Stores (Name, Street, City, Voivodeship)
values
('Biedronka', 'Poznañska', 'Warszawa', 'Mazowieckie'),
('Lidl', 'Mruczyñska', 'Suwa³ki', 'Podlaskie'),
('¯abka', 'Lubelska', 'Bia³ystok', 'Podlaskie'),
('Kaufland', 'Epicka', 'Czêstochowa', 'Ma³opolskie'),
('Netto', 'Kunicka', 'Pruszków', 'Mazowieckie'),
('Biedronka', 'Olsztynska', 'Olsztyn', 'Œl¹skie'),
('Lidl', 'Elpicka', 'E³k', 'Kujawsko-Pomorskie'),
('Chorten', 'Mazowiecka', 'Kraków', 'Warmiñsko-Mazurskie'),
('Piotr i Pawe³', 'Lublanska', 'P³ock', 'Mazowieckie'),
('Biedronka', 'Egipska', 'Warszawa', 'Mazowieckie')

GO

insert into [dbo].Discounts (Name, DateFrom, DateTo, Value)
values
('Rabat',	'2017-06-20','2017-06-30', 0.3),
('Promocja','2017-07-20','2017-07-30', 0.2),
('Rabat',	'2017-10-20','2017-10-30', 0.13),
('Promocja','2017-06-10','2017-06-30', 0.22),
('Zni¿ka',	'2017-02-06','2017-02-27', 0.03),
('Rabat',	'2017-12-20','2017-12-30', 0.23),
('Promocja','2017-10-20','2017-10-30', 0.36),
('Rabat',	'2017-02-06','2017-04-20', 0.4),
('Rabat',	'2017-12-06','2017-12-12', 0.33),
('Promocja','2017-11-11','2017-11-30', 0.55)

Go



insert into dbo.StoreHouses (Street, City, Voivodeship)
values
('Ró¿añska', 'P³ock', 'Kujawsko-Pomorskie'),
('Kruszczyñska', 'Warszawa', 'Mazowieckie'),
('Pociecka', 'Poznañ', 'Podlaskie'),
('Lublañska', 'Lublin', 'Œl¹skie'),
('Rzymska', 'Opole', 'Dolnoœl¹skie'),
('Kurmanska', 'Sopot', 'Pomorskie'),
('Egoiska', 'Toruñ', '£ódzkie'),
('Werytanska', 'Radom', 'Ma³opolskie'),
('Adamska', 'Suwa³ki', 'Wielkopolskie'),
('Departamencka', 'Warszawa', 'Lubiskie')

Go

insert into dbo.ProductTypes (Name)
values
('Nabia³'),
('S³odycze'),
('Produkty Zbo¿owe'),
('Miêso,Wêdliny,Ryby'),
('Jaja'),
('Ziemniaki'),
('Cukier i S³odycze'),
('Warzywa i Owoce'),
('Suche nasiona roœlin str.'),
('Inne t³uszcze')

Go

insert into dbo.Products (Name, Description, ProductTypeId, Price)
values
('Kasza Jêczmienna' ,'Bez glutenu'			,3, 2.50),
('Makaron'			,'Ciemny'				,3, 3.40),
('£osoœ'			, 'Œwie¿y'				,4, 2.70),
('D¿em'				, 'Wiœniowy'			,7, 2.80),
('Mas³o'			, 'Maœlane'				,1, 4.50),
('Miruna'			, 'Z Morza pó³nocnego'	,8, 5.20),
('Czekolada'		, 'Wedel'				,7, 4.99),
('Serek Danio'		, 'Bez GMO'				,1, 1.90),
('M¹ka'				, '¯ytnia'				,3, 21.12),
('Olej'				, 'Kujawski'			,10, 7.85)

Go

insert into [dbo].Orders (CustomerId, StoreId, OrderDate, PaymentId)
values
(1,1,'2017-03-02', 1),
(2,2,'2017-03-03', 2),
(3,3,'2017-03-04', 1),
(4,4,'2017-03-05', 1),
(5,5,'2017-03-06', 3),
(6,6,'2017-03-07', 1),
(7,7,'2017-03-08', 2),
(8,8,'2017-03-09', 2),
(9,9,'2017-03-10', 3),
(10,10,'2017-03-11',1)

Go

insert into [dbo].StoreHousesToProduct(StoreHouseId,ProductId)
values
(1,2),(1,4),(1,5),(4,2),(4,4),(4,7),(2,2),(4,9),(2,8),(3,1),(3,2),
(3,3),(3,4),(5,1),(5,2),(5,6),(5,7),(5,8),(5,9),(6,5),(6,4),(6,3),
(6,2),(6,1),(7,2),(7,6),(7,7),(7,8),(7,9)

GO

insert into [dbo].OrderDetails(OrderId, ProductId)
values
(1, 3),(1, 7),
(2, 3), (2, 7), (2, 8),
(3, 3), (3, 7), (3, 8), (3, 5), (3, 6), (3, 9),
(4, 3), (4, 7), (4, 8),
(5, 3), (5, 4), (5, 10),
(6, 1), (6, 2), (6, 6),
(7, 3), (7, 7), 
(8, 5), (8, 9), (8, 1),
(9, 5), (9, 2), (9, 8),
(10, 3), (10, 7), (10, 8)

GO

insert into [dbo].StoresToStoreHouses(StoreId, StoreHouseId)
values
(1, 3),(1, 7),
(2, 3), (2, 7), (2, 8),
(3, 3), (3, 7), (3, 8), (3, 5), (3, 6), (3, 9),
(4, 3), (4, 7), (4, 8),
(5, 3), (5, 4), (5, 10),
(6, 1), (6, 2), (6, 6),
(7, 3), (7, 7), 
(8, 5), (8, 9), (8, 1),
(9, 5), (9, 2), (9, 8),
(10, 3), (10, 7), (10, 8)