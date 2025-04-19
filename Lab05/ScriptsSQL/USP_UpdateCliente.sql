CREATE OR ALTER PROC USP_UpdateCliente
    @idCliente VARCHAR(5),
    @NombreCompañia VARCHAR(100),
    @NombreContacto VARCHAR(100),
    @CargoContacto VARCHAR(100),
    @Direccion VARCHAR(100),
    @Ciudad VARCHAR(100),
    @Region VARCHAR(100),
    @CodPostal VARCHAR(100),
    @Pais VARCHAR(100),
    @Telefono VARCHAR(30),
    @Fax VARCHAR(30)
AS
BEGIN
    UPDATE clientes
    SET 
        NombreCompañia = @NombreCompañia,
        NombreContacto = @NombreContacto,
        CargoContacto = @CargoContacto,
        Direccion = @Direccion,
        Ciudad = @Ciudad,
        Region = @Region,
        CodPostal = @CodPostal,
        Pais = @Pais,
        Telefono = @Telefono,
        Fax = @Fax
    WHERE idCliente = @idCliente
END