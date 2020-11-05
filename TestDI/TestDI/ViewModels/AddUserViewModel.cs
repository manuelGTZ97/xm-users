using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDI.Models;
using Xamarin.Forms;

namespace TestDI.ViewModels
{
    class AddUserViewModel : BaseViewModel
    {
        private String _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }

        private String _password;

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

        public ICommand AddUserCommand { private set; get; }

        public AddUserViewModel(INavigation navigation)
        {
            Navigation = navigation;
            AddUserCommand = new Command(async () => await AddUser());
           
        }

        async Task AddUser()
        {
            // Validate fields
            if (UserName == null || Password == null)
            {
                ErrorMessage = "Username and Password must not be empty.";
                return;
            }

            // Validate password
            if (!Regex.IsMatch(Password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{6,})"))
            {
                ErrorMessage = "The password you entered is invalid.";
                return;
            }

            Singleton.GetInstance().Users.Add(new User(UserName, Password));
            await Navigation.PopAsync();
        }
    }
}
