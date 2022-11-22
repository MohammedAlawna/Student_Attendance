using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentAttendance.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentDetails : ContentPage
    {
        ViewModel.StudentDetailsVM studentdetailsvm;
        public StudentDetails()
        {
            InitializeComponent();

            studentdetailsvm = new ViewModel.StudentDetailsVM();
            BindingContext = studentdetailsvm;
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(studentdetailsvm.EmailAdd))
            {
                return;
            }
            
            studentdetailsvm.UpdateStudent();

            await Navigation.PopAsync();
        }
        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            studentdetailsvm.DeleteStudent();
            await Navigation.PopAsync();
        }
    }
}