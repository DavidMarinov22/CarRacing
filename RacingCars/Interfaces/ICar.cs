using RacingCars.Models;

namespace RacingCars.Interfaces
{
    public interface ICar
    {
        int Id { get; set; }
        string Name { get; set; }
        string Brand { get; set; }
        long Mileage { get; set; }
        string DateOfService { get; set; }
        List<Race> CarRaces { get; set; }
    }
}
