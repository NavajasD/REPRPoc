using FastEndpoints;
using FluentValidation;

namespace REPRPoc.Endpoints.Car.Post.V0
{
    public class RequestValidator : Validator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Car.Plate)
                .NotEmpty().WithMessage("Car plate is required.")
                .MinimumLength(7).WithMessage("Car plate must have at least 7 characters")
                .Matches(@"^[A-Z]{3}-\d{3}$").WithMessage("Car plate must follow the format ABC-123.");

            RuleFor(x => x.Car.Maker)
                .NotEmpty().WithMessage("Car maker is required.");

            RuleFor(x => x.Car.Model)
                .NotEmpty().WithMessage("Car model is required.");

            RuleFor(x => x.Car.Color)
                .NotEmpty().WithMessage("Car color is required.");
        }
    }
}
