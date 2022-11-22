using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SQLite;
using StudentAttendance.Model;
using Xamarin.Essentials;

namespace StudentAttendance.ViewModel
{
    public class NewStudentVM : INotifyPropertyChanged
    {
        Model.DatabaseAccess DBInstance = new DatabaseAccess();
        // Create an instance of the DB Class
        public ObservableCollection<Model.Student> SearchStudents;
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
                OnPropertyChanged("FirstName");
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
              
                bool flag = DBInstance.FindDupMail(value);
                if (flag == false)
                {
                    emailAdd = value;
                }
               
            }
        }
        private DateTime dateofbirth;
        public DateTime DateofBirth
        {
            get
            {
                return dateofbirth;
            }
            set
            {
                dateofbirth = value;
                OnPropertyChanged("DateofBirth");
            }
        }

        public void SavePerson()
        {
            if(emailAdd == null)
            {
                return;
            }
            Model.Student newstudent = new Model.Student();
            newstudent.DateofBirth = DateofBirth;
            newstudent.FirstName = FirstName;
            newstudent.LastName = LastName;
            newstudent.Email = EmailAdd;
            DBInstance = new Model.DatabaseAccess();
            DBInstance.AddStudent(newstudent);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
