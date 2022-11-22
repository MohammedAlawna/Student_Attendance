using StudentAttendance.Model;
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
    public partial class AllStudents : ContentPage
    {
        // Make reference to the global class
        App globalref= (App)Application.Current;

        ViewModel.AllStudentsVM allstudentsvm;
        public AllStudents()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            //base.OnAppearing();
            allstudentsvm = new ViewModel.AllStudentsVM();
            BindingContext = allstudentsvm;
        }
        private async void btnAddStudent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewStudent());
        }

        private async void lvstudent_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvstudent.SelectedItem != null)
            {
                globalref.SelectedStudent = e.SelectedItem as Student;

                await Navigation.PushAsync(new StudentDetails());
            }
        }
    }
}