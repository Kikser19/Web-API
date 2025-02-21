using Aspekt.Application.Request_Models.Company_Request;
using FluentValidation;

namespace Aspekt.Application.Validators.Company_Validator
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyRequest>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(100).WithMessage("Company name must be at most 100 characters.");
        }
    }
}
