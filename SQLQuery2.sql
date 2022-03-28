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

Create Table Login_History(
ID int primary key IDENTITY(0,1),
Title varchar(50) not null,
IPatient int foreign key REFERENCES Patient(ID),
IPaddress varchar(30) not null,
Browser varchar(MAX) not null,
UA varchar(MAX) not null)

Create Table [User](
ID int primary key IDENTITY(0,1),
IPatient int foreign key REFERENCES Patient(ID),
Login varchar(MAX) not null,
Password varchar(MAX) not null)