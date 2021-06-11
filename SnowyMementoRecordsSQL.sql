use master
go

create database wallM_Final
on primary
(name = wallM_Final,
filename = 'C:\Program Files\Microsoft Sql Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\wallM_Final.mdf',
size = 4,
maxsize = 30,
filegrowth = 4)
Log on
(name = wallM_Final_log,
filename = 'C:\Program Files\Microsoft Sql Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\wallM_Final.ldf',
size = 4,
maxsize = 30,
filegrowth = 4)

use wallM_Final
go

CREATE TABLE Products
(ASIN varchar(20) PRIMARY KEY not null,
AlbumName VARCHAR(50) not null,
Band varchar(30) not null,
Price DECIMAL(4,2) not null,
ReleaseDate varchar(20) not null,
Label VARCHAR(15) not null,
RunTime decimal(4,2) not null,
Stock int not null)
Picture varbinary(MAX);

create table variant
(VariantID varchar(20) foreign key references Products(ASIN),
VariantPrice decimal(6,2) not null,
VariantStock int not null)

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

CREATE TABLE Manager
(ManagerID varchar(20) primary key not null,
password varchar(20) not null,
attemptCount int not null,
Locked bit not null);

alter table Manager add constraint CK_attemptCount_Max check (attemptCount <= 3);

create table DealofWeek
(Deal varchar(MAX) not null);

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

create table Cart
(ItemID varchar(20) foreign key REFERENCES Products(ASIN),
Amount int not null,
altAmount int not null);

create table Schedules
(ScheduleEntryID int identity(1,1) primary key not null,
EmployeeID varchar(25) foreign key references Employee(EmployeeID) not null,
Position varchar(30) not null,
Shift varchar(10) not null)

create table ScheduleChanges
(ChangeID int identity(1,1) primary key not null,
PersonalScheduleID int foreign key references Schedules(ScheduleEntryID),
RequestedScheduleID int foreign key references Schedules(ScheduleEntryID),
EmployeeID varchar(25) foreign key references Employee(EmployeeID) not null,
Request varchar(50) not null,
Reason varchar(max) not null,
Status varchar(25) not null)

create table RequestOff
(RequestID int identity(1,1) primary key not null,
EmployeeID varchar(25) foreign key references Employee(EmployeeID),
Shift varchar(10) not null,
Request varchar(50) not null,
Reason varchar(max) not null,
Status varchar(25) not null)

create table Invoice
(ProductID varchar(20) foreign key references Products(ASIN),
PrductName varchar(50) not null,
Amount int not null,
Price decimal(6,2) not null,
AltAmount int not null,
AltPrice decimal(6,2) not null,
Total decimal(14,2) not null)

 insert into Products
  values
  ('B00175GCEU', 'America', 'America', 9.95, 'September 25, 2015', 'Friday Music', 46.14, 30, null),
  ('B002F3BP4U', 'Homecoming', 'America', 34.53, 'May 4, 2018', 'Friday Music', 33.06, 30, null),
  ('B01LTHN0DG', 'The Dark Side of the Moon', 'Pink Floyd', 22.57, 'November 4, 2016', 'Legacy', 43, 30, null),
  ('B01LTHN0DQ', 'Animals', 'Pink Floyd', 24.26, 'December 2, 2016', 'Legacy', 42, 30, null),
  ('B01IOED5AU', 'Divison Bell', 'Pink Floyd', 31.20, 'August 26, 2016', 'Sony Legacy', 66, 30, null),
  ('B01EW1UMM8', 'Ummagumma', 'Pink Floyd', 29.69, 'June 3, 2016', 'Sony Legacy', 86, 30, null),
  ('B00IXHBMLS', 'Led Zeppelin I', 'Led Zeppelin', 21.49, 'June 3, 2014', 'Atlantic', 44.56, 30, null),
  ('B00M30T9F2', 'Led Zeppelin IV', 'Led Zeppelin', 23.80, 'October 27, 2014', 'Atlantic', 42.34, 30, null),
  ('B00BU984SK', 'Sailing The Seas Of Cheese', 'Primus', 13.97, 'May 21, 2013', 'Interscope', 45.43, 30, null),
  ('B002S4DO4U', 'Frizzle Fry', 'Primus', 17.16, 'November 24, 2009', 'Prawn Song', 51.23, 30, null),
  ('B005STGJDA', 'The Colour And The Shape', 'Foo Fightes', 23.01, 'November 21, 2011', 'Sony Legacy', 47, 30, null),
  ('B005STGKI4', 'There Is Nothing Left To Lose', 'Foo Fighters', 23.09, 'November 21, 2011', 'Sony Legacy', 46, 30, null),
  ('B005STGJHQ', 'Foo Fighters', 'Foo Fighters', 16.15, 'November 21, 2011', 'Sony Legacy', 44, 30, null),
  ('B00N3B8VQS', 'The Lonesome Crowded West', 'Modest Mouse', 20.96, 'November 4, 2014', 'Glacial Pace Records', 73.58, 30, null),
  ('B00N3B8V9A', 'This Is A Long Drive For Someone With Nothing to Think About', 'Modest Mouse', 22.58, 'October 27, 2014', 'Glacial Pace Records', 74.03, 30, null),
  ('B004MSRD7E', 'Second Stage Turbine Blade', 'Coheed and Cambria', 175, '?March 5, 2002', 'Equal Vision Records', 48.44, 30, null),
  ('B00M0CXA44', 'In Keeping Secrets Of Silent Earth: 3', 'Coheed and Cambria', 27.41, 'October 21, 2014', 'Columbia', 69, 30, null),
  ('B071HGJMZ8', 'From Fear Through The Eyes Of Madness', 'Coheed and Cambria', 19.99, 'June 30, 2017', 'Columbia', 72, 30, null),
  ('B000VS6QTA', 'No World for Tomorrow', 'Coheed and Cambria', 270, 'October 23, 2007', 'Columbia', 59.59, 30, null),
  ('B00004UEHD', 'Bleach Remastered',  'Nirvana', 15.98, 'November 21, 2011', 'Sub Pop', 71.41, 30, null),
  ('B00004WP7P', 'In Utero', 'Nirvana', 22.48, 'July 3, 2007', 'Imports', 41.23, 30, null),
  ('B01ARJQK52', 'Good News for People Who Love Bad News', 'Modest Mouse', 32.93, 'April 6, 2004', 'Epic', 48.50, 30, null),
  ('B000NA22AI', 'We Were Dead Before the Ship Even Sank', 'Modest Mouse', 24, 'March 20, 2007', 'Epic', 63, 30, null),
  ('B01F0XLQZE', 'The Bends', 'Radiohead', 18.96, 'April 15, 2016', 'Capitol', 48.37, 30, null),
  ('B000YIXBV8', 'In Rainbows', 'Radiohead', 22.98, 'April 15, 2016', 'XL Recordings', 42.39, 30, null);

   insert into variant values 
  ('B00175GCEU',19.95,30),
  ('B002F3BP4U',44.53,30),
  ('B01LTHN0DG',32.57,30),
  ('B01LTHN0DQ',34.26,30),
  ('B01IOED5AU',41.20,30),
  ('B01EW1UMM8',39.69,30),
  ('B00IXHBMLS',31.49,30),
  ('B00M30T9F2',33.80,30),
  ('B00BU984SK',23.97,30),
  ('B002S4DO4U',27.16,30),
  ('B005STGJDA',33.01,30),
  ('B005STGKI4',33.09,30),
  ('B005STGJHQ',26.15,30),
  ('B00N3B8VQS',30.96,30),
  ('B00N3B8V9A',32.58,30),
  ('B004MSRD7E',185.00,30),
  ('B00M0CXA44',37.41,30),
  ('B071HGJMZ8',29.99,30),
  ('B000VS6QTA',280.00,30),
  ('B00004UEHD',25.98,30),
  ('B00004WP7P',32.48,30),
  ('B01ARJQK52',42.93,30),
  ('B000NA22AI',34.00,30),
  ('B01F0XLQZE',28.96,30),
  ('B000YIXBV8',32.98,30)

insert into Employee values
('aAnderson1', 'Kingfisher0', 'Aaron', 'Anderson', 'aAnderson@gmail.com', 32000.00,0,0),
('bBeria', 'Sparrow1', 'Brian', 'Beria', 'bBeria@gmail.com', 32000.00,0,0),
('cChamberlain', 'Bluejay2', 'Charlie', 'Chamberlain', 'cChamberlain@gmail.com', 24000.00,0,0),
('dDenver', 'HummingBird3', 'Dante', 'Denver', 'dDenver@gmail.com', 36000.00,0,0),
('eEwomer', 'Snowyowl4', 'Edgar', 'Ewomer', 'eEwomer@gmail.com', 36000.00,0,0)

insert into Manager values
('recordMaster123', 'GrAuKaIsEr843', 3, 0)

insert into Schedules values
('aAnderson1', 'Casher', '08-15-2019'),
('bBeria', 'Casher', '08-15-2019'),
('cChamberlain', 'Casher', '08-15-2019'),
('dDenver', 'Stock', '08-15-2019'),
('eEwomer', 'Stock', '08-15-2019')