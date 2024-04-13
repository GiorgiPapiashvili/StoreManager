create table EmployeeTypes
(
	EmployeeTypeID int primary key identity(1,1),
	Name nvarchar(50) not null unique,
	Description nvarchar(1000) null,
	CreateDate datetime not null default(GetDate()),
	UpdateDate datetime null,
	IsDeleted bit not null default(0)
)