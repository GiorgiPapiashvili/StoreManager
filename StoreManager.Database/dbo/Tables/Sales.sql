create table Sales
(
  	SaleID int primary key identity(1,1),
	EmployeeID int foreign key references Employees(EmployeeID) not null,
	CustomerID int foreign key references Customers(CustomerID) not null,
	Status tinyint not null default(0),
	SaleDate datetime Default(GetDate()) null
	constraint check_Sales_Status check(Status in(0,1,2))
)