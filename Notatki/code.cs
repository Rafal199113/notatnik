using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notatki
{
    internal class code
    {
        private int key=3;
        private string toEncrypt;
        public string toDecrypt;
       

        char[] alfabet = { 'a', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't','u','w', 'y', 'z', 'ź', 'ż' };
        public void savePassword(string password)
        {
            string data = @"  {'" + System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1] + "':'" + password + "'} ";
           
            File.WriteAllText(@"g:\json.txt", data);
        

        }
        public string Enctype(string text)
        {
            
           string napis="";
            for(int i=0; i<text.Length; i++)
            {

                for(int x=0; x<alfabet.Length; x++)
                {
                    if (alfabet[x] == text[i]) {

                        try
                        {
                            napis = napis + alfabet[x + key];

                        }catch(IndexOutOfRangeException e)
                        {

                            napis = napis + alfabet[x-(alfabet.Length-key)];
                        }
                    }

                }
             

            }
         
            this.toEncrypt = napis;
            return napis;
        }
        public string NoEnctype()
        {
            string napis = "";
            for (int i = 0; i < toEncrypt.Length; i++)
            {
                for (int x = 0; x < alfabet.Length; x++)
                {
                    if (alfabet[x] == toEncrypt[i])
                    {

                        try
                        {
                            napis = napis + alfabet[x - key];

                        }
                        catch (IndexOutOfRangeException e)
                        {

                            napis = napis + alfabet[x + (alfabet.Length - key)];
                        }
                    }

                }

            }


            return napis;
        }

    } 
}