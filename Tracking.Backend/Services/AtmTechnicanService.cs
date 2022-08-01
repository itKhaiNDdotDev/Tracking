using System.Threading.Tasks;
using Tracking.Backend.Data;
using Tracking.Backend.DTOs;
using Tracking.Backend.Models;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class AtmTechnicanService : IAtmTechnicanService
    {
        private readonly TrackingDbContext _context;
        public AtmTechnicanService(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(AtmTechnicanRequest req)
        {
            //throw new System.NotImplementedException();
            AtmTechnican atmTechnican = new AtmTechnican()
            {
                Image = req.Image,
                EmployeeCode = req.EmployeeCode,
                Name = req.Name,
                Gender = req.Gender,
                PhoneNumber = req.PhoneNumber,
                Email = req.Email,
                RfidId = req.RfidId,
                UnitId = req.UnitId,
                OffJob = req.OffJob
            };
            _context.AtmTechnican.Add(atmTechnican);
            await _context.SaveChangesAsync();

            return atmTechnican.Id;

        }

        public async Task<int> Update(int id, AtmTechnicanRequest req)
        {
            //throw new System.NotImplementedException();
            var atmTechnican = await _context.AtmTechnican.FindAsync(id);
            if (atmTechnican == null)
                return -1;
            atmTechnican.Image = req.Image;
            atmTechnican.EmployeeCode = req.EmployeeCode;
            atmTechnican.Name = req.Name;
            atmTechnican.Gender = req.Gender;
            atmTechnican.PhoneNumber = req.PhoneNumber;
            atmTechnican.Email = req.Email;
            atmTechnican.RfidId = req.RfidId;
            atmTechnican.UnitId = req.UnitId;
            atmTechnican.OffJob = req.OffJob;
            _context.AtmTechnican.Update(atmTechnican);

            return await _context.SaveChangesAsync();
        }
    }
}
