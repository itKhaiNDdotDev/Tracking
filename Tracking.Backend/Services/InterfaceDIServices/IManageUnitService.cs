using System.Threading.Tasks;

namespace Tracking.Backend.Services.InterfaceDIServices
{
    public interface IManageUnitService
    {
        Task<int> Create(string name);
        Task<int> Update(int id, string name);
    }
}
