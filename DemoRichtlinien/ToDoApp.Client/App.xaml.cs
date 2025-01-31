using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ToDoApp.Business.Utility;

namespace ToDoApp.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Logging.WriteLog("ToDo-App gestartet...");
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Logging.WriteLog("ToDo-App beendet.");
            base.OnExit(e);
        }

    }
}
