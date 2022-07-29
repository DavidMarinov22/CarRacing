using RacingCars.Models;

namespace RacingCars.Interfaces
{
    public interface IPilot
    {
        int Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        string Nationality { get; set; }
        int Points { get; set; }
        public List<Race> PilotRaces { get; set; }
    }
}
