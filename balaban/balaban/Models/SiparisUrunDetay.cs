using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace balaban.Models
{
    public class SiparisUrunDetay : Status
    {
        public int ID { get; set; }
        public decimal Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        [ForeignKey("Urun")]
        public int UrunID { get; set; }
        public Urun Urun { get; set; }

        [ForeignKey("Siparis")]
        public int SiparisID { get; set; }
        public Siparis Siparis { get; set; }


    }
}