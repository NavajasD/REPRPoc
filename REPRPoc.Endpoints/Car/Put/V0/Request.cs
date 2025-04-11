using FastEndpoints;
using REPRPoc.Dtos.Car;

namespace REPRPoc.Endpoints.Car.Put.V0
{
    public class Request
    {
        [FromClaim]
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public CarDto Car { get; set; }
    }
}
