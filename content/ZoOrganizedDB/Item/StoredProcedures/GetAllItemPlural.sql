CREATE PROCEDURE [dbo].[GetAllItemPlural]
AS
BEGIN

    SET NOCOUNT ON

	DECLARE @responseMessage NVARCHAR(250)

	SET @responseMessage='Success'

	Select @responseMessage  as ResponseMessage, Id as ItemSingularId, Name, Description, Nickname, CreationDate, ModifyDate, IsActive from AllItemPlural

END






/****** Object:  StoredProcedure [dbo].[GetItemSingularById]    Script Date: 2/2/2022 9:42:00 PM ******/
SET ANSI_NULLS ON
