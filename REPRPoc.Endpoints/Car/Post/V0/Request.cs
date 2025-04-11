using FastEndpoints;
using REPRPoc.Dtos.Car;

namespace REPRPoc.Endpoints.Car.Post.V0
{
    public class Request
    {
        [FromClaim]
        public Guid UserId { get; set; }
        public CarDto Car { get; set; }
    }
}
