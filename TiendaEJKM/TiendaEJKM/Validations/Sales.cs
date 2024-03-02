using FluentValidation;
using TiendaEJKM.Models;

namespace TiendaEJKM.Validations
{
    public class Sales : AbstractValidator<SalesModel>
    {
        public Sales()
        {
            RuleFor(employees => employees.Name_Customer)
                .NotNull().WithMessage("Debe de ingresar el nombre ")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Debe de ingresar minimo 3 letras ")
                .MaximumLength(25).WithMessage("Solo se permite ingresar 50 caracteres");

            RuleFor(employees => employees.Name_Product)
                .NotNull().WithMessage("El campo no debe de estar vacio")
                .MinimumLength(3).WithMessage("Debe de ingresar minimo 3 letras ")
                .MaximumLength(25).WithMessage("Solo se permite ingresar 50 caracteres");

            RuleFor(employees => employees.Name_Employee)
                .NotNull().WithMessage("El teléfono no debe de estar vacio")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Debe de ingresar minimo 3 letras ")
                .MaximumLength(25).WithMessage("Solo se permite ingresar 50 caracteres");

            RuleFor(employees => employees.Date_Sale)
                .NotNull().WithMessage("La fecha no debe de estar vacio")
                .NotEmpty();

            RuleFor(employees => employees.Total_Paid)
                .NotNull().WithMessage("El total pagado no debe de estar vacio")
                .NotEmpty();

        }
    }
}
