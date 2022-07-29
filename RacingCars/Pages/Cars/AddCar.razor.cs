using Microsoft.AspNetCore.Components;
using RacingCars.Interfaces;
using RacingCars.VMs;

namespace RacingCars.Pages.Cars
{
    public partial class AddCar : ComponentBase
    {
        [Inject]
        ICarService carService { get; set; } = default!;
        [Inject]
        NavigationManager navmanager { get; set; } = default!;

        string str = "";
        public CarVM car = new CarVM();
        private void HandleValidSubmit()
        {
            InsertCar();
            Navigate();
            // Process the valid form
        }
        private void InsertCar()
        {
            carService.InsertCar(car);
        }
        private void Navigate()
        {
            navmanager.NavigateTo("/Cars/Index", forceLoad: true);
        }
    }
}
