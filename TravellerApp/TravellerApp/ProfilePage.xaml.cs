using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerApp.Helper;
using TravellerApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravellerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    var postTable = conn.Table<Post>().ToList();
            var postTable = await Firestore.Read();
            postCountLabel.Text = postTable.Count.ToString();
            //var countries = (from p in postTable 
            //                 orderby p.Country 
            //                 select p.Country).Distinct().ToList();
            var countries2 = postTable.OrderBy(p => p.Country).Select(p => p.Country).Distinct().ToList();
            Dictionary<string, int> countriesCount = new Dictionary<string, int>();
            foreach (var country in countries2)
            {
                //var count = (from p in postTable where p.Country == country select p).ToList().Count();
                var count2 = postTable.Where(p => p.Country == country).ToList().Count();
                countriesCount[country] = count2;
            }
            countriesListView.ItemsSource = countriesCount;
        }
    }
}