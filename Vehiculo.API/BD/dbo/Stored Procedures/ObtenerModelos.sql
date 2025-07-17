-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerModelos]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

SELECT 
        modelo.Id,
        modelo.Idmarca,
        modelo.Nombre,
        marca.Nombre AS Marca
    FROM Modelos modelo
    INNER JOIN Marcas marca ON modelo.Idmarca = marca.Id;


END