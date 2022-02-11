CREATE PROCEDURE [dbo].[AddItemSingular]

	@Name nvarchar(500),
	@Nickname nvarchar(500),
	@Description nvarchar(MAX), 
	@IsActive bit

AS
BEGIN

    SET NOCOUNT ON

	DECLARE @responseMessage NVARCHAR(250)

	IF EXISTS (select top 1 id from AllItemPlural where Name = @Name)
		Begin
			SET @responseMessage='ItemSingular name already exists. Please choose another'
			Select @responseMessage  as ResponseMessage
		End
	ELSE 
		Begin
			SET @responseMessage='Success'
			insert into AllItemPlural (Name, Nickname, Description, IsActive, CreationDate, ModifyDate)
			Values (@Name, @Nickname, @Description, @IsActive, GETDATE(), GETDATE())

			select @responseMessage  as ResponseMessage, Id as ItemSingularId from  AllItemPlural where ItemSingularID= (IDENT_CURRENT('AllItemPlural'))

		End
	
END
