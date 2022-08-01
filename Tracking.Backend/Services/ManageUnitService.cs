using System.Threading.Tasks;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class ManageUnitService : IManageUnitService
    {
        public Task<int> Create(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(int id, string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
