create table PurchaseDetails
( 
	PurchaseID int  foreign key references Purchases(PurchaseID) not null,
	ProductID int foreign key references Products(ProductID) not null,
	UnitPrice money not null,
	Quantity int not null,
	primary key(ProductID, PurchaseID)
)