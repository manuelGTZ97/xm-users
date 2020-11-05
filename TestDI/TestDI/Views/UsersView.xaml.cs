using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersView : ContentPage
    {
        public UsersView()
        {
            InitializeComponent();
            BindingContext = new UsersViewModel(Navigation);
            Users.ItemsSource = Singleton.GetInstance().Users;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}