using Api.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IStomachService
    {
        Task EatAsync(Food food, CancellationToken cancellationToken = default);
    }
}