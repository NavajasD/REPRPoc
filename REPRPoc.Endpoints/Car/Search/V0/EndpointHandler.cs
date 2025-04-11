using FastEndpoints;
using Microsoft.AspNetCore.Http;
using REPRPoc.Contracts.Persistance.Repositories;
using REPRPoc.Dtos.Car;
namespace REPRPoc.Endpoints.Car.Search.V0
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
            Get("/car");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var cars = await carRepository.SearchCarsAsync(req.Plate, req.Maker, req.Model, req.Color, ct);

            Response.Cars = cars.Select(c => new CarDto
            {
                Plate = c.Plate,
                Maker = c.Maker,
                Model = c.Model,
                Color = c.Color,
            }).ToList();

            await SendOkAsync(Response, ct);
        }
    }
}
