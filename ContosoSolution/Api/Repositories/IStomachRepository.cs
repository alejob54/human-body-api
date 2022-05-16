using Api.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IStomachRepository
    {
        Task StoreAsync(NutrientDTO nutrient, CancellationToken cancellationToken = default);
    }
}