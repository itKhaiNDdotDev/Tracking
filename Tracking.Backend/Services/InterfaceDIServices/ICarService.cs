using System.Threading.Tasks;
using Tracking.Backend.DTOs;

namespace Tracking.Backend.Services.InterfaceDIServices
{
    public interface ICarService
    {
        Task<int> Create(CarRequest req);
        Task<int> Update(int id, CarRequest req);
    }
}
