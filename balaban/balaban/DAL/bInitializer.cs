using balaban.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace balaban.DAL
{
    public class bInitializer : DropCreateDatabaseIfModelChanges<bContext>
    {
        protected override void Seed(bContext context)
        {
            #region Ürünler
            var urun = new List<Urun>
            {
                new Urun{ UrunAdi="Fındık"},
                new Urun{ UrunAdi="Çam Fıstığı"},
                new Urun{ UrunAdi="Çekirdek"}
            };
            urun.ForEach(b => context.Urunler.Add(b));
            context.SaveChanges();
            #endregion
        }
    }
}