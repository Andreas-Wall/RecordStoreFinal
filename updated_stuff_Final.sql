/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ASIN]
      ,[AlbumName]
      ,[Band]
      ,[Price]
      ,[ReleaseDate]
      ,[Label]
      ,[RunTime]
      ,[Stock]
      ,[Picture]
  FROM [wallM_Final].[dbo].[Products]

  select p.*, v.VariantPrice, v.VariantStock from Products p join variant v on p.ASIN = v.VariantID order by p.Band 

insert into Products values ('test', 'test', 'test', 1, 'test', 'test', 1, 1, null);
insert into variant values ('test', 0,0);

update Products set stock = 30 
update variant set VariantStock = 30 

update products set Price = '3.00' where ASIN = 'yeet'

delete from variant where VariantID = 'test'
delete from Products where ASIN = 'test'

select AlbumName, Band, Label from Products order by Band, AlbumName

use wallM_Final
go

create table Cart
(ItemID varchar(20) foreign key REFERENCES Products(ASIN),
Amount int not null,
altAmount int not null);

insert into Cart values
('test',2, 2),
('B01F0XLQZE',2,2)

select * from Products where ASIN = 'B01F0XLQZE'

select p.AlbumName, c.Amount,(c.Amount * p.Price) as 'NormalTotal', c.altAmount, (c.altAmount * v.VariantPrice) as 'AltTotal' from Cart c join Products p on c.ItemID = p.ASIN join variant v on c.ItemID = v.VariantID

delete from cart where amount = 0

update cart set Amount = Amount + 1 where ItemID = 'test'

select * from variant

select * from Cart

 select * from Orders 
 select * from orderDetails

 update orderDetails set OrderID = 2 where ProductName = 'The Bends'

CREATE TABLE Manager
(ManagerID varchar(20) primary key not null,
password varchar(20) not null,
attemptCount int not null,
Locked bit not null);

alter table Manager add constraint CK_attemptCount_Max check (attemptCount <= 3);

insert into Manager values
('recordMaster123', 'GrAuKaIsEr843', 3, 0)

select * from Manager

select ManagerID, Locked from Manager where ManagerID = 'recordMaster123'

update Manager set attemptCount = 0
update Manager set Locked = 0

 begin
	declare @attempts int;
	update Manager set attemptCount = attemptCount + 1 where ManagerID = 'recordMaster123';
	select @attempts = (attemptCount) from Manager where ManagerID = 'recordMaster123';
	select @attempts;
	if @attempts = 3
	begin
		update Manager set Locked = 1 where ManagerID = 'recordMaster123';
	end
end

delete from Manager

create table DealofWeek
(Deal varchar(MAX) not null);

create Table Employee
(EmployeeID varchar(25) primary key not null,
Password varchar(25) not null,
FirstName varchar(25) not null,
LastName varchar(25) not null,
Phone varchar(12) not null,
Email varchar(100) not null,
Salary decimal(7,2) not null,
attemptCount int not null,
Locked bit not null);

alter table Employee add constraint CK_Password_num check (Password like '%[^0-9]%');
alter table Employee add constraint CK_Password_cap check (Password like '%[^A-Z]%');
alter table Employee add constraint CK_Phone CHECK (phone like '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]')

insert into Employee values
('aAnderson1', 'Kingfisher0', 'Aaron', 'Anderson', '111-111-1111', 'aAnderson@gmail.com', 32000.00,0,0),
('bBeria', 'Sparrow1', 'Brian', 'Beria', '222-222-2222', 'bBeria@gmail.com', 32000.00,0,0),
('cChamberlain', 'Bluejay2', 'Charlie', 'Chamberlain','333-333-3333', 'cChamberlain@gmail.com', 24000.00,0,0),
('dDenver', 'HummingBird3', 'Dante',  'Denver', '444-444-4444', 'dDenver@gmail.com', 36000.00,0,0),
('eEwomer', 'Snowyowl4', 'Edgar',  'Ewomer', '555-555-5555', 'eEwomer@gmail.com', 36000.00,0,0)

select * from DealofWeek

create table Orders
(OrderID int IDENTITY(1,1) primary key not null,
Tax decimal(10,2) not null,
PriceTotal decimal(15,2) not null,
Amount int not null,);

create table orderDetails
(OrderID int foreign key references Orders(OrderID),
ProductName varchar(70) not null,
Amount int not null,
Price decimal(6,2) not null,
AltAmount int not null,
AltPrice decimal(6,2) not null)

select * from Orders

select * from orders
select * from orderDetails

update Employee set attemptCount = 0
update Employee set Locked = 0

select * from Employee where EmployeeID = 'aAnderson1'

 use wallM_Final
go

select (FirstName + ' ' + LastName) as 'Name' from Employee
select s.ScheduleEntryID, (e.FirstName + ' ' + e.LastName) as 'Name', s.Position, s.Shift from Schedules s join Employee e on e.EmployeeID = s.EmployeeID

create table Schedules
(ScheduleEntryID int identity(1,1) primary key not null,
EmployeeID varchar(25) foreign key references Employee(EmployeeID) not null,
Position varchar(30) not null,
Shift varchar(10) not null)

select * from Schedules where ScheduleEntryID = '5'


insert into Schedules values
('aAnderson1', 'Casher', '08-15-2019'),
('bBeria', 'Casher', '08-15-2019'),
('cChamberlain', 'Casher', '08-15-2019'),
('dDenver', 'Stock', '08-15-2019'),
('eEwomer', 'Stock', '08-15-2019')

update Schedules set EmployeeID = 'bBeria' where ScheduleEntryID = 4

create table ScheduleChanges
(ChangeID int identity(1,1) primary key not null,
PersonalScheduleID int foreign key references Schedules(ScheduleEntryID),
RequestedScheduleID int foreign key references Schedules(ScheduleEntryID),
EmployeeID varchar(25) foreign key references Employee(EmployeeID) not null,
Request varchar(50) not null,
Reason varchar(max) not null,
Status varchar(25) not null)

insert into ScheduleChanges values
('3','4','aAnderson1','Change','Change of pace','Awaiting confirmation')
insert into ScheduleChanges values
('3','5','aAnderson1','Change','Change of pace','Awaiting confirmation')

select * from ScheduleChanges where EmployeeID = 'aAnderson1'
select count(*) from ScheduleChanges

create table RequestOff
(RequestID int identity(1,1) primary key not null,
EmployeeID varchar(25) foreign key references Employee(EmployeeID),
Shift varchar(10) not null,
Request varchar(50) not null,
Reason varchar(max) not null,
Status varchar(25) not null)


select * from RequestOff

select r.EmployeeID, (e.FirstName + ' ' + e.LastName) as 'Name', r.Shift, r.Request, r.Reason from RequestOff r join Employee e on e.EmployeeID = r.EmployeeID  where r.EmployeeID =  'bBeria'

insert into RequestOff values
('bBeria', '08-19-2019', 'Off', 'Dentist Appointment', 'Awaiting confirmation')


create table Invoice
(ProductID varchar(20) foreign key references Products(ASIN),
PrductName varchar(50) not null,
Amount int not null,
Price decimal(6,2) not null,
AltAmount int not null,
AltPrice decimal(6,2) not null,
Total decimal(14,2) not null)

delete from Invoice
