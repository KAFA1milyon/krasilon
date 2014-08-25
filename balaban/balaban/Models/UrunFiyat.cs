using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace balaban.Models
{
    public class UrunFiyat : Status
    {
        public int ID { get; set; }
        public decimal Fiyat { get; set; }
        
        [ForeignKey("Urun")]
        public int UrunID { get; set; }
        public Urun Urun { get; set; }

        [ForeignKey("SatisKanal")]
        public int SatisKanalID { get; set; }
        public SatisKanali SatisKanal { get; set; }

        [ForeignKey("OdemeTip")]
        public int OdemeTipID { get; set; }
        public OdemeTip OdemeTip{ get; set; }





    }
}