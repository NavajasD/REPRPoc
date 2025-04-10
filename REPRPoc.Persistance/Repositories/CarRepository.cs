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
    }
}
