/* For at indsætte dummy data i serveren*/

USE FastFoodServer

INSERT INTO [Status] VALUES ('Bestilt')
INSERT INTO [Status] VALUES ('Bekræftet')
INSERT INTO [Status] VALUES ('Ude til levering')
INSERT INTO [Status] VALUES ('Leveret')

INSERT INTO Accessories ([Name], Category, PriceOfItem) VALUES ('Skinke','burger','10')
INSERT INTO Accessories ([Name], Category, PriceOfItem) VALUES ('Skinke','pizza','10')
INSERT INTO Accessories ([Name], Category, PriceOfItem) VALUES ('Skinke','burger','10')
INSERT INTO Accessories ([Name], Category, PriceOfItem) VALUES ('Skinke','pizza','10')
INSERT INTO Accessories ([Name], Category, PriceOfItem) VALUES ('Skinke','pizza','10')
INSERT INTO Accessories ([Name], Category, PriceOfItem) VALUES ('Skinke','burger','10')

INSERT INTO Products VALUES ( 'Burger', 95, 'A burger', '1,2,3,4')
INSERT INTO Products VALUES ( 'Big Burger', 95, 'A burger', '1,2,3,4')
INSERT INTO Products VALUES ( 'Hello', 95, 'A burger', '1,2,3,4')
INSERT INTO Products VALUES ( 'Pizza', 95, 'A burger', '1,2,3,4')
INSERT INTO Products VALUES ( 'dwazxc', 95, 'A burger', '1,2,3,4')
INSERT INTO Products VALUES ( 'zxczxc', 95, 'A burger', '1,2,3,4')
INSERT INTO Products VALUES ( 'awdaw', 95, 'A burger', '1,2,3,4')
INSERT INTO Products VALUES ( 'xzc', 95, 'A burger', '1,2,3,4')
INSERT INTO Products VALUES ( 'dwadaw', 95, 'A burger', '1,2,3,4')
INSERT INTO Products VALUES ( 'zcxxzcxsa', 95, 'A burger', '1,2,3,4')

INSERT INTO Customers ([Address], LoginId)  VALUES ('Vardevej 12', 'dawadwd@hotmail.com') 
INSERT INTO Customers ([Address], LoginId)  VALUES ('Vardevej 1s2', 'daawdwd@hotmail.com' )
INSERT INTO Customers ([Address], LoginId)  VALUES ('Vardevej wa12', 'ddawdawd@hotmail.com')
INSERT INTO Customers ([Address], LoginId)  VALUES ('Vardevej 1212', 'aaaaawdwd@hotmail.com')

INSERT INTO Orders VALUES ( CURRENT_TIMESTAMP, 1, 3)
INSERT INTO Orders VALUES ( CURRENT_TIMESTAMP, 1, 2)
INSERT INTO Orders VALUES ( CURRENT_TIMESTAMP, 1, 1)
INSERT INTO Orders VALUES ( CURRENT_TIMESTAMP, 1, 1)

INSERT INTO OrderLines VALUES (1, 1, 2, 550, '1,2,3,3')
INSERT INTO OrderLines VALUES (1, 2, 2, 520, '1,2,3,3')
INSERT INTO OrderLines VALUES (1, 3, 2, 501, '1,2,3,3')
INSERT INTO OrderLines VALUES (2, 1, 2, 502, '1,2,3,3')
INSERT INTO OrderLines VALUES (2, 2, 2, 530, '1,2,3,3')
INSERT INTO OrderLines VALUES (3, 3, 2, 501, '1,2,3,3')
INSERT INTO OrderLines VALUES (4, 1, 2, 502, '1,2,3,3')
INSERT INTO OrderLines VALUES (4, 2, 2, 530, '1,2,3,3')
INSERT INTO OrderLines VALUES (4, 3, 2, 501, '1,2,3,3')
