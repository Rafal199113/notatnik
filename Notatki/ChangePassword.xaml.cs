using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notatki
{
    /// <summary>
    /// Logika interakcji dla klasy ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        code code = new code();
        private const string HelloMessage = "Hello World";
        public string Hello { get { return HelloMessage; } }
        public ChangePassword()
        {
            InitializeComponent();

        }
        public string getPassword()
        {
            string date = File.ReadAllText(@"g:\json.txt", Encoding.UTF8);
            dynamic cycki = (JsonConvert.DeserializeObject(date));
            string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];

            return cycki.xyloh.ToString();


        }
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          
            if (getPassword() ==code.Enctype(oldPas.Password)) {
                code.savePassword(code.Enctype(newPas.Password));
                result("Hasło zmienone", Color.FromRgb(50, 205, 50),"/done.png");
            }
            else { MessageBox.Show("Stare hasło jest błędne");

                result("Stare hasło jest błędne", Color.FromRgb(255, 0, 0), "/incorrect.png");
            }

         
        }
        public void result(String result, Color color, String path)
        {
            Result.Content = result;
            Result.Foreground = new SolidColorBrush(color);
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(path, UriKind.Relative);
            logo.EndInit();

            icon.Source = logo;
            Task.Run(() =>
            {
                Thread.Sleep(2000);
                Dispatcher.Invoke(new Action(() => { icon.Source = null; Result.Content = ""; }));
            });
        }

        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
