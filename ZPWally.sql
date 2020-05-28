DROP DATABASE IF EXISTS ZPWally;

CREATE DATABASE IF NOT EXISTS 
ZPWally;

USE ZPWally;

DROP TABLE IF EXISTS Branch;
CREATE TABLE Branch (
  BranchID varchar(45) NOT NULL,
  BranchName varchar(45),
  PRIMARY KEY (BranchID)
);

DROP TABLE IF EXISTS Customer;
CREATE TABLE Customer (
  CustomerID varchar(45) NOT NULL,
  FirstName varchar(45),
  LastName varchar(45),
  Telephone varchar(45),
  PRIMARY KEY (CustomerID)
);

DROP TABLE IF EXISTS Orders;
CREATE TABLE Orders (
  OrderID varchar(45) NOT NULL,
  OrderDate varchar(45),
  CustomerID varchar(45) NOT NULL,
  OrderStatus varchar(45),
  BranchID varchar(45) NOT NULL,
  PRIMARY KEY (OrderID),
  FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
  FOREIGN KEY (BranchID) REFERENCES Branch(BranchID)
);

DROP TABLE IF EXISTS Product;
CREATE TABLE Product (
  SKU varchar(45) NOT NULL,
  ProductName varchar(45),
  WholesalePrice varchar(45),
  PRIMARY KEY (SKU)
);

DROP TABLE IF EXISTS Inventory;
CREATE TABLE Inventory (
  BranchID varchar(45) NOT NULL,
  SKU varchar(45) NOT NULL,
  Quantity INT,
  PRIMARY KEY (BranchID, SKU),
  FOREIGN KEY (BranchID) REFERENCES Branch(BranchID),
  FOREIGN KEY (SKU) REFERENCES Product(SKU)
);

DROP TABLE IF EXISTS ProductOrder;
CREATE TABLE ProductOrder (
  OrderID varchar(45) NOT NULL,
  SKU varchar(45) NOT NULL,
  Quantity int,
  PRIMARY KEY(OrderID, SKU),
  FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
  FOREIGN KEY (SKU) REFERENCES Product(SKU)
);

INSERT INTO Branch(BranchID, BranchName) VALUES
('0001', 'Sports World'),
('0002', 'Waterloo'),
('0003', 'Cambridge Mall');

INSERT INTO Customer (CustomerID, FirstName, LastName, Telephone) VALUES
('26001', 'Carlo', 'Sgro', '519-555-0000'),
('26002', 'Norbert', 'Mika', '416-555-1111'),
('26003', 'Russell', 'Foubert', '519-555-2222'),
('26004', 'Sean', 'Clarke', '519-555-3333');

INSERT INTO Product(SKU, ProductName, WholesalePrice) VALUES
('314001', 'Disco Queen Wallpaper', 12.95),
('314002', 'Countryside Wallpaper ', 11.95),
('314003', 'Victorian Lace Wallpaper ', 14.95),
('314004', 'Drywall Tape', 3.95),
('314005', 'Drywall Tape x10',36.95),
('314006', 'Drywall Repair Compound ', 6.95);

INSERT INTO Orders(OrderID, OrderDate, CustomerID, OrderStatus, BranchID) VALUES
('360001', '09-20-2019', '26003', 'PAID', '0001'),
('360002', '10-06-2019', '26003', 'PAID', '0003'),
('360003', '11-02-2019', '26002', 'RFND', '0002');

INSERT INTO ProductOrder(OrderID, SKU, Quantity) VALUES
('360001', '314003', 4),
('360001', '314006', 1),
('360001', '314004', 2),
('360002', '314002', 10),
('360003', '314001', 12),
('360003', '314004', 3);

INSERT INTO Inventory(BranchID, SKU, Quantity) VALUES
('0001', '314001', 56),
('0001', '314002', 24),
('0001', '314003', 44),
('0001', '314004', 120),
('0001', '314005', 30),
('0001', '314006', 90),
('0002', '314001', 56),
('0002', '314002', 24),
('0002', '314003', 44),
('0002', '314004', 120),
('0002', '314005', 30),
('0002', '314006', 90),
('0003', '314001', 56),
('0003', '314002', 24),
('0003', '314003', 44),
('0003', '314004', 120),
('0003', '314005', 30),
('0003', '314006', 90);