using System.Threading.Tasks;
using Tracking.Backend.DTOs;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class SampleRouteService : ISampleRouteService
    {
        public Task<int> Create(SampleRouteRequest req)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(int id, SampleRouteRequest req)
        {
            throw new System.NotImplementedException();
        }
    }
}
