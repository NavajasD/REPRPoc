using FastEndpoints;
using FluentValidation;

namespace REPRPoc.Endpoints.Car.Delete.V0
{
    public class RequestValidator : Validator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.CarId)
                .NotEmpty().WithMessage("Car ID is required.")
                .Must(x => x != Guid.Empty).WithMessage("Car ID cannot be empty.");
        }
    }
}
