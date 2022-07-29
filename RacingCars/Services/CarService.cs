using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RacingCars.Data;
using RacingCars.Interfaces;
using RacingCars.Models;
using RacingCars.VMs;
using System.Linq;

namespace RacingCars.Services
{
    public class CarService : Controller, ICarService
    {
         private readonly DBContext _context;
        public CarService(DBContext context)
        {
            _context = context;
        }

        public void DeleteCar(long id)
        {
            Car car = _context.Cars.FirstOrDefault(p => p.Id == id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }

        public List<Car> GetCars()
        {
            return _context.Cars.ToList(); ;
        }

        public void InsertCar(CarVM carVM)
        {
            Car testCar = _context.Cars.FirstOrDefault((c) => (c.Name == carVM.Name));
            if (testCar == null)
            {
                Car car = ToCar(carVM);
                _context.Cars.Add(car);
                _context.SaveChanges();
            }
        }

        public CarVM SingleCar(long id)
        {
            Car car = _context.Cars.FirstOrDefault((c) => (c.Id == id));
            return new CarVM()
            {
                Id = car.Id,
                Name = car.Name,
                Brand = car.Brand,
                Mileage = car.Mileage,
                DateOfService = Convert.ToDateTime(car.DateOfService),
                CarRaces = car.CarRaces
            };
        }

        public void UpdateCar(long id, CarVM car)
        {
            Car data = ToCar(car);
            var local = _context.Set<Car>().Local.FirstOrDefault(entry => entry.Id.Equals(data.Id));
            // check if local is not null
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private Car ToCar(CarVM car)
        {
            return new Car()
            {
                Id = car.Id,
                Name = car.Name,
                Brand = car.Brand,
                Mileage = car.Mileage,
                DateOfService = car.DateOfService.ToShortDateString(),
                CarRaces = car.CarRaces
            };
        }
    
    }
}
