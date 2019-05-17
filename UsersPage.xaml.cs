using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UsersPage : ContentPage
	{
        private UsersDataAccess dataAccess;
		public UsersPage ()
		{
			InitializeComponent ();
            this.dataAccess = new UsersDataAccess();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = this.dataAccess;
        }

        private void Add_Activated(object sender, EventArgs e)
        {
            this.dataAccess.AddNewUser();
        }

        private void Save_Activated(object sender, EventArgs e)
        {            
            this.dataAccess.SaveUser();           
        }

        private void Delete_Activated(object sender, EventArgs e)
        {
            var currentUser = this.userView.SelectedItem as User;
            if ( currentUser != null)
            {
                this.dataAccess.DeleteUser(currentUser);
            }
        }
    }
}