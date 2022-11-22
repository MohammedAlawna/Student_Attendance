using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using SQLite;

namespace StudentAttendance.ViewModel
{

    public class AllStudentsVM : INotifyPropertyChanged
    {
        App globalref = (App)Application.Current; // Make reference to the global class

        Model.DatabaseAccess newDBInstance;
       
        public AllStudentsVM()
        {

            // Create an instance of the DB Class
            newDBInstance = new Model.DatabaseAccess();
            // Create and add sample data
            Model.Student newStudent = new Model.Student();
            newStudent.FirstName = "Benzema";
            newStudent.LastName = "Karim";
            newStudent.DateofBirth = new DateTime(2000, 01, 01);
           // newDBInstance.AddStudent(newStudent);
            // Load from DB into attribute
            AllStudents = newDBInstance.GetAllStudents();
        }


        private ObservableCollection<Model.Student> allstudents;
        public ObservableCollection<Model.Student> AllStudents
        {
            get
            {
                return allstudents;
            }
            set
            {
                if (value != null)
                { 
                    allstudents = value;
                    OnPropertyChanged("AllStudents");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new
                PropertyChangedEventArgs(propertyname));
            }
        }

        private string searchterm;
        public string SearchTerm
        {
            get
            {
                return searchterm;
            }
            set
            {
                if(value != null)
                {
                    searchterm = value;
                    OnPropertyChanged("SearchTerm");
                    OnSearch();
                }
              
            }
        }
        private void OnSearch()
        {
            var returnedstudents =
            newDBInstance.GetStudentByName(SearchTerm);
            AllStudents= returnedstudents;
        }
    } 
}
