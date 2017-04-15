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

        DispatcherTimer timer;


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
                      if (current.Hour == 9 && current.Minute == 55
                            || current.Hour == 19 && current.Minute == 0)
                      {
                          this.Show();
                      }
                  }
              };
            timer.Start();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            System.Diagnostics.Process.Start("http://www.baidu.com");
        }
    }
}
