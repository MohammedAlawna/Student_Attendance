using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace StudentAttendance.Model
{
    public class DatabaseAccess
    {
        public string CurrentState; // to hold the current db state
        static SQLiteConnection DatabaseConnection; // to hold and establish the connection
        public DatabaseAccess()
        {
            try
            {
                // Make the connection
                DatabaseConnection = new SQLiteConnection(DBConnection.DatabasePath, DBConnection.Flags);
                // Create a Table
                DatabaseConnection.CreateTable<Student>();
               
                DatabaseConnection.CreateTable<Module>();
                DatabaseConnection.CreateTable<Session>();
                DatabaseConnection.CreateTable<Tutor>();
               
                // set the status of the DB
                CurrentState = "Database and Table Created";
            }
            catch (SQLiteException excep)
            {
                CurrentState = excep.Message;
            }
        }

        // DB Utility Functions
        // Insert a new Person
        public int AddStudent(Student student)
        {
            // Insert into the table and return the status of the inset
            var insertstatus = DatabaseConnection.Insert(student);
            return insertstatus;
        }
        // Delete a person
        public int DeleteStudent(Student student)
        {
            // Query to return all persons in the DB
            var deletestatus = DatabaseConnection.Delete(student);
            return deletestatus;
        }
        // Update a person
        public int UpdateStudent(Student student)
        {
            // Query to return all persons in the DB
            var updatestatus = DatabaseConnection.Update(student);
            return updatestatus;
        }

        // Return ALL Students
        public ObservableCollection<Student> GetAllStudents()
        {
            ObservableCollection<Student> students;
            // Query to return all studets in the DB
            var allstudents = DatabaseConnection.Table<Student>();
            students = new ObservableCollection<Student>(allstudents.ToList());
            return students;
        }



        public ObservableCollection<Student> GetStudentByName(string searchTerm)
        {

            //Student students
            // Query to return all students in the DB
            var searchstudents = DatabaseConnection.Table<Student>()
                .Where(stud => stud.FirstName.ToLower().Contains(searchTerm.ToLower()) || 
                stud.LastName.ToLower().Contains(searchTerm.ToLower()));

            ObservableCollection<Student> liststudents = new ObservableCollection<Student>(searchstudents.ToList());
            return liststudents;
        }

        // Return a Student based on ID
        public Student GetStudentByID(int sid)
        {
            
            // Query to return a student by the unique ID
            var student = DatabaseConnection.Table<Student>()
            .Where(stud => stud.SID == sid)
            .FirstOrDefault();
            return student;
        }

        public bool FindDupMail(string email)
        {
            bool flag = false;
            var search = DatabaseConnection.Table<Student>()
                .Where(stud => stud.Email.ToLower() == email.ToLower())
                .FirstOrDefault();
            if (search != null) flag = true;
            return flag;
        }

        public Student VerifyStudReg(string emailAdd, string fname, string lname)
        {
            
            // Query to return student matching record in the DB
            var student = DatabaseConnection.Table<Student>()
            .Where(stud => stud.Email.ToLower() == emailAdd.ToLower() && 
            stud.FirstName.ToLower() == fname.ToLower() && 
            stud.LastName == lname.ToLower())
            .FirstOrDefault();
            return student;
        }

        public Student VerifyStudLog(string emailAdd, string password)
        {
            // Query to return student matching record in the DB
            var student = DatabaseConnection.Table<Student>()
            .Where(stud => stud.Email.ToLower() == emailAdd.ToLower() &&
            stud.Password == password && stud.IsSignedUp == true)
            .FirstOrDefault();
            return student;
        }

        public int AddTutor(Tutor tutor)
        {
            // Insert into the table and return the status of the insert
            var insertstatus = DatabaseConnection.Insert(tutor);
            return insertstatus;
        }
        public Tutor GetTutorByID(int tid)
        {

            // Query to return a tutor by the unique ID
            var tutor = DatabaseConnection.Table<Tutor>()
            .Where(tut => tut.TID == tid)
            .FirstOrDefault();
            return tutor;
        }

        public int AddModule(Module module)
        {
            // Insert into the table and return the status of the insert
            var insertstatus = DatabaseConnection.Insert(module);
            return insertstatus;
        }

        // Return ALL Modules
        public ObservableCollection<Module> GetAllModules()
        {
            ObservableCollection<Module> modules;
            // Query to return all studets in the DB
            var allmodules = DatabaseConnection.Table<Module>();
            modules = new ObservableCollection<Module>(allmodules.ToList());
            return modules;
        }
    }
}

