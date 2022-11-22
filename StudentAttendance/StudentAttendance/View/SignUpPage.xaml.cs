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
    public partial class SignUpPage : ContentPage
    {
        ViewModel.SignUpVM signupvm;
        public SignUpPage()
        {
            InitializeComponent();
            signupvm = new ViewModel.SignUpVM();
            BindingContext = signupvm;
        }

        private async void btnSignUp_Clicked(object sender, EventArgs e)
        {
            signupvm.VerifyStudent();
            if (signupvm.VerifyStudent())
            {
                await DisplayAlert("Saved?", "Saved Successfully", "OK");
            }
            else
                await DisplayAlert("Error!", "Either you are already registered or" +
                    " your records are not available", "OK");

        }
    }
}