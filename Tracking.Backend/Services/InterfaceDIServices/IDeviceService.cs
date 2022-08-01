using System.Threading.Tasks;
using Tracking.Backend.DTOs;

namespace Tracking.Backend.Services.InterfaceDIServices
{
    public interface IDeviceService
    {
        Task<int> Create(DeviceRequest req);
        Task<int> Update(int id, DeviceRequest req);
    }
}
