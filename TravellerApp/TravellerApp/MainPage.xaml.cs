using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravellerApp
{ 
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("TravellerApp.Assets.Images.plane.png", assembly);
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(userEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passEntry.Text);
            if (!isEmailEmpty && !isPasswordEmpty)
            {
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                // do not navigate
            }
        }
    }
}
