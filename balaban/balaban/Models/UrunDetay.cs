using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace balaban.Models
{
    public class UrunDetay : Status
    {
        public int ID { get; set; }
        public string DetayText { get; set; }

        [ForeignKey("Urun")]
        public int UrunID{ get; set; }
        public Urun Urun { get; set; }
    }
}