using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextIT.Models
{
    
    public class HashTag
    {
        public int hashTagID { get; set; }
        List<Tekst> tekstovi { get; set; }
    }
}