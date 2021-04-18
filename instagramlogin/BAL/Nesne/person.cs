using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace instagramlogin.BAL.Nesne
{
   public class Person
    {
        //Create the variables with getters and setters so that the Objectlistview can access them
        

        
        public string KullaniciAdi { get; set; }
        public string Yorumu { get; set; }
        public string Yorumlinki { get; set; }

        public Person( string KullaniciAdi, string Yorumu, string Yorumlinki)
        {
           
            this.KullaniciAdi = KullaniciAdi;
            this.Yorumu = Yorumu;
            this.Yorumlinki = Yorumlinki;
        }
    }
}
