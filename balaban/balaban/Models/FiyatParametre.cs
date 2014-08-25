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
        public string ParametreBaslangic { get; set; }
        [Required]
        public string ParametreBitis { get; set; }

    }
}