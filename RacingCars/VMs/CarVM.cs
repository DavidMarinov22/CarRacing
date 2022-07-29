using RacingCars.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacingCars.VMs
{
    public class CarVM
    {
        public CarVM()
        {
            CarRaces = new List<Race>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Name is too long!")]
        public string Name { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Brand is too long!")]
        public string Brand { get; set; }

        [Required]
        [Range(1, 999999, ErrorMessage = "Mileage should be a number between (1-999999).")]
        public long Mileage { get; set; } = default;

        [Required]
        public DateTime DateOfService { get; set; } = DateTime.Now; 

        public List<Race> CarRaces { get; set; }
    }
}
