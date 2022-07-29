using Microsoft.AspNetCore.Components;
using RacingCars.VMs;
using RacingCars.Interfaces;
using RacingCars.Models;
using RacingCars.VMs;
namespace RacingCars.Pages.Races
{
    public partial class Index : ComponentBase
    {
        [Inject]
        IPilotService pilotService { get; set; } = default!;
        [Inject]
        ICarService carService { get; set; } = default!;
        [Inject]
        IRaceService raceService { get; set; } = default!;
        
        RaceVM race = new RaceVM();
        List<PilotVM> pilots = new List<PilotVM>();
        List<Car> cars = new List<Car>();
        private PilotVM selectedPilot = new PilotVM();
        private Car selectedCar = new Car();

        private bool VisibilityInfoDialog { get; set; } = false;
        private void OkClicked() => VisibilityInfoDialog = false;
        protected override void OnInitialized()
        {
            pilots = pilotService.GetPilots();
            cars = carService.GetCars();
        }
        List<string> tracks = new List<string>()
    {
         "Kyalami" ,
         "Pescara",
         "Hockenheim" ,
         "Nurburgring " ,
         "Spa" ,
         "Suzuka" ,
         "Circuit de la Sarthe",
         "Mount Panorama" ,
          "Laguna Seca",
          "Monaco",
          "Monza",
          "Silverstone",
          "Interlagos"
    };
        private void InsertRace()
        {
            raceService.InsertRace(race);
            selectedPilot = pilots.FirstOrDefault(p => p.Id == race.IdPilot);
            selectedCar = cars.FirstOrDefault(c => c.Id == race.IdCar);
            UpdateTables();
        }
        private void UpdateTables()
        {
            CarVM carVM = new CarVM()
            {
                Id = selectedCar.Id,
                Name = selectedCar.Name,
                Brand = selectedCar.Brand,
                Mileage = selectedCar.Mileage,
                DateOfService = Convert.ToDateTime(selectedCar.DateOfService),
                CarRaces = selectedCar.CarRaces
            };
            selectedPilot.Points += race.Points;
            selectedCar.Mileage += race.Mileage;
            pilotService.UpdatePilot(selectedPilot.Id, selectedPilot);
            carService.UpdateCar(selectedCar.Id, carVM);
        }
        private void HandleValidSubmit()
        {
            InsertRace();
            VisibilityInfoDialog = true;
            // Process the valid form
        
        }
    }
}
