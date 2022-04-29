using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerApp.Logic;
using TravellerApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravellerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        Plugin.Geolocator.Abstractions.Position position;
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            position = await locator.GetPositionAsync();
            var location = await LocationLogic.GetLocation(position.Latitude, position.Longitude);
            locationListView.ItemsSource = location;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var selectedLocation = locationListView.SelectedItem as Address;
                var firstCategory = selectedLocation.address;
                Post post = new Post()
                {
                    Experience = experienceEntry.Text,
                    Address = firstCategory.freeformAddress,
                    Country = firstCategory.country,
                    Municipality = firstCategory.municipality,
                    Latitude = position.Latitude,
                    Longitude = position.Longitude
                };
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    int rows = conn.Insert(post);
                    if (rows > 0)
                        DisplayAlert("Success", "Experience successfully inserted", "OK");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}