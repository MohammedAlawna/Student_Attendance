using StudentAttendance.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StudentAttendance.ViewModel
{
    public class ModulesPageVM
    {
        Model.DatabaseAccess newDBInstance;
        public ModulesPageVM()
        {
            newDBInstance = new Model.DatabaseAccess();
            LoadModules();
        }

        public ObservableCollection<Module> AllModules = new ObservableCollection<Module>();
        private void LoadModules()
        {
           AllModules = newDBInstance.GetAllModules();
        }
    }
}
