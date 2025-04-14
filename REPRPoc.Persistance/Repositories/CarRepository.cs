using Microsoft.EntityFrameworkCore;
using REPRPoc.Contracts.Persistance.Repositories;
using REPRPoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPRPoc.Persistance.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<IEnumerable<Car>> SearchCarsAsync(string? plate = null, string? maker = null, string? model = null, string? color = null, CancellationToken cancellationToken = default)
        {
            var cars = databaseContext.Cars.AsNoTracking();
            cars = cars.Where(c => !c.IsDeleted);

            if (plate is not null)
                return await cars.Where(c => c.Plate == plate).ToListAsync(cancellationToken);

            if (maker is not null)
                cars = cars.Where(c => c.Maker.ToLower().Contains(maker.ToLower()));

            if (model is not null)
                cars = cars.Where(c => c.Model.ToLower().Contains(model.ToLower()));

            if (color is not null)
                cars = cars.Where(c => c.Color.ToLower().Contains(color.ToLower()));

            return await cars.ToListAsync(cancellationToken);
        }
    }
}
