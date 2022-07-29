using Microsoft.AspNetCore.Components;
using RacingCars.Interfaces;
using RacingCars.Models;
using RacingCars.VMs;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Navigations;
namespace RacingCars.Pages.Cars
{
    public partial class Index : ComponentBase
    {
        [Inject]
        ICarService carService { get; set; } = default!;

        private AddCar addPage = new AddCar();
        private EditCar editPage = new EditCar();
        private List<ItemModel> Toolbaritems = new List<ItemModel>();
        private bool isSelect = false;
        private CarVM selectedCar = new CarVM();

        public List<Car>? cars { get; set; }
        private bool VisibilityAddDialog { get; set; } = false;
        private bool VisibilityDeleteDialog { get; set; } = false;
        private bool VisibilityErrorDialog { get; set; } = false;
        private bool VisibilityEditDialog { get; set; } = false;

        private void DeletePilot()
        {
            carService.DeleteCar(selectedCar.Id);
            VisibilityDeleteDialog = false;
            isSelect = false;
            InitializeTable();
        }
        private void CancelDelete() => VisibilityDeleteDialog = false;
        private void ErrorClick() => VisibilityErrorDialog = false;

        protected override async Task OnInitializedAsync()
        {
            InitializeTable();
            Toolbaritems.Add(new ItemModel() { Text = "Add", TooltipText = "Add pilot", PrefixIcon = "e-plus" });
            Toolbaritems.Add(new ItemModel() { Text = "Edit", TooltipText = "Edit pilot", PrefixIcon = "e-edit" });
            Toolbaritems.Add(new ItemModel() { Text = "Delete", TooltipText = "Delete pilot", PrefixIcon = "e-delete" });
            Toolbaritems.Add(new ItemModel() { Text = "Refresh", TooltipText = "Refresh Table", PrefixIcon = "e-refresh" });
        }

        public void RowSelectHandler(RowSelectEventArgs<Car> args)
        {
            isSelect = true;
            selectedCar.Id = args.Data.Id;
            selectedCar.Name = args.Data.Name;
            selectedCar.Brand = args.Data.Brand;
            selectedCar.Mileage = args.Data.Mileage;
            selectedCar.DateOfService = Convert.ToDateTime(args.Data.DateOfService);
        }
        public void DeselectHandler(RowDeselectEventArgs<Car> args) => isSelect = false;

        public async Task OnClicked(Syncfusion.Blazor.Navigations.ClickEventArgs Args)
        {

            if (Args.Item.Text == "Add")
            {
                //prevent the default action 
                Args.Cancel = true;
                //to show customized dialog 
                this.VisibilityAddDialog = true;
                InitializeTable();
            }
            if (Args.Item.Text == "Edit")
            {
                //prevent the default action 
                Args.Cancel = true;
                //to show customized dialog 
                if (isSelect)
                {
                    this.VisibilityEditDialog = true;
                }
                else
                {
                    this.VisibilityErrorDialog = true;
                }
            }
            if (Args.Item.Text == "Delete")
            {
                //prevent the default action 
                Args.Cancel = true;
                //to show customized dialog 
                if (isSelect)
                {
                    this.VisibilityDeleteDialog = true;
                }
                else
                {
                    this.VisibilityErrorDialog = true;
                }
            }
            if (Args.Item.Text == "Refresh")
            {
                //prevent the default action 
                Args.Cancel = true;
                //to show customized dialog 
                InitializeTable();
            }
        }
        private void InitializeTable() => cars = carService.GetCars();
    }
}
