using FastEndpoints;
using Microsoft.AspNetCore.Http;
using REPRPoc.Contracts.Persistance.Repositories;
using REPRPoc.Endpoints.PreProcessors;
namespace REPRPoc.Endpoints.Car.Post.V0
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
            Post("/car");
            Roles("Manager");
            PreProcessor<RequestLogger<Request>>();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var plateExists = await carRepository.ExistsAsync(c => c.Plate == req.Car.Plate, ct);

            if (plateExists)
            {
                await SendResultAsync(Results.Conflict("The car plate already exists"));
                return;
            }
                
            var carEntity = Map.ToEntity(req.Car);

            await carRepository.AddAsync(carEntity, req.UserId, ct);
            await carRepository.UnitOfWork.SaveChangesAsync(ct);

            await SendOkAsync(ct);
        }
    }
}
