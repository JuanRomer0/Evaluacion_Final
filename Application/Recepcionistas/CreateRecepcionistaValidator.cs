using FluentValidation;
using Application.Administradores;

namespace Application.Recepcionistas;
public class CreateRecepcionistaValidator : AbstractValidator<CreateRecepcionista>
{
    public CreateRecepcionistaValidator()
    {
        RuleFor(x => x.Nombre).NotNull();
        RuleFor(x => x.Telefono).NotNull();
        RuleFor(x => x.AreaResponsabilidad).NotNull();
        RuleFor(x => x.IsActive).NotNull();
    }
}

