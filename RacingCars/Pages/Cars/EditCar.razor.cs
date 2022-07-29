using Microsoft.AspNetCore.Components;
using RacingCars.Interfaces;
using RacingCars.VMs;
namespace RacingCars.Pages.Cars
{
    public partial class EditCar : ComponentBase
    {
        [Inject]
        ICarService carService { get; set; } = default!;
        [Inject]
        NavigationManager navmanager { get; set; } = default!;

        [Parameter]
        public CarVM car { get; set; }
        private void HandleValidSubmit()
        {
            UpdatePilot();
            Navigate();
            // Process the valid form
        }
        private void UpdatePilot()
        {
            carService.UpdateCar(car.Id, car);
        }
        private void Navigate()
        {
            navmanager.NavigateTo("/Cars/Index", forceLoad: true);
        }
    }
}
