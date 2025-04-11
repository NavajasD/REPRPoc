using REPRPoc.Entities;

namespace REPRPoc.Contracts.Persistance.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        public Task<IEnumerable<Car>> SearchCarsAsync(string? plate = null, string? maker = null, string? model = null, string? color = null, CancellationToken cancellationToken = default);
    }
}
