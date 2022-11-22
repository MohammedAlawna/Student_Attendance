using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace StudentAttendance.ViewModel
{
    public class LogInVM
    {

        Model.DatabaseAccess DBInstance = new Model.DatabaseAccess();

        // Make reference to the global class
        App globalref = (App)Application.Current;


        //private string firstname;
        //public string FirstName
        //{
        //    get
        //    {
        //        return firstname;
        //    }
        //    set
        //    {
        //        firstname = value;
        //        // OnPropertyChanged("FirstName");
        //    }
        //}
        //private string lastname;
        //public string LastName
        //{
        //    get
        //    {
        //        return lastname;
        //    }
        //    set
        //    {
        //        lastname = value;
        //        OnPropertyChanged("LastName");
        //    }
        //}
        private string emailAdd;
        public string EmailAdd
        {
            get
            {
                return emailAdd;
            }
            set
            {
                emailAdd = value;
                OnPropertyChanged("EmailAdd");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public bool VerifyStudent()
        {
            //locating the student in our database
            var selectedstudent = DBInstance.VerifyStudLog(EmailAdd, Password);
            if (selectedstudent != null && selectedstudent.IsSignedUp == true)
            {
                globalref.SelectedStudent = selectedstudent;
                return true;
                // Navigate in view
            }
            else return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            var change = PropertyChanged;
            if (change != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
