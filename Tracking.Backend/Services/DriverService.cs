using System.Threading.Tasks;
using Tracking.Backend.DTOs;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class DriverService : IDriverService
    {
        public Task<int> Create(DriverRequest req)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(int id, DriverRequest req)
        {
            throw new System.NotImplementedException();
        }
    }
}
