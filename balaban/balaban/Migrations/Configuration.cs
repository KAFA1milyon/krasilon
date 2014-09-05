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


            #region MusteriTip
            context.MusteriTipleri.AddOrUpdate(p => new { p.TipTanim },
               new MusteriTip { TipTanim = "Bireysel" },
               new MusteriTip { TipTanim = "Kurumsal" }
            );
            #endregion
            context.SaveChanges();

            #region AdresTip
            context.AdresTipleri.AddOrUpdate(p => new { p.TipTanim },
                 new AdresTip { TipTanim = "�leti�im" },
                 new AdresTip { TipTanim = "Fatura" }
             );
            #endregion
            context.SaveChanges();

            #region TelefonTip
            context.TelefonTipleri.AddOrUpdate(p => new { p.TipTanim },
                new TelefonTip { TipTanim = "��" },
                new TelefonTip { TipTanim = "Ev" },
                new TelefonTip { TipTanim = "GSM" }
            );
            #endregion
            context.SaveChanges();

            #region OdemeTip
            context.OdemeTipleri.AddOrUpdate(p => new { p.OdemeTipAdi },
                new OdemeTip { OdemeTipAdi = "KK" },
                new OdemeTip { OdemeTipAdi = "Havale" },
                new OdemeTip { OdemeTipAdi = "Nakit" },
                new OdemeTip { OdemeTipAdi = "Kap�da �deme" }
            );
            #endregion
            context.SaveChanges();


            #region SatisTip
            context.SatisKanallari.AddOrUpdate(p => new { p.KanalAdi },
                new SatisKanali { KanalAdi = "Web" },
                new SatisKanali { KanalAdi = "Bayi" }
            );
            #endregion
            context.SaveChanges();




            //OdemeTip ot = context.OdemeTipleri.FirstOrDefault(x => x.OdemeTipAdi == "Nakit");
            //SatisKanali sk = context.SatisKanallari.FirstOrDefault(x => x.KanalAdi == "Web");
            OdemeTip ot = context.OdemeTipleri.First();
            SatisKanali sk = context.SatisKanallari.First();
            //OdemeTip ot = null;
            //SatisKanali sk = null;

            context.SaveChanges();
            string UrunDetay = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec mattis. Nulla sagittis tincidunt nibh. ";
            //OdemeTip ot = new OdemeTip { OdemeTipAdi = "Test" };
            //context.OdemeTipleri.AddOrUpdate(ot);

            #region �r�nler
            context.Urunler.AddOrUpdate(p => new { p.UrunAdi },
            new Urun
            {
                UrunAdi = "F�nd�k",
                UrunDetay = new UrunDetay { DetayText = "F�nd�k " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 11, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "kavrulmus_findik.jpg" } }
            },
            new Urun
            {
                UrunAdi = "�am F�st���",
                UrunDetay = new UrunDetay { DetayText = "�am F�st��� " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 16, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "antep_fistigi.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Ay �ekirdek",
                UrunDetay = new UrunDetay { DetayText = "Ay �ekirdek " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 213, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "aycekirdek.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Kan �z�m�",
                UrunDetay = new UrunDetay { DetayText = "Kan �z�m� " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 35, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "kan_uzumu.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Siirt F�st�k",
                UrunDetay = new UrunDetay { DetayText = "Siirt F�st�k " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 235, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "siirt_fistik.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Pestil",
                UrunDetay = new UrunDetay { DetayText = "Pestil " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 105, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "pestil.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Tuzlu F�st�k",
                UrunDetay = new UrunDetay { DetayText = "Tuzlu F�st�k " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 85, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "tuzlu_fistik.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Kabak �ekirde�i",
                UrunDetay = new UrunDetay { DetayText = "Kabak �ekirde�i " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 58, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "kabak_cekirdegi.jpeg" } }
            },
            new Urun
            {
                UrunAdi = "Tuzsuz Kabak �ekirde�i",
                UrunDetay = new UrunDetay { DetayText = "Tuzsuz Kabak �ekirde�i " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 99, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "kabak_cekirdegi.jpeg" } }
            },
            new Urun
            {
                UrunAdi = "Badem",
                UrunDetay = new UrunDetay { DetayText = "Badem " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 43, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "badem_ici.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Kaju",
                UrunDetay = new UrunDetay { DetayText = "Kaju " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 35, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "kaju.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Ceviz",
                UrunDetay = new UrunDetay { DetayText = "Ceviz " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 67, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "ceviz_ici.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Kabuklu Ceviz",
                UrunDetay = new UrunDetay { DetayText = "Kabuklu Ceviz " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 40, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "ceviz_ici.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Soslu F�st�k",
                UrunDetay = new UrunDetay { DetayText = "Soslu F�st�k " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 77, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "soslu_fistik.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Sar� Leblebi",
                UrunDetay = new UrunDetay { DetayText = "Sar� Leblebi " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 24, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "sar�_leblebi.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Beyaz Leblebi",
                UrunDetay = new UrunDetay { DetayText = "Beyaz Leblebi " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 34, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "beyaz leblebi.jpg" } }
            },
            new Urun
            {
                UrunAdi = "��t�r Leblebi",
                UrunDetay = new UrunDetay { DetayText = "��t�r Leblebi " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 39, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "citir_leblebi.jpg" } }
            },
            new Urun
            {
                UrunAdi = "�i� Badem",
                UrunDetay = new UrunDetay { DetayText = "�i� Badem " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 447, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "cig_badem.jpg" } }
            },
            new Urun
            {
                UrunAdi = "Renkli Leblebi",
                UrunDetay = new UrunDetay { DetayText = "Renkli Leblebi " + UrunDetay },
                UrunFiyatDetaylar = null,
                UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 76, OdemeTip = ot, SatisKanal = sk } },
                UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "renkli_leblebi.jpg" } }
            }
            );
            #endregion
            //context.SaveChanges();

            //new Urun { UrunAdi = "test", UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "test1.jpg" } } },

            //context.Urunler.AddOrUpdate(p => new { p.UrunAdi },
            //    new Urun
            //    {
            //        UrunAdi = "Rsdsenkli",
            //        UrunDetay = new UrunDetay { DetayText = "Rssdenkli " + UrunDetay },
            //        UrunFiyatDetaylar = null,
            //        UrunFiyatlar = new List<UrunFiyat> { new UrunFiyat { Fiyat = 76, OdemeTip = ot, SatisKanal = sk } },
            //        UrunResimler = new List<UrunResim> { new UrunResim { AnaResim = true, ResimYol = "renkli_leblebi.jpg" } }
            //    } 

            //    );

            //context.UrunResimleri.AddOrUpdate(new UrunResim()
            //{
            //    Urun = context.Urunler.Find("F�nd�k"),
            //    ResimYol="test1.jpg" 
            //});

            //context.Urunler.AddOrUpdate(p => p.UrunAdi, urun.ToArray());




            context.SaveChanges();
        }
    }
}
