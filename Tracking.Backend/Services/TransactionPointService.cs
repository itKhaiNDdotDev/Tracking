using System.Threading.Tasks;
using Tracking.Backend.DTOs;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class TransactionPointService : ITransactionPointService
    {
        public Task<int> Create(TransactionPointRequest req)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(int id, TransactionPointRequest req)
        {
            throw new System.NotImplementedException();
        }
    }
}
