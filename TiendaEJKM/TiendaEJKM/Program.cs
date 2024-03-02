using FluentValidation;
using Microsoft.Extensions.Options;
using System.Globalization;
using TiendaEJKM.Data;
using TiendaEJKM.Models;
using TiendaEJKM.Repositories;
using TiendaEJKM.Validations;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<SqlDataAccess>();
builder.Services.AddScoped<IEmployeesRepositories, EmployeesRepositories>();
builder.Services.AddScoped<IProductsRepositories, ProductsRepositories>();
builder.Services.AddScoped<ICustomersRepositories, CustomersRepositories>();
builder.Services.AddScoped<ISalesRepositories, SalesRepositories>();

//Validaciones
builder.Services.AddScoped<IValidator<EmployeesModel>, Employees>();
builder.Services.AddScoped<IValidator<ProductsModel>, Products>();
builder.Services.AddScoped<IValidator<CustomersModel>, Customers>();
builder.Services.AddScoped<IValidator<SalesModel>, Sales>();

//trd
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("es");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
