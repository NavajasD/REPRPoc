using FastEndpoints;
using FluentValidation;

namespace REPRPoc.Endpoints.ValidationTest.Post.V0
{
    public class RequestValidator : Validator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MinimumLength(2).WithMessage("First name must have at least 2 characters");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MinimumLength(2).WithMessage("Last name must have at least 2 characters");
            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Age must be greater than 0.");
        }
    }
}
