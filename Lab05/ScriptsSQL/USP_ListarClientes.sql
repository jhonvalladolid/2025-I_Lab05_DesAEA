CREATE OR ALTER PROC USP_ListarClientes
AS
BEGIN
    SELECT 
        idCliente,
        NombreCompañia,
        NombreContacto,
        CargoContacto,
        Direccion,
        Ciudad,
        Region,
        CodPostal,
        Pais,
        Telefono,
        Fax
    FROM clientes
    WHERE activo = 1
END
