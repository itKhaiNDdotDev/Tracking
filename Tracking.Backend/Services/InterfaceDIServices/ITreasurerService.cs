using System.Threading.Tasks;
using Tracking.Backend.DTOs;

namespace Tracking.Backend.Services.InterfaceDIServices
{
    public interface ITreasurerService
    {
        Task<int> Create(TreasurerRequest req);
        Task<int> Update(int id, TreasurerRequest req);
    }
}
