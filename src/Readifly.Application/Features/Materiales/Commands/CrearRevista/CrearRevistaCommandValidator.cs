using FluentValidation;

namespace Readifly.Application.Features.Materiales.Commands.CrearRevista
{
    public class CrearRevistaCommandValidator : AbstractValidator<CrearRevistaCommand>
    {
        public CrearRevistaCommandValidator()
        {
            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("El ISBN es requerido")
                .Length(10, 17).WithMessage("El ISBN debe tener entre 10 y 17 caracteres");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres");

            RuleFor(x => x.Editorial)
                .NotEmpty().WithMessage("La editorial es requerida")
                .MaximumLength(100).WithMessage("La editorial no puede exceder 100 caracteres");

            RuleFor(x => x.Numero)
                .GreaterThan(0).WithMessage("El número debe ser mayor a 0");

            RuleFor(x => x.Volumen)
                .GreaterThan(0).WithMessage("El volumen debe ser mayor a 0");

            RuleFor(x => x.FechaPublicacion)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de publicación no puede ser futura");
        }
    }
}
