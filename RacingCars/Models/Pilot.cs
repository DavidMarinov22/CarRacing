using RacingCars.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RacingCars.Models
{
    public class Pilot : IPilot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public int Points { get; set; }
        public List<Race> PilotRaces { get; set; }
    }
}
