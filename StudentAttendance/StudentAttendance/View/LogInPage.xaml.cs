using StudentAttendance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentAttendance.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        App globalref = (App)Application.Current;
        ViewModel.LogInVM loginvm;
        public LogInPage()
        {
            InitializeComponent();
           // NavigationPage.SetHasNavigationBar(this, false);
           loginvm = new ViewModel.LogInVM();
           BindingContext = loginvm;
        }

        private async void btnLogIn_Clicked(object sender, EventArgs e)
        {

            loginvm.VerifyStudent();
            if (loginvm.VerifyStudent())
            {
                
                //Navigate
                await Navigation.PushAsync(new ModulesPage(globalref.SelectedStudent));
            }
            else
                await DisplayAlert("Error!", "Either your email or password is incorrect", "OK");
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}