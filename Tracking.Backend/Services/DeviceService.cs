using System.Threading.Tasks;
using Tracking.Backend.DTOs;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class DeviceService : IDeviceService
    {
        public Task<int> Create(DeviceRequest req)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(int id, DeviceRequest req)
        {
            throw new System.NotImplementedException();
        }
    }
}
