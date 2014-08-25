using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace balaban.Models
{
   public class AdresTip : Status
    {
        public int ID { get; set; }
       [Required]
        public string TipTanim { get; set; }
    }
}
