using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServisTextIT.Models
{
    [Table(name: "Ocjena")]
    public class Ocjena
    {
        public int ocjenaID { get; set; }
        [DisplayName("Ocjena")]
        [Required(ErrorMessage = "Niste unijeli odjenu !")]
        public int ocjena { get; set; }

    }
}