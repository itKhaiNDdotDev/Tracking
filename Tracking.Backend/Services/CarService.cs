using System.Threading.Tasks;
using Tracking.Backend.Data;
using Tracking.Backend.DTOs;
using Tracking.Backend.Models;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class CarService : ICarService
    {
        private readonly TrackingDbContext _context;
        public CarService(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CarRequest req)
        {
            //throw new System.NotImplementedException();
            Car car = new Car()
            {
                LicensePlate = req.LicensePlate,
                Type = req.Type,
                DeviceId = req.DeviceId,
                DriverId = req.DriverId,
                FirstCam = req.FirstCam,
                FirstCamRotation = req.FirstCamRotation,
                Fuel = req.Fuel,
                FuelType = req.FuelType,
                LimitedSpeed = req.LimitedSpeed,
                NumberCamera = req.NumberCamera,
                SecondCamRotation = req.SecondCamRotation,
                UnitId = req.UnitId,
                Uom = req.Uom
            };
            _context.Car.Add(car);
            await _context.SaveChangesAsync();

            return car.Id;
        }

        public async Task<int> Update(int id, CarRequest req)
        {
            //throw new System.NotImplementedException();
            var car = await _context.Car.FindAsync(id);
            if(car == null)
                return -1;
           car.LicensePlate = req.LicensePlate;
            car.Type = req.Type;
            car.DeviceId = req.DeviceId;
            car.DriverId = req.DriverId;
            car.FirstCam = req.FirstCam;
            car.FirstCamRotation = req.FirstCamRotation;
            car.Fuel = req.Fuel;
            car.FuelType = req.FuelType;
            car.LimitedSpeed = req.LimitedSpeed;
            car.NumberCamera = req.NumberCamera;
            car.SecondCamRotation = req.SecondCamRotation;
            car.UnitId = req.UnitId;
            car.Uom = req.Uom;
            _context.Car.Update(car);

            return await _context.SaveChangesAsync();
        }
    }
}
