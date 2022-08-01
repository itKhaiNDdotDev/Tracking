using System.Threading.Tasks;
using Tracking.Backend.DTOs;

namespace Tracking.Backend.Services.InterfaceDIServices
{
    public interface IAtmTechnicanService
    {
        Task<int> Create(AtmTechnicanRequest req);
        Task<int> Update(int id, AtmTechnicanRequest req);
    }
}
