using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Notatki
{
    /// <summary>
    /// Logika interakcji dla klasy BackUp.xaml
    /// </summary>
    public partial class BackUp : Window
    {

        int i = DateTime.Now.Hour;
        int day ;
        int minuts = DateTime.Now.Minute;
        List<string> dni;
         settings settings;

        public BackUp(settings settings, List<string> dni)
        {

            InitializeComponent();
            godzina.Text = DateTime.Now.Hour.ToString();
            minuty.Text = DateTime.Now.Minute.ToString();
            this.settings = settings;
            this.dni = dni;

            getData();


        }

        

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (i >= 0 && i <= 24)
            {
                i++;
                godzina.Text = i.ToString();
                if (i == 24) { i = 0; godzina.Text = i.ToString(); }
                getData();
            }
        }
        private void Button_MouseLeftButtonDown2(object sender, MouseButtonEventArgs e)
        {
            if (i >= 0 && i <= 24)
            {
                i--;
                godzina.Text = i.ToString();



                if (i == -1) { i = 23; godzina.Text = i.ToString(); }


                getData();

            }
        }

        private void Image_MouseLeftButtonDown3(object sender, MouseButtonEventArgs e)
        {
            if (minuts >= 0 && minuts <= 60)
            {
                minuts++;
                minuty.Text = minuts.ToString();



                if (minuts == 60) { minuts = 0; minuty.Text = minuts.ToString(); }


                getData();

            }
        }

        private void Image_MouseLeftButtonDown4(object sender, MouseButtonEventArgs e)
        {
            if (minuts >= 0 && minuts <= 60)
            {
                minuts--;
                minuty.Text = minuts.ToString();



                if (minuts == -1) { minuts = 59; minuty.Text = minuts.ToString(); }



                getData();
            }
        }
        private void getData()
        {
            int x=0;
            if(day==0) { x = day; }
            if(day>0)x=day-1;
          
            select.Content = "BackUp zostanie wykonany o: " + godzina.Text + " : " + minuty.Text + " w każdą/y " + dni[x];
        }
        private void Btn1_Checked(object sender, RoutedEventArgs e)
        {
           
            switch ((string)((RadioButton)sender).Content)
            {
                case "Poniedziałek":
                    day = 1;
                    break;

                case "Wtorek":
                    day = 2;
                    break;

                case "Środa":
                    day =3;
                    break;

                case "Czwartek":
                    day = 4;
                    break;

                case "Piątek":
                    day = 5;
                    break;

                case "Sobota":
                    day = 6;
                    break;

                case "Niedziela":
                    day = 7;
                    break;



            }
            getData();
        }

        private void Label_MouseLeftButtonDownSave(object sender, MouseButtonEventArgs e)
        {
            DateTime date1 = new DateTime(2008, 8, 29, 21, 22, 15, 18);
            DateTime date2 = DateTime.Now;
            
            settings settings = new settings(date1, day);
            settings.saveSettings();
            this.settings.getSettings();
         
        }
        
    }
}