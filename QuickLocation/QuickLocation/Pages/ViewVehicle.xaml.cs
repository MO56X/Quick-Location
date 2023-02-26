using QuickLocation.Data;
using QuickLocation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLocation.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewVehicle : ContentPage
    {
        public ViewVehicle()
        {
            InitializeComponent();
        }

        async void OnDirectionsClicked(object sender, EventArgs e)
        {
            //launching the default GPS App
            var vehicles = (Vehicles)BindingContext;
            VehiclesDataBase database = await VehiclesDataBase.Instance;
            try
            {
                await Map.Default.OpenAsync(vehicles.Latitude,vehicles.Longitude);
                }
                catch (Exception ex)
                {
                // No map application available to open
                await DisplayAlert("Warning", "You Do Not Have A GPS App", "OK");
            }

        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            //Delete the current Vehicle
            var vehicles = (Vehicles)BindingContext;
            VehiclesDataBase database = await VehiclesDataBase.Instance;
            await database.DeleteItemAsync(vehicles);
            await Navigation.PopAsync();
        }


    }
}