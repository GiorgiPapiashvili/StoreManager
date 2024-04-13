create procedure sp_InsertCountry
@Name nvarchar(100),
@ID int out
as
begin	
	set nocount on;

		insert into Countries(Name) values(@Name);

		set @ID = @@IDENTITY;

	return 0;
end