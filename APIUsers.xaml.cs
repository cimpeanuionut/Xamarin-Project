using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectMobile
{
    

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class APIUsers : ContentPage
	{
        private const string Url = "http://jsonplaceholder.typicode.com/users";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<UserAPI> _userAPI;

        public APIUsers ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var users = JsonConvert.DeserializeObject<List<UserAPI>>(content);
            _userAPI = new ObservableCollection<UserAPI>(users);            
            usersListView.ItemsSource = _userAPI;
                       
            
            base.OnAppearing();
        }       
    }
}