create table SaleDetails
(
	SaleID int foreign key references Sales(SaleID) not null,
	ProductID int foreign key references Products(ProductID) not null,
	UnitPrice money not null,
	Quantity int not null,
	primary key(SaleID, ProductID)
)
