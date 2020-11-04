using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersList : ContentPage
    {
        public UsersList()
        {
            InitializeComponent();
            Users.ItemsSource = Singleton.GetInstance().Users;
        }

        private async void OnClickAddUserPage(object sender, EventArgs e)
        {
            // Psuh page
            var addUserPage = new AddUserPage();
            await Navigation.PushAsync(addUserPage);
        }

        private async void OnClickLoginPage(object sender, EventArgs e)
        {
            // Psuh page
            var mainPage = new MainPage();
            await Navigation.PushModalAsync(mainPage);
        }
    }
}