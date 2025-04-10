using REPRPoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPRPoc.EntitySeeds
{
    public static class CarSeeds
    {
        public static List<Car> InitialSeed = new List<Car>()
        {
            new Car
            {
                Id = Guid.Parse("e9b22bae-3afd-43e5-b739-174f74523055"),
                Created = DateTime.SpecifyKind(DateTime.Parse("2025-04-10T21:27:37Z"), DateTimeKind.Utc),
                LastModifiedBy = SeedUserId.Id,
                Plate = "ABC-1234",
                Maker = "Toyota",
                Model = "Corolla",
                Color = "Red"
            },
            new Car
            {
                Id = Guid.Parse("8bd7635e-d72a-4d63-b209-be88c72448e7"),
                Created = DateTime.SpecifyKind(DateTime.Parse("2025-04-10T21:27:37Z"), DateTimeKind.Utc),
                LastModifiedBy = SeedUserId.Id,
                Plate = "XYZ-5678",
                Maker = "Honda",
                Model = "Civic",
                Color = "Blue"
            },
        };
    }
}
