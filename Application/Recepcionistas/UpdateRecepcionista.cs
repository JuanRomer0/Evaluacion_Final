using Domain.ValueObjects;
using MediatR;

namespace Application.Recepcionistas;

public sealed record UpdateRecepcionista(
    IdVO Id,
    NombreVO Nombre,
    TelefonoVO Telefono,
    DescripcionVO AreaResponsabilidad,
    EstadoVO IsActive
) : IRequest<bool>;
