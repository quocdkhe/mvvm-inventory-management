Create database InventoryManagement
GO

Use InventoryManagement
GO

Create table Units
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(255)
)

GO

Create table Suppliers
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(255),
	Address nvarchar(255),
	Phone nvarchar(20),
	Email nvarchar(255),
	MoreInfo nvarchar(255),
	ContractDate DateTime
)

GO

Create table Customers
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(255),
	Address nvarchar(255),
	Phone nvarchar(20),
	Email nvarchar(255),
	MoreInfo nvarchar(255),
	ContractDate DateTime
)

GO

Create table Objects
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(255),
	UnitId int not null,
	SupplierId int not null,
	QRCode nvarchar(255),
	BarCode nvarchar(255),

	foreign key(UnitId) references Units(Id),
	foreign key(SupplierId) references Suppliers(Id)
)
go
Create table Roles
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(255),
)
go

Create table Users
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(255),
	UserName nvarchar(100),
	Password nvarchar(255),
	RoleId int not null,

	foreign key (RoleId) references Roles(Id)
)

go
