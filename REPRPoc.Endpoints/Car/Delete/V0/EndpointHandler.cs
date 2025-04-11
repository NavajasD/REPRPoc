using FastEndpoints;
using Microsoft.AspNetCore.Http;
using REPRPoc.Contracts.Persistance.Repositories;
namespace REPRPoc.Endpoints.Car.Delete.V0
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
            Delete("/car/{CarId}");
            Roles("Manager");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var car = await carRepository.FirstOrDefaultAsync(c => c.Id == req.CarId);

            if (car is null)
            {
                await SendResultAsync(Results.NotFound("Car not found"));
                return;
            }
            
            carRepository.SoftDelete(car, req.UserId);

            await carRepository.UnitOfWork.SaveChangesAsync(ct);

            await SendOkAsync(ct);
        }
    }
}
