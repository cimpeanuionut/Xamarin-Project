using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProiectMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToSqLiteDB(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new UsersPage());
        }

        private async void ViewAPI(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new APIUsers());
        }
    }
}
