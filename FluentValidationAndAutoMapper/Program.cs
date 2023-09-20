// See https://aka.ms/new-console-template for more information
using AutoMapper;
using FluentValidation;
using FluentValidationAndAutoMapper.Entity;
using FluentValidationAndAutoMapper.Enums;
using FluentValidationAndAutoMapper.Models;
using FluentValidationAndAutoMapper.Profiles;
using FluentValidationAndAutoMapper.Validators;

Console.WriteLine("Hello, World!");
var mapper = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<CompanyProfile>();
    cfg.AddProfile<CarProfile>();
}).CreateMapper();

var companyValidator = new CompanyBindingValidator();

var companyBindings = new CompanyBindingModel(); //Empty properties

Company company = null;


if (ValidateModel(companyBindings, companyValidator))
{
    company = SaveCompany(companyBindings);
}

Console.WriteLine("Press any key to continue...");
Console.ReadKey(true);

companyBindings.Name = new string('?', 51); //More than 50 symbols
companyBindings.Address = new string('?', 201); //More than 200 symbols
companyBindings.Email = "companyagmail.com"; //Not an email
companyBindings.Phone = "9828374811"; //Not enought numbers

if (ValidateModel(companyBindings, companyValidator))
{
    company = SaveCompany(companyBindings);
}

Console.WriteLine("Press any key to continue...");
Console.ReadKey(true);

companyBindings.Name = "McDonalds"; //Correct
companyBindings.Address = "Kyiv, Some street, 34"; //Correct
companyBindings.Email = "mcdonalds@gmail.com"; //Correct
companyBindings.Phone = "380442637463"; //Correct

if (ValidateModel(companyBindings, companyValidator))
{
    company = SaveCompany(companyBindings);
}

Console.WriteLine("Press any key to continue...");
Console.ReadKey(true);
Console.WriteLine("Mapping company to view model");

var companyViewModel = mapper.Map<CompanyViewModel>(company);

Console.WriteLine(companyViewModel.Name);
Console.WriteLine(companyViewModel.EmailAndPhone);

Console.WriteLine("Press any key to continue...");
Console.ReadKey(true);

var carBinding = new CarBindingModel();

var carValidator = new CarBindingValidator();

Car car;

if (ValidateModel(carBinding, carValidator))
{
    car = SaveCar(carBinding);
}

Console.WriteLine("Press any key to continue...");
Console.ReadKey(true);

carBinding.Make = "BYD";
carBinding.Model = "Yuan Pro";
carBinding.CarType = (CarType)11;
carBinding.SeatsNumber = 9;

if (ValidateModel(carBinding, carValidator))
{
    car = SaveCar(carBinding);
}

Console.WriteLine("Press any key to continue...");
Console.ReadKey(true);

carBinding.Make = "BYD";
carBinding.Model = "Yuan Pro";
carBinding.CarType = CarType.HatchBack;
carBinding.SeatsNumber = 5;

if (ValidateModel(carBinding, carValidator))
{
    car = SaveCar(carBinding);
}

Console.WriteLine("Press any key to continue...");
Console.ReadKey();

bool ValidateModel<T>(T model, AbstractValidator<T> validator)
{
    var validationResults = validator.Validate(model);

    if (!validationResults.IsValid)
    {
        foreach (var error in validationResults.Errors)
        {
            Console.WriteLine(error);
        }
        return false;
    }
    return true;
}

Car SaveCar(CarBindingModel carBinding)
{
    var car = mapper.Map<Car>(carBinding);
    Console.WriteLine("Car saved");
    Console.WriteLine(car.Make);
    Console.WriteLine(car.Model);
    Console.WriteLine(car.CarType);
    Console.WriteLine("Number of seats " + car.SeatsNumber);

    return car;
}

Company SaveCompany(CompanyBindingModel companyBindings)
{
    var company = mapper.Map<Company>(companyBindings);

    Console.WriteLine("Company saved");
    Console.WriteLine(company.Name);
    Console.WriteLine(company.Address);
    Console.WriteLine(company.Email);
    Console.WriteLine(company.Phone);

    return company;
}