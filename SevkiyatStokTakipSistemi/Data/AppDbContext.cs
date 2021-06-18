using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SevkiyatStokTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Stok> Stoklar { get; set; }
        public DbSet<Sevkiyat> Sevkiyatlar { get; set; }
        public DbSet<AracBilgisi> AracBilgileri { get; set; }
        public DbSet<Surucu> Suruculer { get; set; }
        public DbSet<SipFirma> FirmaSiparisleri { get; set; }
        public DbSet<SipUrun> UrunSiparisler { get; set; }







        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<AppUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });


            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UsersClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

           
            builder.Entity<SipFirma>().HasKey(c => new
            {
                c.FirmaId,
                c.SiparisId,
            });
            builder.Entity<SipFirma>()
               .HasOne(c => c.Siparis)
               .WithMany(c => c.FirmaSiparisleri)
               .HasForeignKey(c => c.SiparisId);
            builder.Entity<SipFirma>()
                .HasOne(c => c.Firma)
                .WithMany(c => c.FirmaSiparisleri)
                .HasForeignKey(c => c.FirmaId);

            builder.Entity<SipUrun>().HasKey(c => new
            {
                c.UrunId,
                c.SiparisId,
            });
            builder.Entity<SipUrun>()
                .HasOne(c => c.Siparis)
                .WithMany(c => c.UrunSiparisleri)
                .HasForeignKey(c => c.SiparisId);

            builder.Entity<SipUrun>()
                .HasOne(c => c.Urun)
                .WithMany(c => c.UrunSiparisleri)
                .HasForeignKey(c => c.UrunId);
                
 
            builder.Entity<SevkiyatAraci>().HasKey(c => new
            {
                c.SevkiyatId,
                c.AracBilgisiId,
            });
            builder.Entity<SipSevkiyat>().HasKey(c => new
            {
                c.SevkiyatId,
                c.SiparisId,
            });
           
            builder.Entity<AracSurucusu>().HasKey(c => new
            {
                c.SurucuId,
                c.AracBilgisiId,
            });

            builder.Entity<Urun>()
                  .HasOne(x => x.Stok)
                  .WithOne(i => i.Urunler)
                  .HasForeignKey<Stok>(x => x.UrunForeingKey);

            builder.Entity<Firma>().ToTable("Firma");
            builder.Entity<Urun>().ToTable("Urun");












        }

    }
    
    
    
}
