using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace balaban.Models
{
    public class Urun : Status
    {
        public int ID { get; set; }

        [Required]
        public string UrunAdi { get; set; }
        public bool Kampanya { get; set; }

        [ForeignKey("UrunDetay")]
        public int UrunDetayID { get; set; }
        public UrunDetay UrunDetay { get; set; }

        public virtual ICollection<UrunFiyat> UrunFiyatlar { get; set; }
        public virtual ICollection<UrunFiyatDetay> UrunFiyatDetaylar { get; set; }
        public virtual ICollection<UrunResim> UrunResimler { get; set; }
    }
}