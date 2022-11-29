using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace Notatki
{
   public  class settings
    {
        DateTime godzina;
     
        int day;

        public settings(DateTime godzina, int day)
        {
            this.godzina = godzina;
            this.day = day;
        }

        public settings()
        {
        }

        public DateTime Godzina { get => godzina; set => godzina = value; }
        public int Day { get => day; set => day = value; }

        public void saveSettings()
        {
         
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
           

            File.WriteAllText(@"settings.txt", json);
           
           
        }
        public void getSettings()
        {
            string date = File.ReadAllText(@"settings.txt", Encoding.UTF8);
            settings cycki = JsonConvert.DeserializeObject<settings>(date);
            this.godzina = cycki.godzina;
            this.day = cycki.day;
        }
     
    }

}
