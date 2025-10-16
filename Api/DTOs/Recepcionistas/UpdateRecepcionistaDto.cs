namespace Api.DTOs.Recepcionistas;

public sealed record UpdateRecepcionistaDto(
    string? Nombre,
    string? Telefono,
    string? AreaResponsabilidad,
    bool? IsActive
);
