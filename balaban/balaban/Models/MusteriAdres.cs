using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace balaban.Models
{
    public class MusteriAdres : Status
    {
        public int ID { get; set; }
        public string Sehir{ get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public bool AdresOncelik { get; set; }

        [ForeignKey("Musteri")]
        public int MusteriID { get; set; }
        public Musteri Musteri { get; set; }

        [ForeignKey("AdresTip")]
        public int AdresTipID { get; set; }
        public AdresTip AdresTip{ get; set; }


    }
}