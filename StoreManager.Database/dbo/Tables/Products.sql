create table Products
(
	ProductID int primary key identity(1,1),
	CategoryID int foreign key references Categories(CategoryID) not null,
	ProductCode varchar(10) not null unique,
	Name nvarchar(50) not null,
	Description nvarchar(1000) null,
	UnitPrice money not null,
	CreateDate datetime not null default(GetDate()),
	UpdateDate datetime null,
	IsDeleted bit not null default(0)
)