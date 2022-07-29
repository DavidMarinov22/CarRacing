using RacingCars.Interfaces;
using RacingCars.VMs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacingCars.Models
{
    [Table("RacesDb")]
    public class Race : IRace
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(Pilot))]
        public int IdPilot { get; set; }
        public PilotVM Pilot { get; set; }


        [ForeignKey(nameof(Car))]
        public int IdCar { get; set; }
        public Car Car { get; set; }

        public string Track { get; set; }
        public string DateOfCompetition { get; set; }
        public long Mileage { get; set; }
        public string Duration { get; set; }
        public int Points { get; set; }
    }
}
