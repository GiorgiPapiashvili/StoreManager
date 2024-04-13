create table Countries
(
	CountryID int primary key identity(1,1),
	Name nvarchar(100) not null unique,
	CreateDate datetime not null default(GetDate()),
	UpdateDate datetime null,
	IsDeleted bit not null default(0)
)
