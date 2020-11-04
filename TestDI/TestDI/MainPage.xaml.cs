using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestDI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClickLoginButton(object sender, EventArgs e)
        {
            // Get users
            var users = Singleton.GetInstance().Users;

            // Get user if exists
            var user = users.Where(x => x.UserName == Username.Text && x.Password == Password.Text).FirstOrDefault();

            // Validate user
            if(user != null)
            {
                // Push page
                var usersList = new NavigationPage(new UsersList());
                await Navigation.PushModalAsync(usersList);
            } else
            {
                // Show error message
                errorMessage.Text = "Passoword Invalid or whatever!";
            }
        }
    }
}
