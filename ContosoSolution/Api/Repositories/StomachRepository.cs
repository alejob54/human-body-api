using Api.Data;
using Api.DTOs;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class StomachRepository : IStomachRepository
    {
        private readonly HumanBodyContext _dbContext;

        public StomachRepository(HumanBodyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task StoreAsync(NutrientDTO nutrient, CancellationToken cancellationToken = default)
        {
            nutrient.NutrientType = _dbContext.NutrientTypes.First(m => m.Id == nutrient.NutrientType.Id);
            await _dbContext.AddAsync(nutrient, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
