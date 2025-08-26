using FluentValidation;

namespace Readifly.Application.Features.Materiales.Commands.CrearLibro
{
    public class CrearLibroCommandValidator : AbstractValidator<CrearLibroCommand>
    {
        public CrearLibroCommandValidator()
        {
            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("El ISBN es requerido")
                .Length(10, 17).WithMessage("El ISBN debe tener entre 10 y 17 caracteres");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres");

            RuleFor(x => x.Autor)
                .NotEmpty().WithMessage("El autor es requerido")
                .MaximumLength(100).WithMessage("El autor no puede exceder 100 caracteres");

            RuleFor(x => x.NumeroPaginas)
                .GreaterThan(0).WithMessage("El número de páginas debe ser mayor a 0");

            RuleFor(x => x.Editorial)
                .NotEmpty().WithMessage("La editorial es requerida")
                .MaximumLength(100).WithMessage("La editorial no puede exceder 100 caracteres");

            RuleFor(x => x.AnioPublicacion)
                .GreaterThan(0).WithMessage("El año de publicación debe ser válido")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("El año de publicación no puede ser futuro");
        }
    }
}
