﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE AgregarMarcas
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

INSERT INTO [dbo].[Marcas]
           ([Id]
           ,[Nombre])
     VALUES
           (@Id  
           ,@Nombre )


           SELECT @Id
            COMMIT TRANSACTION
           
END