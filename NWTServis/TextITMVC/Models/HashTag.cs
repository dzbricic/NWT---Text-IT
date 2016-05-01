using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TextITMVC.Models
{
    public class HashTag
    {
        public int hashTagID { get; set; }
        [DisplayName("HashTag#:")]
        [Required(ErrorMessage = "Niste unijeli unijeti HashTag !")]
        public string naziv { get; set; }

    }
    
}