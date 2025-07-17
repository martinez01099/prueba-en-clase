-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE EditarMarcas
	-- Add the parameters for the stored procedure here
	       @Id AS uniqueidentifier
           ,@Nombre AS varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    BEGIN TRANSACTION
    UPDATE [dbo].[Marcas]
   SET [Id] = @Id
      ,[Nombre] = @Nombre
 WHERE Id=@Id

 SELECT @Id 
 COMMIT TRANSACTION




END