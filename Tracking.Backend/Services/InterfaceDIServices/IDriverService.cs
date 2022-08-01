using System.Threading.Tasks;
using Tracking.Backend.DTOs;

namespace Tracking.Backend.Services.InterfaceDIServices
{
    public interface IDriverService
    {
        Task<int> Create(DriverRequest req);
        Task<int> Update(int id, DriverRequest req);
    }
}
