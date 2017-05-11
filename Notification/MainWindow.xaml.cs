using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Notification
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public EventHandler ExitAppClicked;

        DispatcherTimer timer;
        bool IsCheckDone = false;

        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += (object sender, EventArgs e) =>
              {
                  DateTime current = DateTime.Now;
                
                  timeTex.Text = current.ToString("t");

                  if (current.DayOfWeek != DayOfWeek.Sunday && current.DayOfWeek != DayOfWeek.Saturday)
                  {
                      if (current.Hour == Notification.Properties.Settings.Default.begin_hour
                            && current.Minute == Notification.Properties.Settings.Default.begin_min
                            || current.Hour == Notification.Properties.Settings.Default.end_hour
                            && current.Minute == Notification.Properties.Settings.Default.end_min)
                      {
                          if (IsCheckDone)
                              IsCheckDone = false;
                          else
                              this.Show();
                      }
                  }
              };
            timer.Start();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            System.Diagnostics.Process.Start(Notification.Properties.Settings.Default.OA_URL);
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            if (ExitAppClicked != null)
                ExitAppClicked(this, e);
        }

        private void check_click(object sender, RoutedEventArgs e)
        {
            IsCheckDone = true;
            System.Diagnostics.Process.Start(Notification.Properties.Settings.Default.OA_URL);
        }
    }
}
