use [pr1-22-vodyannikoves_up2_day2]

Create Table Gender(
ID int primary key IDENTITY(0,1),
Name varchar(35) not null)


Create Table Client(
ID int primary key IDENTITY(0,1),
LastName varchar(35) not null,
Name varchar(35) not null,
Patronimyc varchar(35) not null,
IGender int foreign key REFERENCES Gender(ID),
PhoneNumber varchar(20) not null,
DateOfBirth date not null,
Mail varchar(30),
DateOfRegistation date not null)

Create Table Service(
ID int primary key IDENTITY(0,1),
Title varchar(150) not null,
MainImagePath varchar(75) not null,
Duration int not null,
Cost float not null,
Discount int not null)

Create Table Client_Service(
ID int primary key IDENTITY(0,1),
IService int foreign key REFERENCES Service(ID),
IClient int foreign key REFERENCES Client(ID),
StartDate datetime not null)