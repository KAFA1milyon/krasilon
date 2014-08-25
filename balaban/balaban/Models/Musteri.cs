using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace balaban.Models
{
    public class Musteri : Status
    {
        public int ID { get; set; }
        public string MusteriKod { get; set; }

        [ForeignKey("MusteriTip")]
        public int MusteriTipID { get; set; }
        public MusteriTip MusteriTip{ get; set; }


        public Musteri AnaMusteri { get; set; }

        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string VergiNo { get; set; }

        [StringLength(11,MinimumLength=0)]
        public string TCKimlikNo { get; set; }

        public string VergiDairesi { get; set; }        
        public string IrtibatIsim { get; set; }
        public string IrtibatNo { get; set; }

        public virtual ICollection<MusteriAdres> MusteriAdresleri { get; set; }
        public virtual ICollection<MusteriTelefon> MusteriTelefonlari { get; set; }





    }
}