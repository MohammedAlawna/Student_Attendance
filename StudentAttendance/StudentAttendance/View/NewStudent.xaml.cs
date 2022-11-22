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
    public partial class NewStudent : ContentPage
    {
        ViewModel.NewStudentVM newstudentvm;

        public NewStudent()
        {
            InitializeComponent();
            newstudentvm = new ViewModel.NewStudentVM();
            BindingContext = newstudentvm;
        }
       
        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(newstudentvm.EmailAdd))
            {
                return;
            }
            // Save a new person
            newstudentvm.SavePerson();
            // Navigate back to previous page
            await Navigation.PopAsync();
        }
        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
       
    }
}