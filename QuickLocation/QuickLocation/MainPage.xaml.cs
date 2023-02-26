using QuickLocation.Models;
using QuickLocation.Data;
using QuickLocation.Pages;

namespace QuickLocation;

public partial class MainPage : ContentPage
{
	public MainPage()
	{

        InitializeComponent();
	}
    protected override async void OnAppearing()
    {

        base.OnAppearing();
        VehiclesDataBase database = await VehiclesDataBase.Instance;
        listView.ItemsSource = await database.GetItemsAsync();

    }

    async void OnVehicleAdded(object sender, EventArgs e)
    {
        //Adding A new Vehicle
        await Navigation.PushAsync(new NewVehicle
        {
            BindingContext = new Vehicles()
        });
    }

    async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //select from the listed Vehicles
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ViewVehicle
            {
                BindingContext = e.SelectedItem as Vehicles
            });
        }
    }




}

