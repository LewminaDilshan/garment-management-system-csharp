create database GarmentDB
use GarmentDB
create table Supplier (
sup_id varchar(10) PRIMARY KEY NOT NULL,
sup_name varchar(50) NOT NULL,
sup_add varchar(150) NOT NULL,
sup_email varchar(50) NOT NULL,
sup_cont varchar(15) NOT NULL
)

INSERT INTO Supplier VALUES('S1', 'Kasun', 'Nugegoda', 'kasun123@gmail.com','0772123123');
select * from Supplier

CREATE TABLE supplier_items(
item_id varchar(10) NOT NULL,
sup_id varchar(10) NOT NULL,
PRIMARY KEY(item_id,sup_id), 
item_type varchar(150) NOT NULL
)

Insert INTO supplier_items VALUES('I1','S1','Buttons')

CREATE TABLE purchase_master (
pur_id varchar(10) PRIMARY KEY NOT NULL,
sup_id varchar(10),
pur_date date NOT NULL,
pur_status varchar(20) NOT NULL,
pur_total varchar(20) NULL,
pur_resv_status varchar(20) NULL
)

CREATE TABLE purchase_details(
pd_id varchar(10) NOT NULL,
pur_id varchar(10) NOT NULL,
PRIMARY KEY(pd_id,pur_id), 
pd_Item_type varchar(20) NOT NULL,
Size varchar(20) NULL,
color varchar(20) NULL,
pd_qty varchar(20) NOT NULL,
pd_Item_price varchar(20) NULL,
pd_Item_Status varchar(20) NULL
)

--drop table purchase_details

INSERT INTO purchase_master VALUES('PM10', 'S1', '2019.03.01', 'Pending','50000','Recieved');

INSERT INTO purchase_details VALUES('PD2', 'PM2', 'Leather', '1 cm', 'Black', '400','7000','Added to stock');

select * from purchase_master
select * from purchase_details

CREATE TABLE Sales_master (
sale_id varchar(10) PRIMARY KEY NOT NULL,
clt_id varchar(10),
sale_date date NOT NULL,
sale_total varchar(20) NULL,
sale_status varchar(20) NOT NULL,
sale_Deliv_status varchar(20) NULL
)

CREATE TABLE Sales_details(
sd_id varchar(10) NOT NULL,
sale_id varchar(10) NOT NULL,
PRIMARY KEY(sd_id,sale_id), 
sd_Product varchar(20) NOT NULL,
Item_id varchar(10) NOT NULL,
DesignId varchar(10) NOT NULL,
PSizeId varchar(10) NOT NULL,
fabricId varchar(10) NOT NULL,
brandId varchar(10) NOT NULL,
sd_qty varchar(20) NOT NULL,
sd_Product_price varchar(20) NULL,
)

INSERT INTO Sales_master VALUES('SM4', 'C3', '2019.03.01','100000', 'Pending','Not Delivered');

INSERT INTO Sales_details VALUES('SD1', 'SM1', 'Shirts', 'I1','D1','PS1','F1','B1','200','75000');


select * from Sales_details
select * from Sales_master

CREATE TABLE Stock_Product(
Pro_id varchar(10) PRIMARY KEY NOT NULL,
Product_Type varchar(20) NOT NULL, 
Size varchar(20) NOT NULL,
Color varchar(20) NOT NULL,
Fabric_Type varchar(20) NOT NULL,
Quantity varchar(15) NOT NULL,
Descriptions varchar(250) NOT NULL,
Price varchar(25) NULL,
Damage_Status varchar(20) NULL
)

--drop table Product

CREATE TABLE Stock_Materials(
Mat_id varchar(10) PRIMARY KEY NOT NULL,
Material_Type varchar(20) NOT NULL, 
Size varchar(20) NULL,
Color varchar(20) NULL,
Quantity varchar(15) NOT NULL,
Descriptions varchar(250) NOT NULL,
Damage_Status varchar(20) NULL
)

INSERT INTO Stock_Product VALUES('PRO1', 'T-Shirt','Toque','Plain', '16.5 inch', 'Blue','Cotton','200','Collarless/Slim-Fit', 'Rs. 1500/= (Per Item)','Not Damaged');
INSERT INTO Stock_Materials VALUES('MAT1', 'Button', '1 cm', 'Black','150','with 3 holes','Not Damaged');


CREATE TABLE Stock_Product(
Pro_id varchar(10) PRIMARY KEY NOT NULL,
Product_Type varchar(20) NOT NULL,
Brand varchar(30) NOT NULL,
Design varchar(50) NOT NULL, 
Size varchar(20) NOT NULL,
Color varchar(20) NOT NULL,
Fabric_Type varchar(20) NOT NULL,
Quantity varchar(15) NOT NULL,
Descriptions varchar(250) NOT NULL,
Price varchar(25) NULL,
Damage_Status varchar(20) NULL
)
/*
CREATE TABLE Products(

MarkupCost varchar(25) NULL,
SalesPrice varchar(25) NULL,

)

INSERT INTO Products VALUES('I1', 'T-Shirt','Cotton','Toque','Plain', '16.5 inch', 'Blue','Collarless/Slim-Fit', '1000','1.2','2200','Send To Accountant');
*/

CREATE TABLE Brand(
brandId varchar(10) PRIMARY KEY NOT NULL,
brandName varchar(30) NOT NULL,
brandPrice nchar(8) NOT NULL,
CurrentStatus varchar(20) NULL
)

INSERT INTO Brand VALUES('B5', 'ANDRE(Mens Collection)', '400', 'NOT CHANGED');

CREATE TABLE FabricType(
fabricId varchar(10) PRIMARY KEY NOT NULL,
fabricType varchar(30) NOT NULL,
fabricPrice nchar(8) NOT NULL,
CurrentStatus varchar(20) NULL
)

INSERT INTO FabricType VALUES('F4', 'Fabric(LINEN)', '650', 'NOT CHANGED');

CREATE TABLE Product(
Item_id varchar(10) PRIMARY KEY NOT NULL,
ProductName varchar(30) NULL,
productPrice nchar(8) NOT NULL,
CurrentStatus varchar(20) NULL
)

INSERT INTO Product VALUES('P9', 'Baby Grow', '600', 'NOT CHANGED');

CREATE TABLE ProductSize(
PSizeId varchar(10) PRIMARY KEY NOT NULL,
ItemType varchar(10) NOT NULL,
ProductSize varchar(10) NOT NULL,
sizePrice nchar(8) NOT NULL,
CurrentStatus varchar(20) NULL
)

INSERT INTO ProductSize VALUES('PS28', 'Baby Grow', 'Medium', '100', 'NOT CHANGED');

CREATE TABLE Design(
DesignId varchar(10) Primary Key NOT NULL,
ItemType varchar(10) NOT NULL,
DesignType varchar(50) NOT NULL,
DesignPrice nchar(8) NOT NULL,
CurrentStatus varchar(20) NULL
)

INSERT INTO Design VALUES('D20', 'Baby Grow', 'Colored', '150', 'NOT CHANGED');

/*CREATE VIEW V_Sales 
AS SELECT sale_id,
clt_id ,
sale_date ,
sale_total  
FROM Sales_master;*/

CREATE TABLE Management(
ManID varchar(10) PRIMARY KEY NOT NULL,
UserName varchar(30) NOT NULL,
UserPassword nchar(8) NOT NULL,
)

CREATE TABLE Sales(
SaleID varchar(10) PRIMARY KEY NOT NULL,
UserName varchar(30) NOT NULL,
UserPassword nchar(8) NOT NULL,
)

CREATE TABLE Production(
ProID varchar(10) PRIMARY KEY NOT NULL,
UserName varchar(30) NOT NULL,
UserPassword nchar(8) NOT NULL,
)

CREATE TABLE Stock(
StkID varchar(10) PRIMARY KEY NOT NULL,
UserName varchar(30) NOT NULL,
UserPassword nchar(8) NOT NULL,
)

CREATE TABLE Accountant(
AccID varchar(10) PRIMARY KEY NOT NULL,
UserName varchar(30) NOT NULL,
UserPassword nchar(8) NOT NULL,
)
CREATE TABLE Employee(
EmpId varchar(10) PRIMARY KEY NOT NULL,
EmpName varchar(30) NOT NULL,
EmpPost varchar(30) NOT NULL,
UserName varchar(30) NOT NULL,
UserPassword nchar(8) NOT NULL,
)

INSERT INTO Employee VALUES('1','gayan','Accountant', 'gayan', '1234@Xyz');
INSERT INTO Employee VALUES('2','gayan','Managing Director', 'gayan', '1234@Xyz');
INSERT INTO Employee VALUES('3','gayan','Production Manager', 'gayan', '1234@Xyz');
INSERT INTO Employee VALUES('4','gayan','Sales Manager', 'gayan', '1234@Xyz');
INSERT INTO Employee VALUES('5','gayan','Stock Manager', 'gayan', '1234@Xyz');

