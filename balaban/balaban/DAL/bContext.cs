using balaban.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace balaban.DAL
{
    public class bContext : DbContext
    {
        public DbSet<AdresTip> AresTipleri { get; set; }
        public DbSet<FiyatParametre> FiyatParametreleri { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<MusteriAdres> MusteriAdresleri { get; set; }
        public DbSet<MusteriTelefon> MusteriTelefonlari { get; set; }
        public DbSet<MusteriTip> MusteriTipleri { get; set; }
        public DbSet<OdemeTip> OdemeTipleri { get; set; }
        public DbSet<SatisKanali> SatisKanallari { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisOdemeDetay> SiparisOdemeDetaylari { get; set; }
        public DbSet<SiprasiUrunDetay> SiprasiUrunDetaylari { get; set; }
        public DbSet<TelefonTip> TelefonTipleri { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunDetay> UrunDetaylari { get; set; }
        public DbSet<UrunFiyat> UrunFiyatlari { get; set; }
        public DbSet<UrunFiyatDetay> UrunFiyatDetaylari { get; set; }
        public DbSet<UrunResim> UrunResimleri { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}