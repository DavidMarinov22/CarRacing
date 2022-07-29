using Microsoft.AspNetCore.Components;
using RacingCars.Interfaces;
using RacingCars.Models;
using RacingCars.VMs;
namespace RacingCars.Pages.Pilots
{
    public partial class AddPilot : ComponentBase
    {
        [Inject]
        IPilotService pilotService { get; set; } = default!;
        [Inject]
        NavigationManager navmanager { get; set; } = default!;

        private PilotVM pilot = new PilotVM();
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
            InsertPilot();
            Navigate();
            // Process the valid form
        }
        private void InsertPilot()
        {
            pilotService.InsertPilot(pilot);
        }
        private void Navigate()
        {
            navmanager.NavigateTo("/Pilots/Index", forceLoad: true);
        }
    }
}
