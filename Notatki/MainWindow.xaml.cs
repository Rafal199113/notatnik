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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notatki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XXXUrls xXX = new XXXUrls();
        code code = new code();
        public MainWindow()
        {
            InitializeComponent();
            user.Content ="Użytkownik: "+System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
           

          
           
         
            
        }
        public string getPassword()
        {
            string date = File.ReadAllText(@"g:\json.txt", Encoding.UTF8);
            dynamic cycki = (JsonConvert.DeserializeObject(date));
            string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
         
            return cycki.xyloh.ToString();


        }
        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Label)sender).Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));

        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Label)sender).Foreground = new SolidColorBrush(Color.FromRgb(211,211,211));
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (code.Enctype(pas.Password)==getPassword())
            {
               
                xXX.Show();
                this.Close();
                pas.Password = "";
            }else
            {
                error.Content = "Bad password";
                pas.Password = "";
                Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    Dispatcher.Invoke(new Action(() => { error.Content = ""; }));
                });
            }
          

        }

        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

            ChangePassword password = new ChangePassword();
            password.Show();

           
        }
       
    }
}
