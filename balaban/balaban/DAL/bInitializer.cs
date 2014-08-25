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
                new Urun{ UrunAdi="Ay Çekirdek"},
                new Urun{ UrunAdi="Kan Üzümü"},
                new Urun{ UrunAdi="Siirt Fıstık"},
                new Urun{ UrunAdi="Pestil"},
                new Urun{ UrunAdi="Tuzlu Fıstık"},
                new Urun{ UrunAdi="Kabak Çekirdeği"},
                new Urun{ UrunAdi="Tuzsuz Kabak Çekirdeği"},
                new Urun{ UrunAdi="Badem"},
                new Urun{ UrunAdi="Kaju"},
                new Urun{ UrunAdi="Ceviz"},
                new Urun{ UrunAdi="Kabuklu Ceviz"},
                new Urun{ UrunAdi="Soslu Fıstık"},
                new Urun{ UrunAdi="Sarı Leblebi"},
                new Urun{ UrunAdi="Beyaz Leblebi"},
                new Urun{ UrunAdi="Çıtır Leblebi"},
                new Urun{ UrunAdi="Fındık"},
                new Urun{ UrunAdi="Çiğ Badem"},


            };
            urun.ForEach(b => context.Urunler.Add(b));
            context.SaveChanges();
            #endregion
        }
    }
}