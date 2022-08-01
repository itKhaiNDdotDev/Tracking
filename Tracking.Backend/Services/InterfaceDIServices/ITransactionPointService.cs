using System.Threading.Tasks;
using Tracking.Backend.DTOs;

namespace Tracking.Backend.Services.InterfaceDIServices
{
    public interface ITransactionPointService
    {
        Task<int> Create(TransactionPointRequest req);
        Task<int> Update(int id, TransactionPointRequest req);
    }
}
