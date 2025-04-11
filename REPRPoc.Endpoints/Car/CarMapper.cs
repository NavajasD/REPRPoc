using FastEndpoints;
using REPRPoc.Dtos.Car;
namespace REPRPoc.Endpoints.Car
{
    public class CarMapper : Mapper<CarDto, CarDto, Entities.Car>
    {
        public override CarDto FromEntity(Entities.Car e)
        {
            return new CarDto
            {
                Plate = e.Plate,
                Maker = e.Maker,
                Model = e.Model,
                Color = e.Color
            };
        }

        public override Entities.Car ToEntity(CarDto r)
        {
            return new Entities.Car
            {
                Plate = r.Plate,
                Maker = r.Maker,
                Model = r.Model,
                Color = r.Color
            };
        }
    }
}
