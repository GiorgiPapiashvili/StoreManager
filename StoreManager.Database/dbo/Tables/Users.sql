CREATE TABLE [dbo].[Users]
(
	EmployeeID int foreign key references Employees(EmployeeId) primary key,
	UserName nvarchar(50) not null unique,
	Password varbinary(50) not null,
	IsActive bit not null default(1),
	CreateDate datetime2 not null default(GetDate())
)
