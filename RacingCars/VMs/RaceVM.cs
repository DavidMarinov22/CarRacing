using RacingCars.Interfaces;
using RacingCars.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacingCars.VMs
{
    public class RaceVM
    {
        [Key]
        public int Id { get; set; }
        public int IdPilot { get; set; }
        public PilotVM Pilot { get; set; }
        public int IdCar { get; set; }
        public Car Car { get; set; }

        [Required]
        public string Track { get; set; }

        [Required]
        public DateTime DateOfCompetition { get; set; } = DateTime.Now;

        [Required]
        [Range(1, 999999, ErrorMessage = "Mileage should be a number between (1-999999).")]
        public long Mileage { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Points should be a number between (1-1000).")]
        public int Points { get; set; }
    }
}
