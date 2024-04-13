create table Customers
(
	CustomerID int primary key identity(1, 1),
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) unique null,
	Phone varchar(20) null,
	AddressLine1 nvarchar(100) null,
	Addressline2 nvarchar(100) null,
	ZipCode nvarchar(50) null,
	CityID int foreign key references Cities(CityID),
	CreateDate datetime not null default(GetDate()),
	UpdateDate datetime null,
	IsDeleted bit not null default(0)
)