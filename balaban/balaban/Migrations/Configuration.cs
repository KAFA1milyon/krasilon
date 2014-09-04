namespace balaban.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using balaban.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<balaban.DAL.bContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(balaban.DAL.bContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            #region Ürünler
            context.Urunler.AddOrUpdate( p => new { p.UrunAdi },
            new Urun { UrunAdi = "Fýndýk" },
            new Urun { UrunAdi = "Çam Fýstýðý" },
            new Urun { UrunAdi = "Ay Çekirdek" },
            new Urun { UrunAdi = "Kan Üzümü" },
            new Urun { UrunAdi = "Siirt Fýstýk" },
            new Urun { UrunAdi = "Pestil" },
            new Urun { UrunAdi = "Tuzlu Fýstýk" },
            new Urun { UrunAdi = "Kabak Çekirdeði" },
            new Urun { UrunAdi = "Tuzsuz Kabak Çekirdeði" },
            new Urun { UrunAdi = "Badem" },
            new Urun { UrunAdi = "Kaju" },
            new Urun { UrunAdi = "Ceviz" },
            new Urun { UrunAdi = "Kabuklu Ceviz" },
            new Urun { UrunAdi = "Soslu Fýstýk" },
            new Urun { UrunAdi = "Sarý Leblebi" },
            new Urun { UrunAdi = "Beyaz Leblebi" },
            new Urun { UrunAdi = "Çýtýr Leblebi" },
            new Urun { UrunAdi = "Çið Badem" }, 
            new Urun { UrunAdi = "Renkli Leblebi" }
            );
            #endregion

            //context.Urunler.AddOrUpdate(p => p.UrunAdi, urun.ToArray());
            #region MusteriTip
            context.MusteriTipleri.AddOrUpdate( p => new { p.TipTanim },
               new MusteriTip { TipTanim = "Bireysel" },
               new MusteriTip { TipTanim = "Kurumsal" }
            );

            #endregion

            #region AdresTip
            context.AdresTipleri.AddOrUpdate(p => new { p.TipTanim },
                 new AdresTip { TipTanim = "Ýletiþim" },
                 new AdresTip { TipTanim = "Fatura" }
             );
            #endregion

            #region TelefonTip
            context.TelefonTipleri.AddOrUpdate(p => new { p.TipTanim },
                new TelefonTip { TipTanim = "Ýþ" },
                new TelefonTip { TipTanim = "Ev" },
                new TelefonTip { TipTanim = "GSM" }
            );

            #endregion

            #region OdemeTip
            context.OdemeTipleri.AddOrUpdate(p => new { p.OdemeTipAdi },
                new OdemeTip { OdemeTipAdi = "KK" },
                new OdemeTip { OdemeTipAdi = "Havale" },
                new OdemeTip { OdemeTipAdi = "Nakit" },
                new OdemeTip { OdemeTipAdi = "Kapýda Ödeme" }
            );
            #endregion


            #region SatisTip
            context.SatisKanallari.AddOrUpdate(p => new { p.KanalAdi },
                new SatisKanali { KanalAdi = "Web" },
                new SatisKanali { KanalAdi = "Bayi" }
            );

            #endregion

        }


    }
}
