using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServisTextIT.Models;
 
namespace TextITMVC
{
    public class LaraKlasa
    {
        Korisnik korisnik;
        int brojKom;
 
        public LaraKlasa()
        {
            BrojKom = 0;
        }
        public LaraKlasa(Korisnik k, int b)
        {
            Korisnik = k;
            BrojKom = b;
        }
 
        public int BrojKom
        {
            get { return brojKom; }
            set { brojKom = value; }
        }
 
        public Korisnik Korisnik
        {
            get { return korisnik; }
            set { korisnik = value; }
        }
    }
}


