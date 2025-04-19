CREATE OR ALTER PROC USP_InsertCliente
    @idCliente VARCHAR(5),
    @NombreCompañia VARCHAR(100),
    @NombreContacto VARCHAR(100) = NULL,
    @CargoContacto VARCHAR(100) = NULL,
    @Direccion VARCHAR(100) = NULL,
    @Ciudad VARCHAR(100) = NULL,
    @Region VARCHAR(100) = NULL,
    @CodPostal VARCHAR(100) = NULL,
    @Pais VARCHAR(100) = NULL,
    @Telefono VARCHAR(30) = NULL,
    @Fax VARCHAR(30) = NULL
AS
BEGIN
    INSERT INTO clientes (
        idCliente, NombreCompañia, NombreContacto, CargoContacto,
        Direccion, Ciudad, Region, CodPostal, Pais, Telefono, Fax, activo
    )
    VALUES (
        @idCliente, @NombreCompañia, @NombreContacto, @CargoContacto,
        @Direccion, @Ciudad, @Region, @CodPostal, @Pais, @Telefono, @Fax, 1
    )
END