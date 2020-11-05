using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDI.Models;
using TestDI.Views;
using Xamarin.Forms;

namespace TestDI.ViewModels
{
    public class UsersViewModel
    {
        public INavigation Navigation { get; set; }

        public ICommand GoToAddUserCommand { private set; get; }
        
        public ICommand GoToLoginCommand { private set; get; }

        public UsersViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GoToAddUserCommand = new Command(async () => await GoToAddUser());
            GoToLoginCommand = new Command(async () => await GoToLogin());
        }

        async Task GoToAddUser()
        {
            var addUserView = new AddUserView();
            await Navigation.PushAsync(addUserView);
        }

        async Task GoToLogin()
        {
            var loginView = new NavigationPage(new LoginView());
            await Navigation.PushModalAsync(loginView);
        }

    }
}
