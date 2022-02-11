CREATE PROCEDURE [dbo].[UpdateItemSingular]
    @ItemSingularID bigint,
    @Name NVARCHAR(100)='',
	 @Nickname NVARCHAR(100)='',
	 @Description NVARCHAR(MAX)='',
	 @IsActive nvarchar(5)='',
    @responseMessage NVARCHAR(250)='' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

    IF EXISTS (SELECT TOP 1 ItemSingularID FROM [dbo].AllItemPlural WHERE ItemSingularID=@ItemSingularID)
    BEGIN
		BEGIN TRY
			Update [dbo].AllItemPlural Set Name = CASE WHEN @Name <>'' THEN @Name Else Name END,
									  Nickname =  CASE WHEN @Nickname <>'' THEN @Nickname Else Nickname END,
									  [Description] =  CASE WHEN @Description <>'' THEN @Description Else [Description] END,
									  IsActive = CASE WHEN @IsActive <>'' THEN (CASE @IsActive WHEN 'TRUE' THEN 1 ELSE 0 END) Else IsActive END

									  Where ItemSingularID= @ItemSingularID

			SET @responseMessage='Success'
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE() 
		END CATCH
    END
    ELSE
       SET @responseMessage='Invalid ItemSingular'

END
