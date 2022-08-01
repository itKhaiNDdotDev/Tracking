using System.Threading.Tasks;
using Tracking.Backend.DTOs;

namespace Tracking.Backend.Services.InterfaceDIServices
{
    public interface IRfidService
    {
        Task<int> Create(RfidRequest req);
        Task<int> Update(int id, RfidRequest req);
    }
}
