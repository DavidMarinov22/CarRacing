using RacingCars.Interfaces;
using RacingCars.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacingCars.VMs
{
    [Table("PilotsDb")]
    public class PilotVM : IPilot
    {
        public PilotVM()
        {
            PilotRaces = new List<Race>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Name is too long!")]
        public string Name { get; set; }

        [Required]
        [Range(18, 60, ErrorMessage = "Age should be a number between (18-60).")]
        public int Age { get; set; }

        [Required]
        public string Nationality { get; set; }
        public int Points { get; set; } = 0;
        public List<Race> PilotRaces { get; set; }
    }
}
