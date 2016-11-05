CREATE DATABASE shoppingcart; 

go

USE shoppingcart; 

go 

CREATE TABLE role 
  ( 
     id   INT NOT NULL PRIMARY KEY IDENTITY, 
     NAME VARCHAR(255) 
  ); 

go 

CREATE TABLE [user] 
  ( 
     id          INT NOT NULL PRIMARY KEY IDENTITY, 
     username    NVARCHAR(255) NOT NULL, 
     NAME        NVARCHAR(255), 
     age         INT, 
     user_address     NVARCHAR(255),
     password    NVARCHAR(255), 
     phonenumber INT, 
     roleid      INT, 
     FOREIGN KEY (roleid) REFERENCES role(id)
	 ON DELETE CASCADE
  ); 

go 

CREATE TABLE [order] 
  ( 
     id     INT NOT NULL PRIMARY KEY IDENTITY, 
     status NVARCHAR(255) ,
     userid INT,
     FOREIGN KEY (userid) REFERENCES [user](id)
  ); 

go 

CREATE TABLE [brand]
(
	id       INT NOT NULL PRIMARY KEY IDENTITY,
	name     NVARCHAR(255)
)

CREATE TABLE [product] 
  ( 
     id          INT NOT NULL PRIMARY KEY IDENTITY, 
     NAME        NVARCHAR(255), 
     quantity    INT, 
     imageurl    NVARCHAR(255), 
     description NVARCHAR(255), 
     chip        NVARCHAR(255),
     ram         NVARCHAR(255),
     monitor     NVARCHAR(255),
     harddrive   NVARCHAR(255),
     power	 NVARCHAR(255),
     mainboard   NVARCHAR(255),
     vga         NVARCHAR(255), 
     cpu         NVARCHAR(255),
     brandid     INT,
     FOREIGN KEY (brandid) REFERENCES brand(id)
  ); 

go 

CREATE TABLE [orderproduct] 
  ( 
     orderid   INT NOT NULL, 
     productid INT NOT NULL, 
     createddate DATETIME, 
     updateddate DATETIME, 
     FOREIGN KEY (orderid) REFERENCES [order] (id), 
     FOREIGN KEY (productid) REFERENCES [product] (id) 
  ); 
go 

ALTER TABLE orderproduct 
  ADD CONSTRAINT orderproductid PRIMARY KEY (orderid, productid); 