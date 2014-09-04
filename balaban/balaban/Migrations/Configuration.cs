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
            #region �r�nler
            context.Urunler.AddOrUpdate( p => new { p.UrunAdi },
            new Urun { UrunAdi = "F�nd�k" },
            new Urun { UrunAdi = "�am F�st���" },
            new Urun { UrunAdi = "Ay �ekirdek" },
            new Urun { UrunAdi = "Kan �z�m�" },
            new Urun { UrunAdi = "Siirt F�st�k" },
            new Urun { UrunAdi = "Pestil" },
            new Urun { UrunAdi = "Tuzlu F�st�k" },
            new Urun { UrunAdi = "Kabak �ekirde�i" },
            new Urun { UrunAdi = "Tuzsuz Kabak �ekirde�i" },
            new Urun { UrunAdi = "Badem" },
            new Urun { UrunAdi = "Kaju" },
            new Urun { UrunAdi = "Ceviz" },
            new Urun { UrunAdi = "Kabuklu Ceviz" },
            new Urun { UrunAdi = "Soslu F�st�k" },
            new Urun { UrunAdi = "Sar� Leblebi" },
            new Urun { UrunAdi = "Beyaz Leblebi" },
            new Urun { UrunAdi = "��t�r Leblebi" },
            new Urun { UrunAdi = "�i� Badem" }, 
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
                 new AdresTip { TipTanim = "�leti�im" },
                 new AdresTip { TipTanim = "Fatura" }
             );
            #endregion

            #region TelefonTip
            context.TelefonTipleri.AddOrUpdate(p => new { p.TipTanim },
                new TelefonTip { TipTanim = "��" },
                new TelefonTip { TipTanim = "Ev" },
                new TelefonTip { TipTanim = "GSM" }
            );

            #endregion

            #region OdemeTip
            context.OdemeTipleri.AddOrUpdate(p => new { p.OdemeTipAdi },
                new OdemeTip { OdemeTipAdi = "KK" },
                new OdemeTip { OdemeTipAdi = "Havale" },
                new OdemeTip { OdemeTipAdi = "Nakit" },
                new OdemeTip { OdemeTipAdi = "Kap�da �deme" }
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
