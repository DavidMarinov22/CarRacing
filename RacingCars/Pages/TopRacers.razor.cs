using Microsoft.AspNetCore.Components;
using RacingCars.Interfaces;
using RacingCars.VMs;

namespace RacingCars.Pages
{
    public partial class TopRacers : ComponentBase
    {
        [Inject]
        IPilotService pilotService { get; set; } = default!;
        public List<PilotVM>? pilots { get; set; }
        protected override void OnInitialized()
        {
             pilots = pilotService.GetPilots().OrderByDescending(p => p.Points).ThenBy(p => p.Name).ToList();
        }

    }
}
