using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TiendaEJKM.Validations
{
    public static class Extensions
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            //r.mError
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
