using FluentValidation;

namespace Readifly.Application.Features.Prestamos.Commands.RealizarPrestamo
{
    public class RealizarPrestamoCommandValidator : AbstractValidator<RealizarPrestamoCommand>
    {
        public RealizarPrestamoCommandValidator()
        {
            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("El ISBN es requerido")
                .Length(10, 17).WithMessage("El ISBN debe tener entre 10 y 17 caracteres");

            RuleFor(x => x.UsuarioId)
                .NotEmpty().WithMessage("El ID de usuario es requerido")
                .MaximumLength(50).WithMessage("El ID de usuario no puede exceder 50 caracteres");
        }
    }
}
