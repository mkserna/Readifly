using FluentValidation;

namespace Readifly.Application.Features.Prestamos.Commands.RegistrarDevolucion
{
    public class RegistrarDevolucionCommandValidator : AbstractValidator<RegistrarDevolucionCommand>
    {
        public RegistrarDevolucionCommandValidator()
        {
            RuleFor(x => x.PrestamoId)
                .GreaterThan(0).WithMessage("El ID del préstamo debe ser mayor a 0");
        }
    }
}
