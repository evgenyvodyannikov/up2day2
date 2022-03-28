use [pr1-22-vodyannikoves_up2_day2_part2]

Create Table Country(
ID int primary key IDENTITY(0,1),
Title varchar(50) not null)

Create Table Insurance(
ID int primary key IDENTITY(0,1),
Title varchar(50) not null,
Country int foreign key REFERENCES Country(ID),
Address varchar(150) not null,
INN int not null,
PP int not null,
BIK int not null)

Create Table Social_License(
ID int primary key IDENTITY(0,1),
Title varchar(50) not null)

Create Table Patient(
ID int primary key IDENTITY(0,1),
LastName varchar(35) not null,
Name varchar(35) not null,
GuID varchar(MAX) not null,
Email varchar(150) not null,
SocialSecNumber int not null,
EIN varchar(50) not null,
Phone varchar(25) not null,
Social_Type int foreign key REFERENCES Social_License(ID),
Passport_Serial int not null,
Passport_Number int not null,
BirthDate date not null,
IInsurance int foreign key REFERENCES Insurance(ID))

Create Table User_Type(
ID int primary key IDENTITY(0,1),
Tittle varchar(40) not null)

Create Table [User](
ID int primary key IDENTITY(0,1),
Login varchar(MAX) not null,
Password varchar(MAX) not null,
Type int foreign key REFERENCES User_Type(ID))

Create Table Login_History(
ID int primary key IDENTITY(0,1),
IUser int foreign key REFERENCES [User](ID),
IPaddress varchar(30) not null,
LastEnter date,
MetaData varchar(MAX))

Create Table [Service](
ID int primary key IDENTITY(0,1),
Code int unique not null,
Tittle varchar(40) not null,
Price float not null)

Create Table User_Service(
ID int primary key IDENTITY(0,1),
IUser int foreign key REFERENCES [User](ID),
IService int foreign key REFERENCES Service(ID))

Create Table User_Patient(
ID int primary key IDENTITY(0,1),
IUser int foreign key REFERENCES [User](ID),
IPatient int foreign key REFERENCES Patient(ID))
--OS varchar(MAX),
--OsVersion varchar(MAX),
--Browser varchar(MAX),
--Language varchar(10),
--Revision varchar(10))