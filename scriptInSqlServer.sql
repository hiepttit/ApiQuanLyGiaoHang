create database QuanLyGiaoHang
go
--use master drop database QuanLyGiaoHangV1
use QuanLyGiaoHang
go
create table TheRoles
(
	id int primary key identity,
	RoleName nvarchar(1000),
	isMainRole int not null default 0,
	isDeleted int default 0
)
go
insert into TheRoles values
('Administrator',1,0),('Staff',1,0),('Shop',1,0)
go
create table TheUser
(
	id varchar(300) primary key,
	userName varchar(300) not null unique,
	pwd varchar(max) not null,
	name nvarchar(300),
	idNumber varchar(30),
	phoneNumber varchar(30),
	dateOfIssueIdNumber datetime,
	placeOfIssueIdNumber nvarchar(40),
	theAddress nvarchar(300),
	bankAccountNumber varchar(40),
	bankName nvarchar(500),
	createdAt datetime,
	updatedAt datetime,
	idRole int not null,-- references dbo.TheRoles(id),
	deletedAt datetime
)
go
create table RoleRelationShip
(
	idMainRole int not null references dbo.TheRoles(id),
	idUser varchar(300) not null references dbo.TheUser(id), -- should not be the main role, except admin and developer
	primary key(idUser)
)

go
create table TokenUser
(
	idToken varchar(200) primary key ,
	userName varchar(100) not null,
	token varchar(1000) not null,
	roles varchar(100),
)
go
create table TheOrder
(
	id varchar(300) primary key,
	idShop varchar(300) not null references dbo.TheUser(id),
	customerName nvarchar(100),
	phoneNumber varchar(30),
	theAddresss nvarchar(300),
	COD float,
	shipFee float,
	realReceive float,
	isSuccess int,
	theStatus int,
	isInStock int default 1,
	createdAt datetime,
	updatedAt datetime,
	deletedAt datetime
)
go
create table DeliveryOrder
(
	id varchar(300),
	idTheOrder varchar(300) not null references dbo.TheOrder(id),
	idStaff varchar(300) null references dbo.TheUser(id),
	createdAt datetime,
	updatedAt datetime,
	dateDeliveryOrder datetime,
	theStatus int,
	deletedAt datetime,
	primary key(id,idTheOrder)
)
create table StockOrder -- don't use if don't need
(
	id varchar(300),
	idTheOrder varchar(300) not null references dbo.TheOrder(id),
	amount float,
	createdAt datetime,
	updatedAt datetime,
	dateReturnToShop datetime, -- haven't used
	theStatus int default 0,
	deletedAt datetime,
	delaydate datetime
	primary key(id,idTheOrder)
)
go