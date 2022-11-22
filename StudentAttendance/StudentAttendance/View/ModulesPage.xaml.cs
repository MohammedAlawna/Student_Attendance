using StudentAttendance.Model;
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
    public partial class ModulesPage : ContentPage
    {
        App globalref = (App)Application.Current;
        ViewModel.ModulesPageVM modulesvm;
        public ModulesPage(Student student)
        {
            InitializeComponent();

            globalref.SelectedStudent = student;

            modulesvm = new ViewModel.ModulesPageVM();
            BindingContext = modulesvm;

        }

        private async void lvmodules_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvmodules.SelectedItem != null)
            {
                globalref.SelectedModule = e.SelectedItem as Module;

                await Navigation.PushAsync(new ModuleDetails());
            }

        }

        private void btnLogOut_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}