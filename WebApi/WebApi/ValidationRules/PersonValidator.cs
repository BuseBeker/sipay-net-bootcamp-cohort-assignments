using FluentValidation;
using System.Text.RegularExpressions;
using WebApi.Controllers;
using WebApi.Model;

namespace WebApi.ValidationRules
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Name)
                .NotEmpty().WithMessage("Staff person name is required.")
                .Length(5, 100).WithMessage("Staff person name must be between 5 and 100 characters.");

            RuleFor(person => person.Lastname)
                .NotEmpty().WithMessage("Staff person lastname is required.")
                .Length(5, 100).WithMessage("Staff person lastname must be between 5 and 100 characters.");

            RuleFor(person => person.Phone)
                .NotEmpty().WithMessage("Staff person phone number is required.")
                .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("Staff person phone number is not valid.");

            RuleFor(person => person.AccessLevel)
                .InclusiveBetween(1, 5).WithMessage("Staff person access level must be between 1 and 5.");

            RuleFor(person => person.Salary)
                .NotEmpty().WithMessage("Staff person salary is required.")
                .InclusiveBetween(5000, 50000).WithMessage("Staff person salary must be between 5000 and 50000.");
        }
    }

}
