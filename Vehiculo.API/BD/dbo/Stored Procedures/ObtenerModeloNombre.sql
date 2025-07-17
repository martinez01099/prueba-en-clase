-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerModeloNombre
    @Nombre VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        IdMarca,
        Nombre
    FROM Modelos
    WHERE LOWER(Nombre) = LOWER(@Nombre);
END