﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [EliminarModelo]
	-- Add the parameters for the stored procedure here
	       @Id  uniqueidentifier
           
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

 BEGIN TRANSACTION
 DELETE FROM Modelos WHERE (Id=@Id)

 SELECT @Id 
 COMMIT TRANSACTION
END