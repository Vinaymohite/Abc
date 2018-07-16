create database PETS
-----------------------------------------------------------
 use pets

Create table adlogin
(
	AdmName varchar(max),
	APassword varchar(max)
)
    select * from adlogin

//insert into adlogin values('siddhesh', 'siddhesh') 
//drop table adlogin
-----------------------------------------------------------------------------------
create table  userlogin
(
	uName varchar(max),
	uPassword varchar(max)
)

select * from userlogin
--------------------------------------------------------------
use pets
create table customerdetails
(
	
	customerid varchar(35),
	Fname varchar(35),
	phoneno varchar(50),
	AddressP varchar(50),
	product_Status char(20),
	product_name varchar(50),
	quantity varchar(50),
	mode varchar(50),
	amount varchar(50),
)

select * from customerdetails
insert into customerdetails values('1','SIDDHESH','9870767309','Dombivli','Delivered','CATS','2','Cash','5000')

//drop table customerdetails
//delete customerdetails where customerid=1
----------------------------------------------------------------------

use pets
create table employeeregister
(
	
	FName varchar(35),
	Phoneno varchar(35),
	FAddress varchar(50),
	AddressP varchar(50),
	EmployeeID varchar(20) PRIMARY KEY,
	Department varchar(40),
	Salary varchar(10),
	Gender char(20)
)

select * from employeeregister

//insert into employeeregister values('','','','','1','','','')
 //delete employeeregister where EmployeeID=1


---------------------------------------------------------------------------------------
use pets
create table product
(	
	ProductID varchar(20),
    PName varchar(20),
	PType varchar(20),
	Quantity varchar(20),
	Price varchar(20)
    
)
select * from Product 

//insert into Product values('1','CAT','POMERIAN','2','50000')
//drop table Product

-----------------------------------------------------------------------------------------------

use pets
create table supplier
(
	supplierID varchar(20),
	Sname varchar(20),
	IDproof varchar(20),
	phoneNO varchar(20),
	Saddress varchar(20),
	Sproduct varchar(20),
	Sdate varchar(20)
)
select * from supplier

//insert into supplier values('1','SIDDEHSH','PANCARD','9870767309','DOMBIVLI','PEDIGREE','10-05-2013')
//drop table supplier
//delete supplier where supplierID=1

-----------------------------------------------------------------------------------------------

use pets
create table salary
(
	Employee_ID bigint,
	FName varchar(35),
	Department varchar(35),
	Salary varchar(50),
	Total varchar(50),
    Payment varchar(50),
    Date varchar(50)
)
select * from salary
		
//drop table salary
//insert into salary values('1','SIDDHESH','','65000','700000','done','2-5-13')
//delete salary where Salary='25000'

---------------------------------------------------------------------------------------------

use pets
create table remainder
(
	 rdate varchar(20),
	CustID varchar(max),
	custname varchar(max),
	ph_no varchar(max),
	pet_name varchar(max),
	delivery_status varchar(max),
	delivery_boy varchar(max),
	phone_no varchar(max)
)
select*from remainder 

//select distinct(rdate) from remainder
//insert into remainder values('02-02-2013', '1', 'Abhishek', '09869856811', 'dog', 'Pending', 'Siddhesh', '98647578')
//drop table remainder
//select rdate from remainder where delivery_status ='Pending' 

------------------------------------------------------------------------------------------

