create table Categories
(
	CategoryID int primary key identity(1, 1),
	Name nvarchar(50) not null unique,
	Description nvarchar(1000) null,
	CreateDate datetime not null default(GetDate()),
	UpdateDate datetime null,
	IsDeleted bit default(0)
)