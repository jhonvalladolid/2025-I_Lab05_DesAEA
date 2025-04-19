CREATE OR ALTER PROC USP_DeleteClienteLogical
    @idCliente VARCHAR(5)
AS
BEGIN
    UPDATE clientes
    SET activo = 0
    WHERE idCliente = @idCliente
END