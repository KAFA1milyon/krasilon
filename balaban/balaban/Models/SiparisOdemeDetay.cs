using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace balaban.Models
{
    public class SiparisOdemeDetay : Status
    {
        public int ID { get; set; }
        public decimal OdemeTutari { get; set; }
        
        [ForeignKey("OdemeTip")]
        public int OdemeTipID { get; set; }
        public OdemeTip OdemeTip { get; set; }

        [ForeignKey("SatisKanali")]
        public int SatisKanalID { get; set; }
        public SatisKanali SatisKanali{ get; set; }






    }
}