create table Purchases
(
	PurchaseID int primary key identity(1,1),
	SupplierID int foreign key references Suppliers(SupplierID) not null,
	EmployeeID int foreign key references Employees(EmployeeID) not null,
	Status tinyint not null default(0),
	PurchaseDate datetime not null default(GetDate())
	constraint check_Purchase_Status check(Status in(0,1,2))
)