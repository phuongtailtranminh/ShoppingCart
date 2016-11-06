CREATE DATABASE shoppingcart;

go

USE shoppingcart;

go

CREATE TABLE [role]
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
     [password]    NVARCHAR(255),
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
     [power]	 NVARCHAR(255),
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
go
INSERT INTO brand(name) VALUES ('Dell');
go
INSERT INTO brand(name) VALUES ('HP');
go
INSERT INTO brand(name) VALUES ('ASUS');
go
INSERT INTO brand(name) VALUES ('ACER');
go
INSERT INTO brand(name) VALUES ('APPLE');
go

INSERT INTO Product(name, quantity, imageurl, description, chip, ram, monitor, harddrive, power, mainboard, vga, cpu, brandid) 
values ('Dell Inspiron 5559 Laptop', 10, '#', 'Dell Inspiron 5559 Laptop Description', 'Intel Core i3 (6th Gen)', '4 GB DDR3 RAM', '15.6 inches, 1366 x 768 pixels Screen
', '1 TB Hard Disk', '450W', 'Intel', 'Intel HD Graphics 520', 'Intel Core i3 (6th Gen)', 1);
go
INSERT INTO Product(name, quantity, imageurl, description, chip, ram, monitor, harddrive, power, mainboard, vga, cpu, brandid) 
values ('Dell Inspiron 3558 Notebook', 10, '#', 'Dell Inspiron 3558 Notebook Description', 'Intel Core i3 (5th Gen)', '4 GB DDR3 RAM', '15.6 inches, 1366 x 768 pixels Screen
', '1 TB Hard Disk', '450W', 'Intel', 'Intel HD Graphics 5500', 'Intel Core i3 (5th Gen)', 1);
go
INSERT INTO Product(name, quantity, imageurl, description, chip, ram, monitor, harddrive, power, mainboard, vga, cpu, brandid) 
values ('Dell Inspiron 3162', 10, '#', 'Dell Inspiron 3162 Description', 'Intel Celeron Dual Core', '2 GB DDR3 RAM', '11.6 inches, 1366 x 768 pixels Screen
', '500GB Hard Disk', '450W', 'Intel', 'Intel HD Graphics 5500', 'Intel Celeron Dual Core', 1);
go
INSERT INTO Product(name, quantity, imageurl, description, chip, ram, monitor, harddrive, power, mainboard, vga, cpu, brandid) 
values ('Dell Inspiron 3542 Laptop', 10, '#', 'Dell Inspiron 3542 Laptop Description', 'Intel Celeron Dual Core (4th Gen)', '4 GB DDR3 RAM', '15.6 inches, 1366 x 768 pixels, Touch Screen
', '500GB Hard Disk', '450W', 'Intel', 'Intel HD Graphics', 'Intel Celeron Dual Core (4th Gen)', 1);
go
INSERT INTO Product(name, quantity, imageurl, description, chip, ram, monitor, harddrive, power, mainboard, vga, cpu, brandid) 
values ('Dell Inspiron 5000 5558 Notebook', 10, '#', 'Dell Inspiron 5000 5558 Notebook Description', 'Intel Core i5', '8 GB DDR3 RAM', '15.6 inches, 1920 x 1080 pixels Screen
', '1 TB Hard Disk', '450W', 'Intel', '4 GB NVIDIA Graphics Card', 'Intel Core i5', 1);
