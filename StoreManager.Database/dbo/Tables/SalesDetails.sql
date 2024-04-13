create table SaleDetails
(
	primary key(ProductID,SaleID)
	SaleID int foreign key references Sales(SaleID),
	ProductID int foreign key references Products(ProductID),
	Quantity int not null,
	Price money not null,
	SaleDetails nvarchar(500)
)