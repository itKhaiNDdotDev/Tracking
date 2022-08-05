using System.Threading.Tasks;
using Tracking.Backend.Data;
using Tracking.Backend.Models;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class ManageUnitService : IManageUnitService
    {
        private readonly TrackingDbContext _context;
        public ManageUnitService(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(string name)
        {
            //throw new System.NotImplementedException();
            ManageUnit unit = new ManageUnit()
            {
                Name = name
            };
            _context.ManageUnit.Add(unit);
            await _context.SaveChangesAsync();

            return unit.Id;
        }

        public async Task<int> Update(int id, string name)
        {
            //throw new System.NotImplementedException();
            var unit = await _context.ManageUnit.FindAsync(id);
            if(unit == null)
                return -1;
            unit.Name = name;
            _context.ManageUnit.Update(unit);

            return await _context.SaveChangesAsync();
        }
    }
}
