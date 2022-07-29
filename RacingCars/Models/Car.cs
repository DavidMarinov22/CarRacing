using RacingCars.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacingCars.Models
{
    [Table("CarsDb")]
    public class Car : ICar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public long Mileage { get; set; } = 0;
        public string DateOfService { get; set; }
        public List<Race> CarRaces { get; set; }
    }
}
