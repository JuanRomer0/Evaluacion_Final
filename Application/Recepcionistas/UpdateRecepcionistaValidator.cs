using FluentValidation;

namespace Application.Recepcionistas;

public class UpdateRecepcionistaValidator : AbstractValidator<UpdateRecepcionista>
{
    public UpdateRecepcionistaValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Nombre).NotNull();
        RuleFor(x => x.Telefono).NotNull();
        RuleFor(x => x.AreaResponsabilidad).NotNull();
        RuleFor(x => x.IsActive).NotNull();
    }
}
