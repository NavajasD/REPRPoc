﻿using FastEndpoints;
using Microsoft.AspNetCore.Http;
using REPRPoc.Contracts.Persistance.Repositories;
using REPRPoc.Endpoints.PreProcessors;
namespace REPRPoc.Endpoints.Car.Put.V0
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
            Put("/car");
            Roles("Manager");
            PreProcessor<RequestLogger<Request>>();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var car = await carRepository.FirstOrDefaultAsync(c => c.Id == req.CarId);

            if (car is null)
            {
                await SendResultAsync(Results.NotFound("Car not found"));
                return;
            }

            var plateExists = await carRepository.ExistsAsync(c => 
            c.Plate == req.Car.Plate &&
            c.Id != req.CarId, 
            ct);

            if (plateExists)
            {
                await SendResultAsync(Results.Conflict("The car plate already exists"));
                return;
            }
            
            car.Plate = req.Car.Plate;
            car.Maker = req.Car.Maker;
            car.Model = req.Car.Model;
            car.Color = req.Car.Color;

            carRepository.Update(car, req.UserId);
            await carRepository.UnitOfWork.SaveChangesAsync(ct);

            await SendOkAsync(ct);
        }
    }
}
