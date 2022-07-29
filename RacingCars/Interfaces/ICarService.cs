using RacingCars.Models;
using RacingCars.VMs;

namespace RacingCars.Interfaces
{
    public interface ICarService
    {
        List<Car> GetCars();
        void InsertCar(CarVM pilot);
        void UpdateCar(long id, CarVM pilot);
        CarVM SingleCar(long id);
        void DeleteCar(long id);
    }
}
