using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using SQLite;
using StudentAttendance.View;

namespace StudentAttendance.ViewModel
{
    public class StudentDetailsVM : INotifyPropertyChanged
    {
        Model.DatabaseAccess DBInstance = new Model.DatabaseAccess();

        // Make reference to the global class
        App globalref= (App)Application.Current;

        public StudentDetailsVM()
        {
            LoadPerson();
        }

        private int studentid { get; set; }
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

        public void LoadPerson()
        {
            var sid = globalref.SelectedStudent.SID;

            //locating the student in our database
            var selectedstudent = DBInstance.GetStudentByID(sid); 

            // setting the properties of detailspage variable from selected student
            studentid = selectedstudent.SID;
            firstname = selectedstudent.FirstName;
            lastname = selectedstudent.LastName;
            dateofbirth=selectedstudent.DateofBirth;
            emailAdd = selectedstudent.Email;
            
        }
        public void UpdateStudent()
        {
            Model.Student newstudent = new Model.Student();
            newstudent.SID = studentid;
            newstudent.DateofBirth = DateofBirth;
            newstudent.FirstName = FirstName;
            newstudent.LastName = LastName;
            newstudent.Email = EmailAdd;

           
            DBInstance.UpdateStudent(newstudent);
        }

        public void DeleteStudent()
        {
            var sid = globalref.SelectedStudent.SID;

            //locating the student in our database
            var selectedstudent = DBInstance.GetStudentByID(sid);

            DBInstance.DeleteStudent(selectedstudent);
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
