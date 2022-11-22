using StudentAttendance.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StudentAttendance.ViewModel
{
    public class SignUpVM : INotifyPropertyChanged
    {
        Model.DatabaseAccess DBInstance = new Model.DatabaseAccess();

        // Make reference to the global class
        App globalref = (App)Application.Current;

        
        private string firstname;
        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
               // OnPropertyChanged("FirstName");
            }
        }
        private string lastname;
        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
               OnPropertyChanged("LastName");
            }
        }
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
            var selectedstudent = DBInstance.VerifyStudReg(EmailAdd, FirstName, LastName);
            if(selectedstudent != null && selectedstudent.IsSignedUp==false)
            {
                selectedstudent.Password = Password;
                selectedstudent.IsSignedUp = true;
                return true;
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
