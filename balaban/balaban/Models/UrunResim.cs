using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace balaban.Models
{
    public class UrunResim : Status
    {
        public int ID { get; set; }
        public string ResimYol { get; set; }
        public bool AnaResim { get; set; }

        [ForeignKey("Urun")]
        public int UrunID { get; set; }
        public Urun Urun { get; set; }


    }
}