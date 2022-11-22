using StudentAttendance.Model;
using StudentAttendance.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentAttendance
{
    public partial class App : Application
    {
        public Student SelectedStudent;
        public Module SelectedModule { get; set; }
        Model.DatabaseAccess newDBInstance;
        public App()
        {
            InitializeComponent();

            // Create an instance of the DB Class
            newDBInstance = new Model.DatabaseAccess();

            foreach (var tut in ModuleLeaders.TutorList)
            {               
                newDBInstance.AddTutor(tut);
            }

            foreach (var modl in ModulesTaught.ModuleList)
            {
                newDBInstance.AddModule(modl);
            }
            MainPage = new NavigationPage(new LogInPage());

        }

        public Tutors ModuleLeaders = GenerateTutors();
        // Create and add sample data
        public static Tutors GenerateTutors()
        {
            Tutors tutors = new Tutors();
            tutors.TutorList.Add(new Tutor
            {
                FirstName = "James",
                LastName = "Ward",
                Email = "jamesward@email.com",
                Password = "james"
            });

            tutors.TutorList.Add(new Tutor
            {
                FirstName = "Henry",
                LastName = "Ford",
                Email = "henryford@email.com",
                Password = "henry"
            });

            tutors.TutorList.Add(new Tutor
            {
                FirstName = "Elton",
                LastName = "John",
                Email = "eltonjohn@email.com",
                Password = "elton"
            });

            return tutors;          
        }

        public Modules ModulesTaught = GenerateModules();

      
        // Create and add sample data
        public static Modules GenerateModules()
        {
            Modules modules = new Modules();
            modules.ModuleList.Add(new Module
            {
                Title = "History",
                MCode = "HST101",
                CreditUnits = 30,
                TutorID = 1 
            });
            modules.ModuleList.Add(new Module
            {
                Title = "Science",
                MCode = "SCI211",
                CreditUnits = 45,
                TutorID = 2
            });

            modules.ModuleList.Add(new Module
            {
                Title = "Management",
                MCode = "MGT203",
                CreditUnits = 40,
                TutorID = 3
            });

            return modules;
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }

    public class Tutors
    {
        public ObservableCollection<Tutor> TutorList;

        public Tutors()
        {
            TutorList = new ObservableCollection<Tutor>();
        }
    }

    public class Modules
    {
        public ObservableCollection<Module> ModuleList;

        public Modules()
        {
            ModuleList = new ObservableCollection<Module>();
        }
    }
}
