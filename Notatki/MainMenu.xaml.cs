using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;

namespace Notatki
{
    /// <summary>
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
         settings settings = new settings();
        Boolean windowsVisible;
       List<string> dni = new List<string> { "Poniedziałek", "Wtorek", "Środa", "Czwartek","Piątek","Sobota","Niedziela" };
        RegistryKey key = Registry.Users;
       
        public MainMenu()
        {
            InitializeComponent();
            this.Hide();

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                System.Windows.MessageBox.Show(d.Name);
            }
           
         
           NotifyIcon icon = new NotifyIcon();
            icon.Icon = new System.Drawing.Icon("icon.ico");
           icon.Visible = true;
            icon.Click += Icon_Click;
            
            settings.getSettings();
            int n = (int)DateTime.Now.DayOfWeek;
           
            if ((int)DateTime.Now.DayOfWeek ==settings.Day)
            {

                System.Diagnostics.Process.Start("G:\\script.bat");
            }

        }
        private void Icon_Click(object? sender, EventArgs e)
        {
            if (windowsVisible)
            {
                this.Hide();
                windowsVisible = false;
            }
            else { this.Show(); windowsVisible = true; }


        }
        private void XXXUrls(object sender, MouseButtonEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            
        }
        private void BackUp(object sender, MouseButtonEventArgs e)
        {

            BackUp window = new BackUp(settings,dni);
            window.Show();
           

        }

        private void ToolTip(object sender, System.Windows.Input.MouseEventArgs e)
        {
       
            info.Content = "BackUp bedzie wykonywany w każdy/ą " + dni[settings.Day - 1];
            Task.Run(() =>
            {
                Thread.Sleep(2000);
                Dispatcher.Invoke(new Action(() => { info.Content = ""; }));
            });
        }
        private void ToolTip2(object sender, System.Windows.Input.MouseEventArgs e)
        {

            info.Content = "Baza danych Url z stron xxx";
            Task.Run(() =>
            {
                Thread.Sleep(2000);
                Dispatcher.Invoke(new Action(() => { info.Content = ""; }));
            });
        }

        private void minimalize(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.R)
            {
                System.Windows.MessageBox.Show("cipeczka");

            }
        }
    }
}
