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
    public partial class PostDetailPage : ContentPage
    {
        Post SelectedPost;
        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();
            this.SelectedPost = selectedPost;
            experienceEntry.Text = selectedPost.Experience;
        }

        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Post>();
            //    int rows = conn.Delete(SelectedPost);
            //    if (rows > 0)
            //        DisplayAlert("Success", "Experience successfully deleted", "OK");
            //}
            bool result = await Firestore.Delete(SelectedPost);
            if (result) await Navigation.PopAsync();
        }
    }
}