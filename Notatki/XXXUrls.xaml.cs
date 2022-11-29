using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
    /// Logika interakcji dla klasy XXXUrls.xaml
    /// </summary>
    public partial class XXXUrls : Window
    {
        List<Url> products;
        public class Url
        {
            
            public String image;
            public String url;
         public  Url(String image,String url)
            {
                this.image = image;
                this.url = url;
            }
        }
        byte[] key = { 0x02, 0x03, 0x01, 0x03, 0x03, 0x07, 0x07, 0x08, 0x09, 0x09, 0x11, 0x11, 0x16, 0x17, 0x19, 0x16 };
        public XXXUrls()
        {
            InitializeComponent();

            List<Url> lista = new List<Url>();

          


            Image myImage;
            BitmapImage myBitmapImage;

            string date = File.ReadAllText(@"Urls.txt", Encoding.UTF8);
             products = JsonConvert.DeserializeObject<List<Url>>(date);
            foreach (Url url in products)
            {
                
                myImage = new Image();
                myImage.Margin = new Thickness(20);
                

               myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myImage.Width =300;
                if (url.image == "")
                {
                    myBitmapImage.UriSource = new Uri("https://w7.pngwing.com/pngs/564/9/png-transparent-codepen-logo-computer-icons-organization-f-18-text-trademark-logo-thumbnail.png");


                }
                else
                {
                    myBitmapImage.UriSource = new Uri(url.image);
                }
                
                myBitmapImage.EndInit();
                
                
                
                myImage.Source = myBitmapImage;
                myImage.MouseLeftButtonDown += new MouseButtonEventHandler((s, e) => TxblckLineNum_MouseDown( url.url, url.image));
                listBox.Children.Add(myImage);

            }
            
            saveUrl("https://thumb-v0.xhcdn.com/a/d7fCALXKyReRZlswoBHNQg/017/080/740/320x240.7.jpg", "https://pornkai.com/view?key=xhKSuev");
        }

        private void TxblckLineNum_MouseDown(string url, string image)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName =url,
                UseShellExecute = true
            });
        }

       

        public void saveUrl(string image, string url)
        {
                // encryption key for encryption/decryption 
                string data = @"  {'" +image+ "':'" + url + "'} ";

                File.WriteAllText(@"g:\cycki.txt", data);
            }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (url.Text != "" && pic.Text != "")
            {
                products.Add(new Url(pic.Text, url.Text));
                string json = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText(@"Urls.txt", json);
                MessageBox.Show("Pomyślnie dodano");
            }
        }
    }

    }


