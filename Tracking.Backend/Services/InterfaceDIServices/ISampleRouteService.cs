using System.Threading.Tasks;
using Tracking.Backend.DTOs;

namespace Tracking.Backend.Services.InterfaceDIServices
{
    public interface ISampleRouteService
    {
        Task<int> Create(SampleRouteRequest req);
        Task<int> Update(int id, SampleRouteRequest req);
    }
}
