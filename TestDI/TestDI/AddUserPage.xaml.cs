using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserPage : ContentPage
    {
        public AddUserPage()
        {
            InitializeComponent();
        }

        async void OnClickAddUser(object sender, EventArgs args)
        {
            // Validate fields
            if (Username.Text == null || Password.Text == null)
            {
                errorMessage.Text = "Username and Password must not be empty.";
                return;
            }

            // Validate password
            if (!Regex.IsMatch(Password.Text, "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{6,})"))
            {
                errorMessage.Text = "The password you entered is invalid.";
                return;
            }

            // Add user to the list
            Singleton.GetInstance().AddUser(Username.Text, Password.Text);
            await Navigation.PopAsync();
        }
    }
}