using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDI.Views;
using Xamarin.Forms;

namespace TestDI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public String _userName = "test";

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }

        public String _password = "test";

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        private String _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public INavigation Navigation { get; set; }

        public ICommand LoginCommand { private set; get; }
        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            LoginCommand = new Command(async () => await Login());
        }

        async Task Login()
        {
            // Get users
            var users = Singleton.GetInstance().Users;

            // Get user if exists
            var user = users.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();

            // Validate user
            if (user != null)
            {
                // Push page
                var usersView = new NavigationPage(new UsersView());
                await Navigation.PushModalAsync(usersView);
            }
            else
            {
                // Show error message
                ErrorMessage = "Passoword Invalid or whatever!";
            }
        }

    }
}
