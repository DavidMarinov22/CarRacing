using Microsoft.AspNetCore.Components;
using RacingCars.Interfaces;
using RacingCars.VMs;

namespace RacingCars.Pages.Pilots
{
    public partial class EditPilot : ComponentBase
    {
        [Inject]
        IPilotService pilotService { get; set; } = default!;
        [Inject]
        NavigationManager navmanager { get; set; } = default!;

        [Parameter]
        public PilotVM pilot { get; set; }
        private List<string> nationalities = new List<string>()
    {
        "   French ",
        "American	",
        "Chinese   ",
        "Spanish   ",
        "Italian   ",
        "Turkish   ",
        "British 	",
        "German    ",
        "Russian 	",
        "Malaysians",
        "Bulgarian ",
         "Australian",
         "Chinese" ,
         "Croatian" ,
         "Irish",
         "Mexican" ,
          "Polish",
          "Romanian",
          "Serbian",
          "Other"
    };
        private void HandleValidSubmit()
        {
            UpdatePilot();
            Navigate();
            // Process the valid form
        }
        private void UpdatePilot()
        {
            pilotService.UpdatePilot(pilot.Id, pilot);
        }
        private void Navigate()
        {
            navmanager.NavigateTo("/Pilots/Index", forceLoad: true);
        }
    }
}
