namespace Api.DTOs.Recepcionistas;

public sealed record CreateRecepcionistaDto(
    string Nombre,
    string Telefono,
    string AreaResponsabilidad,
    bool IsActive,
    int UserId
);
