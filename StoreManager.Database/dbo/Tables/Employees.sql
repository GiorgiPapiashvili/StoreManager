create table Employees
(
	EmployeeID int primary key identity(1,1),
	EmployeeTypeID int foreign key references EmployeeTypes(EmployeeTypeID) not null,
	FirstName nvarchar(20) not null,
	LastName nvarchar(30) not null,
	IdentityNumber varchar(11) not null unique,
	Email nvarchar(100) unique not null,
	Phone varchar(20) not null,
	AddressLine1 nvarchar(100) null,
	Addressline2 nvarchar(100) null,
	ZipCode nvarchar(50) null,
	CityID int foreign key references Cities(CityID),
	CreateDate datetime not null default(GetDate()),
	UpdateDate datetime null,
	IsDeleted bit not null default(0)
)