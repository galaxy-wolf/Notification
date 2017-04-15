using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;

namespace Notification
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow window;

        public App()
        {
            window = new Notification.MainWindow();
            window.ExitAppClicked += (sender, e) => { this.Shutdown(); };

            SetStartupWithSystem();
        }


        private void SetStartupWithSystem()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
        ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (Notification.Properties.Settings.Default.StartWithSystem == true)
            {
                registryKey.SetValue("Notification", System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                registryKey.DeleteValue("Notification", false);
            }
        }
    }
}
