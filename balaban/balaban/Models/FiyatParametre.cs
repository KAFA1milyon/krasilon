using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace balaban.Models
{
    public class FiyatParametre : Status
    {
        public int ID { get; set; }
        
        [Required]
        public int ParametreBaslangic { get; set; }
        
        public int ParametreBitis { get; set; }

    }
}