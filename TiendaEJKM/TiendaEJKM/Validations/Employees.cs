using FluentValidation;
using TiendaEJKM.Models;

namespace TiendaEJKM.Validations
{
    public class Employees : AbstractValidator<EmployeesModel>
    {
        public Employees()
        {
            RuleFor(employees => employees.Name_Employee)
                .NotNull().WithMessage("Debe de ingresar el nombre ")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Debe de ingresar minimo 3 letras ")
                .MaximumLength(25).WithMessage("Solo se permite ingresar 50 caracteres");


            RuleFor(employees => employees.Address_Employee)
                .NotNull().WithMessage("El campo no debe de estar vacio")
                .NotEmpty()
                .MaximumLength(50).WithMessage("Solo se permite ingresar 50 caracteres");;

            RuleFor(employees => employees.Phone_Employee)
                .NotNull().WithMessage("El teléfono no debe de estar vacio")
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(20);

        }
    }
}
