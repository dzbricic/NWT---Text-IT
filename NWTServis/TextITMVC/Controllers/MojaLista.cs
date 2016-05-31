using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServisTextIT.Models;

namespace TextITMVC
{
    public class MojaLista
    {
        Korisnik k;
        int brojac;

        public MojaLista()
        {
            brojac = 0;
        }

        public MojaLista(Korisnik k, int br)
        {
            K = k;
            Brojac = br;
        }

        public int Brojac
        {
            get { return brojac; }
            set { brojac = value; }
        }

        public Korisnik K
        {
            get { return k; }
            set { k = value; }
        }

    }
}