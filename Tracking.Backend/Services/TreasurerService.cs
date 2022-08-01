using System.Threading.Tasks;
using Tracking.Backend.DTOs;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class TreasurerService : ITreasurerService
    {
        public Task<int> Create(TreasurerRequest req)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(int id, TreasurerRequest req)
        {
            throw new System.NotImplementedException();
        }
    }
}
