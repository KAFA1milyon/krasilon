using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace balaban.Models
{
    public class MusteriTelefon : Status
    {
        public int ID { get; set; }
        public string TelNo { get; set; }
        public bool? TelOncelik { get; set; }

        [ForeignKey("Musteri")]
        public int MusteriID { get; set; }
        public Musteri Musteri { get; set; }
        
        [ForeignKey("TelefonTip")]
        public int TelefonTipID { get; set; }
        public TelefonTip TelefonTip{ get; set; }

    }
}