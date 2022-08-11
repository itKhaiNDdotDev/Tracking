using System.Threading.Tasks;
using Tracking.Backend.DTOs;

namespace Tracking.Backend.Services.InterfaceDIServices
{
    public interface IAssignRouteService
    {
        Task<int> Create(AssignRouteRequest req);
        Task<int> Update(int id, AssignRouteRequest req);
    }
}
