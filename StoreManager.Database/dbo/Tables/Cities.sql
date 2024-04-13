create table Cities
(
	CityID int primary key identity(1,1),
	CountryID int foreign key references Countries(CountryID) not null,
	Name nvarchar(100) not null,
	CreateDate datetime not null default(GetDate()),
	UpdateDate datetime null,
	IsDeleted bit not null default(0)
)