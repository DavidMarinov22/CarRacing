using RacingCars.Models;
using RacingCars.VMs;

namespace RacingCars.Interfaces
{
    public interface IRace
    {
        int Id { get; set; }

        string Track { get; set; }
        string DateOfCompetition { get; set; }
        int IdPilot { get; set; }
        PilotVM Pilot { get; set; }
        int IdCar { get; set; }
        Car Car { get; set; }

        long Mileage { get; set; }
        string Duration { get; set; }
        int Points { get; set; }
    }
}
