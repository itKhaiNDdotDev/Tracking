using System.Threading.Tasks;
using Tracking.Backend.DTOs;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class RfidService : IRfidService
    {
        public Task<int> Create(RfidRequest req)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(int id, RfidRequest req)
        {
            throw new System.NotImplementedException();
        }
    }
}
