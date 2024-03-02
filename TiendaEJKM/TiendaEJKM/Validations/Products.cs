using FluentValidation;
using TiendaEJKM.Models;

namespace TiendaEJKM.Validations
{
    public class Products : AbstractValidator<ProductsModel>
    {
        public Products()
        {
            RuleFor(employees => employees.Name_Product)
                .NotNull().WithMessage("Debe de ingresar el nombre ")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Debe de ingresar minimo 3 letras ")
                .MaximumLength(25).WithMessage("Solo se permite ingresar 50 caracteres");


            RuleFor(employees => employees.Category_Product)
                .NotNull().WithMessage("La categoria no debe de estar vacio")
                .NotEmpty()
                .MaximumLength(50).WithMessage("Solo se permite ingresar 50 caracteres");

            RuleFor(employees => employees.Price_Product)
                .NotNull().WithMessage("El precio no debe de estar vacio")
                .NotEmpty();

            RuleFor(employees => employees.Availability_Product)
                .NotNull().WithMessage("La disponibilidad no debe de estar vacio")
                .NotEmpty();

        }
    }
}
