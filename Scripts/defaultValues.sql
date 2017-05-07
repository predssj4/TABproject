--wstawienie wartoœci do tabel  
--trzeba dodac godzine do orders a nie tylko date
--zwrocic uwage ze nie ma srednikow po kazdej tabeli - wykona sie wszystko na raz
--na poczatku nalezy dodawac wartosci do slownikow np Payment, ProductType

insert into db.Orders (CustomerId, StoreId, OrderDate)
values
(1,1,1,'15:12'),
(2,2,2,'12:22'),
(3,3,3,'22:21'),
(4,4,4,'13:24'),
(5,5,5,'15:40'),
(6,6,6,'10:10'),
(7,7,7,'06:23'),
(8,8,8,'05:22'),
(9,9,9,'23:50'),
(10,10,10,'21:21')

GO

insert into [dbo].[Payments] (Description)
values 
('Gotówka'),
('Przelew'),
('PayPal');



GO

insert into dbo.Customers (Name, LastName, BirthDate, Address, Gender)
values
('Adam', 'Kurek', '1995-02-22', Bia³ystok, Male),
('Pawe³', 'Kubacki', '1975-12-12', Bia³owie¿a, Male),
('Aleksandra', 'Barcka', '1977-07-21', P³ock, Frmale),
('Marcin', 'Fr¹czak', '1995-02-22', Piotrków, Male),
('Piotr', 'Adamik', '1995-02-22', Warszawa, Male),
('Krzysztof', 'Rejtam', '1995-02-22', Grañsk, Male),
('Emil', 'Kopik', '1995-02-22', Choroszcz, Male),
('Natalia', 'Mro¿ek', '1995-02-22', Wroc³aw, Female),
('Dorota', 'Plecha', '1995-02-22', Zakopane, Female),
('Bartosz', 'Robert', '1995-02-22', Czêstochowa, Male);

Go

insert into dbo.Disconts (Name, DateFrom, DateTo, Value)
values
('Rabat','2017-06-20','2017-06-30', 0.3),
('Promocja','2017-07-20','2017-07-30', 0.2),
('Rabat','2017-10-20','2017-10-30', 0.13),
('Promocja','2017-06-10','2017-06-30', 0.22),
('Zni¿a','2017-02-06','2017-02-29', 0.03),
('Rabat','2017-12-20','2017-12-30', 0.23),
('Promocja','2017-10-20','2017-10-30', 0.36),
('Rabat','2017-02-06','2017-04-20', 0.4),
('Rabat','2017-12-06','2017-12-12', 0.33),
('Promocja','2017-11-11','2017-11-30', 0.55)

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
('Suche nasiona roœlin straczkowych'),
('Inne t³uszcze')

Go

insert into dbo.Products (Name, Description, Price)
values
('Kasza Jêczmienna', 'Bez glutenu', 2.50),
('Makaron', 'Ciemny', 3.40),
('£osoœ', 'Œwie¿y', 2.70),
('D¿em', 'Wiœniowy', 2.80),
('Mas³o', 'Maœlane', 4.50),
('Miruna', 'Z Morza pó³nocnego', 5.20),
('Czekolada', 'Wedel', 4.99),
('Serek Danio', 'Bez GMO', 1.90),
('Proszek', 'Vizir', 21.12),
('Olej', 'Kujawski', 7.85)

Go

insert into dbo.CustomerProfileDescriptiosn (Description)
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



--insert into [dbo].[Payments] (PaymentId, Description)
--values 
--(next value for [dbo].[PaymentIdInt] ,'Gotówka'),
--(next value for [dbo].[PaymentIdInt], 'Przelew'),
--(next value for [dbo].[PaymentIdInt], 'PayPal');
--przyklad jak zastosowac wlasne sekwencje podczas wstawiania rekordow
--nalezy tez usunac identity(1,1) z tabeli przed wstawieniem i dodac Id przed Description
-- w nawiasnie
