CREATE PROCEDURE [dbo].[GetItemSingularById]
    @ItemSingularId uniqueidentifier
AS
BEGIN

    SET NOCOUNT ON

	DECLARE @responseMessage NVARCHAR(250)

	DECLARE @ItemSingularIdIdentity bigint

	IF EXISTS (select top 1 id from AllItemPlural where Id = @ItemSingularId)
		Begin
			SET @responseMessage='Success'
			Select @responseMessage  as ResponseMessage, Name, Description, Nickname, CreationDate, ModifyDate, IsActive from AllItemPlural where id = @ItemSingularId
		End
	Else
		Begin
			SET @responseMessage='Fail'
			Select  @responseMessage as ResponseMessage
		End
END
