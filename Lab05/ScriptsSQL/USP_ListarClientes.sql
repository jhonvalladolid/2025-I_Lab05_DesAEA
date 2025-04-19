CREATE OR ALTER PROC USP_ListarClientes
AS
BEGIN
    SELECT 
        idCliente,
        NombreCompañia,
        NombreContacto,
        Ciudad,
        Pais,
        Telefono
    FROM clientes
    WHERE activo = 1
END