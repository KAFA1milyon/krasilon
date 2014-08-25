using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace balaban.Models
{
    public class Siparis : Status
    {
        public int ID { get; set; }
        public DateTime SiparisTarihi { get; set; }

        [ForeignKey("Musteri")]
        public int MusteriID { get; set; }
        public Musteri Musteri { get; set; }


    }
}