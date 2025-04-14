using FastEndpoints;
using Microsoft.AspNetCore.Http;
using REPRPoc.Contracts.Persistance.Repositories;
namespace REPRPoc.Endpoints.Car.Get.V0
{
    public class EndpointHandler : Endpoint<Request, Response, CarMapper>
    {
        private readonly ICarRepository carRepository;

        public EndpointHandler(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        public override void Configure()
        {
            Get("/car/{CarId}");
            AllowAnonymous();
            ResponseCache(60);
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var car = await carRepository.FirstOrDefaultAsync(c => c.Id == req.CarId && !c.IsDeleted, ct);

            if (car is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
                
            Response.Car = Map.FromEntity(car);

            await SendOkAsync(Response, ct);
        }
    }
}
