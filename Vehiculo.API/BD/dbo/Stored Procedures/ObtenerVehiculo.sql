-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerVehiculo
	-- Add the parameters for the stored procedure here
	@Id uniqueidentifier
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Vehiculo.Id, Vehiculo.Placa, Vehiculo.IdModelo, Vehiculo.Color, Vehiculo.Anio, Vehiculo.CorreoPropietario, Vehiculo.TelefonoPropietario, Vehiculo.Precio, Modelos.Nombre AS Modelo, Marcas.Nombre AS Marca
FROM     Vehiculo INNER JOIN
                  Modelos ON Vehiculo.IdModelo = Modelos.Id INNER JOIN
                  Marcas ON Modelos.Idmarca = Marcas.Id
WHERE  (Vehiculo.Id = @Id)
END