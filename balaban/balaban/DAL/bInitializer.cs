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
            base.Seed(context);//krlsln
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
                new Urun{ UrunAdi="Renkli Leblebi"}


            };
            urun.ForEach(b => context.Urunler.Add(b));
            context.SaveChanges();
            #endregion

            #region MusteriTip
            var MusteriTipList = new List<MusteriTip>
            {
                new MusteriTip { TipTanim="Bireysel"},
                new MusteriTip { TipTanim="Kurumsal"},
            };

            MusteriTipList.ForEach(b => context.MusteriTipleri.Add(b));
            context.SaveChanges();
            #endregion

            #region AdresTip
            var AdresTipList = new List<AdresTip>
            {
                new AdresTip { TipTanim="İletişim"},
                new AdresTip { TipTanim="Fatura"},
            };

            AdresTipList.ForEach(b => context.AresTipleri.Add(b));
            context.SaveChanges();
            #endregion

            #region TelefonTip
            var telefonTiplist = new List<TelefonTip>
            {
                new TelefonTip { TipTanim="İş"},
                new TelefonTip { TipTanim="Ev"},
                new TelefonTip { TipTanim="GSM"},
            };

            telefonTiplist.ForEach(b => context.TelefonTipleri.Add(b));
            context.SaveChanges();
            #endregion

            #region OdemeTip
            var OdemeTiplist = new List<OdemeTip>
            {
                new OdemeTip { OdemeTipAdi ="KK"},
                new OdemeTip { OdemeTipAdi="Havale"},
                new OdemeTip { OdemeTipAdi="Nakit"},
                new OdemeTip { OdemeTipAdi="Kapıda Ödeme"},
            };

            OdemeTiplist.ForEach(b => context.OdemeTipleri.Add(b));
            context.SaveChanges();
            #endregion


            #region SatisTip
            var satisTipList = new List<SatisKanali>
            {
                new SatisKanali { KanalAdi="Web"},
                new SatisKanali { KanalAdi="Bayi"},
            };

            satisTipList.ForEach(b => context.SatisKanallari.Add(b));
            context.SaveChanges();
            #endregion


        }
    }
}