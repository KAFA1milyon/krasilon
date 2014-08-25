using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace balaban.Models
{
    public class UrunFiyatDetay : Status
    {
        public int ID { get; set; }
        public decimal Fiyat { get; set; }

        [ForeignKey("Urun")]
        public int UrunID { get; set; }
        public Urun Urun { get; set; }

        [ForeignKey("Musteri")]
        public int MusteriID { get; set; }
        public Musteri Musteri { get; set; }

        [ForeignKey("FiyatParametre")]
        public int FiyatParametreID { get; set; }
        public FiyatParametre FiyatParametre { get; set; }


    }
}