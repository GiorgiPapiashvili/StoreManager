create Table Suppliers
(
	SupplierID int primary key identity(1,1),
	Name nvarchar(100) not null,
	TaxCode varchar(11) not null,
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