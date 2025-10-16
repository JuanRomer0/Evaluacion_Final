namespace Api.DTOs.Recepcionistas;

public sealed record RecepcionistaDto(
    int Id,
    string Nombre,
    string Telefono,
    string AreaResponsabilidad,
    bool IsActive,
    int UserId,
    DateTime CreatedAt,
    DateTime UpdatedAt
);