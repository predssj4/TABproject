--wstawienie warto�ci do tabel  
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
('Got�wka'),
('Przelew'),
('PayPal');



GO

insert into dbo.Customers (Name, LastName, BirthDate, Address, Gender)
values
('Adam', 'Kurek', '1995-02-22', Bia�ystok, Male),
('Pawe�', 'Kubacki', '1975-12-12', Bia�owie�a, Male),
('Aleksandra', 'Barcka', '1977-07-21', P�ock, Frmale),
('Marcin', 'Fr�czak', '1995-02-22', Piotrk�w, Male),
('Piotr', 'Adamik', '1995-02-22', Warszawa, Male),
('Krzysztof', 'Rejtam', '1995-02-22', Gra�sk, Male),
('Emil', 'Kopik', '1995-02-22', Choroszcz, Male),
('Natalia', 'Mro�ek', '1995-02-22', Wroc�aw, Female),
('Dorota', 'Plecha', '1995-02-22', Zakopane, Female),
('Bartosz', 'Robert', '1995-02-22', Cz�stochowa, Male);

Go

insert into dbo.Disconts (Name, DateFrom, DateTo, Value)
values
('Rabat','2017-06-20','2017-06-30', 0.3),
('Promocja','2017-07-20','2017-07-30', 0.2),
('Rabat','2017-10-20','2017-10-30', 0.13),
('Promocja','2017-06-10','2017-06-30', 0.22),
('Zni�a','2017-02-06','2017-02-29', 0.03),
('Rabat','2017-12-20','2017-12-30', 0.23),
('Promocja','2017-10-20','2017-10-30', 0.36),
('Rabat','2017-02-06','2017-04-20', 0.4),
('Rabat','2017-12-06','2017-12-12', 0.33),
('Promocja','2017-11-11','2017-11-30', 0.55)

Go

Insert into dbo.Stores (Name, Street, City, Voivodeship)
values
('Biedronka', 'Pozna�ska', 'Warszawa', 'Mazowieckie'),
('Lidl', 'Mruczy�ska', 'Suwa�ki', 'Podlaskie'),
('�abka', 'Lubelska', 'Bia�ystok', 'Podlaskie'),
('Kaufland', 'Epicka', 'Cz�stochowa', 'Ma�opolskie'),
('Netto', 'Kunicka', 'Pruszk�w', 'Mazowieckie'),
('Biedronka', 'Olsztynska', 'Olsztyn', '�l�skie'),
('Lidl', 'Elpicka', 'E�k', 'Kujawsko-Pomorskie'),
('Chorten', 'Mazowiecka', 'Krak�w', 'Warmi�sko-Mazurskie'),
('Piotr i Pawe�', 'Lublanska', 'P�ock', 'Mazowieckie'),
('Biedronka', 'Egipska', 'Warszawa', 'Mazowieckie')

Go

insert into dbo.StoreHouses (Street, City, Voivodeship)
values
('R�a�ska', 'P�ock', 'Kujawsko-Pomorskie'),
('Kruszczy�ska', 'Warszawa', 'Mazowieckie'),
('Pociecka', 'Pozna�', 'Podlaskie'),
('Lubla�ska', 'Lublin', '�l�skie'),
('Rzymska', 'Opole', 'Dolno�l�skie'),
('Kurmanska', 'Sopot', 'Pomorskie'),
('Egoiska', 'Toru�', '��dzkie'),
('Werytanska', 'Radom', 'Ma�opolskie'),
('Adamska', 'Suwa�ki', 'Wielkopolskie'),
('Departamencka', 'Warszawa', 'Lubiskie')

Go

insert into dbo.ProductTypes (Name)
values
('Nabia�'),
('S�odycze'),
('Produkty Zbo�owe'),
('Mi�so,W�dliny,Ryby'),
('Jaja'),
('Ziemniaki'),
('Cukier i S�odycze'),
('Warzywa i Owoce'),
('Suche nasiona ro�lin straczkowych'),
('Inne t�uszcze')

Go

insert into dbo.Products (Name, Description, Price)
values
('Kasza J�czmienna', 'Bez glutenu', 2.50),
('Makaron', 'Ciemny', 3.40),
('�oso�', '�wie�y', 2.70),
('D�em', 'Wi�niowy', 2.80),
('Mas�o', 'Ma�lane', 4.50),
('Miruna', 'Z Morza p�nocnego', 5.20),
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
--(next value for [dbo].[PaymentIdInt] ,'Got�wka'),
--(next value for [dbo].[PaymentIdInt], 'Przelew'),
--(next value for [dbo].[PaymentIdInt], 'PayPal');
--przyklad jak zastosowac wlasne sekwencje podczas wstawiania rekordow
--nalezy tez usunac identity(1,1) z tabeli przed wstawieniem i dodac Id przed Description
-- w nawiasnie
