using System;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class GarageContext : DbContext
    {
        public DbSet<Partner> Partner { get; set; }
        public DbSet<GatekeeperLog> GatekeeperLogs { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=Garage;Integrated Security=True");
            }
        }

        public GarageContext() {}

        public GarageContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(vehicle =>
            {
                vehicle.Property(e => e.LicensePlate)
                    .HasMaxLength(12)
                    .IsRequired();

                vehicle
                    .HasIndex(i => i.LicensePlate)
                    .IsUnique();
            });

            modelBuilder.Entity<GatekeeperLog>(gatekeeperLog =>
            {
                gatekeeperLog.Property(e => e.LicensePlate)
                    .HasMaxLength(12)
                    .IsRequired();

                gatekeeperLog.Property(e => e.VehicleColor)
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<Partner>(partner =>
            {
                partner.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                partner.Property(e => e.Discount)
                    .HasColumnType("decimal(5,2)")
                    .IsRequired()
                    .HasDefaultValue(0.0m);

                partner.Property(e => e.PaymentPeriod)
                    .IsRequired()
                    .HasDefaultValue(PaymentPeriod.Daily);
            });

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Partner>().HasData(
                new Partner { Id = 1, Name = "Partner1", Discount = 0.1m, PaymentPeriod = PaymentPeriod.Daily },
                new Partner { Id = 2, Name = "Partner2", Discount = 0.0m, PaymentPeriod = PaymentPeriod.Weekly },
                new Partner { Id = 3, Name = "Partner3", Discount = 0.15m, PaymentPeriod = PaymentPeriod.Monthly },
                new Partner { Id = 4, Name = "Partner4", Discount = 0.3m, PaymentPeriod = PaymentPeriod.Monthly, CardId = 11111 },
                new Partner { Id = 5, Name = "Partner5", Discount = 0.3m, PaymentPeriod = PaymentPeriod.Monthly, CardId = 22222 }
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, LicensePlate = "ABC123", PartnerId = 1},
                new Vehicle { Id = 2, LicensePlate = "ABC124", PartnerId = 2},
                new Vehicle { Id = 3, LicensePlate = "ABC125", PartnerId = 3},
                new Vehicle { Id = 4, LicensePlate = "ABC126", PartnerId = 4},
                new Vehicle { Id = 5, LicensePlate = "ABC127", PartnerId = 4},
                new Vehicle { Id = 6, LicensePlate = "ABC128", PartnerId = 5},
                new Vehicle { Id = 7, LicensePlate = "ABC129", PartnerId = 5}
            );

            modelBuilder.Entity<GatekeeperLog>().HasData(
                new GatekeeperLog { Id = 01, PassOver = DateTime.Today.AddDays(-9).AddHours(10).AddMinutes(10), Direction = PassOverDirection.In,  LicensePlate = "ABC123", VehicleColor = "Yellow"},
                new GatekeeperLog { Id = 02, PassOver = DateTime.Today.AddDays(-9).AddHours(10).AddMinutes(15), Direction = PassOverDirection.In,  LicensePlate = "ABC124", VehicleColor = "Red"},
                new GatekeeperLog { Id = 03, PassOver = DateTime.Today.AddDays(-9).AddHours(10).AddMinutes(30), Direction = PassOverDirection.In,  LicensePlate = "ABC125", VehicleColor = "Blue" },
                new GatekeeperLog { Id = 04, PassOver = DateTime.Today.AddDays(-9).AddHours(10).AddMinutes(35), Direction = PassOverDirection.In,  LicensePlate = "ABC126", VehicleColor = "Purple" },
                new GatekeeperLog { Id = 05, PassOver = DateTime.Today.AddDays(-9).AddHours(10).AddMinutes(55), Direction = PassOverDirection.In,  LicensePlate = "ABC127", VehicleColor = "Black" },
                new GatekeeperLog { Id = 06, PassOver = DateTime.Today.AddDays(-9).AddHours(11).AddMinutes(15), Direction = PassOverDirection.In,  LicensePlate = "ABC128", VehicleColor = "White" },
                new GatekeeperLog { Id = 07, PassOver = DateTime.Today.AddDays(-9).AddHours(11).AddMinutes(25), Direction = PassOverDirection.Out, LicensePlate = "ABC123", VehicleColor = "Orange" },
                new GatekeeperLog { Id = 08, PassOver = DateTime.Today.AddDays(-9).AddHours(11).AddMinutes(45), Direction = PassOverDirection.In,  LicensePlate = "ABC129", VehicleColor = "Green" },
                new GatekeeperLog { Id = 09, PassOver = DateTime.Today.AddDays(-9).AddHours(12).AddMinutes(10), Direction = PassOverDirection.Out, LicensePlate = "ABC124", VehicleColor = "Red" },
                new GatekeeperLog { Id = 10, PassOver = DateTime.Today.AddDays(-9).AddHours(13).AddMinutes(20), Direction = PassOverDirection.Out, LicensePlate = "ABC125", VehicleColor = "Blue" },
                new GatekeeperLog { Id = 11, PassOver = DateTime.Today.AddDays(-9).AddHours(14).AddMinutes(30), Direction = PassOverDirection.Out, LicensePlate = "ABC126", VehicleColor = "Purple" },
                new GatekeeperLog { Id = 12, PassOver = DateTime.Today.AddDays(-9).AddHours(15).AddMinutes(45), Direction = PassOverDirection.Out, LicensePlate = "ABC127", VehicleColor = "Black" },
                new GatekeeperLog { Id = 13, PassOver = DateTime.Today.AddDays(-9).AddHours(16).AddMinutes(50), Direction = PassOverDirection.Out, LicensePlate = "ABC128", VehicleColor = "White" },
                new GatekeeperLog { Id = 14, PassOver = DateTime.Today.AddDays(-9).AddHours(17).AddMinutes(55), Direction = PassOverDirection.Out, LicensePlate = "ABC129", VehicleColor = "Green" },
                // --
                new GatekeeperLog { Id = 25, PassOver = DateTime.Today.AddDays(-8).AddHours(07).AddMinutes(40), Direction = PassOverDirection.In,  LicensePlate = "ABC123" },
                new GatekeeperLog { Id = 26, PassOver = DateTime.Today.AddDays(-8).AddHours(08).AddMinutes(10), Direction = PassOverDirection.In,  LicensePlate = "ABC124" },
                new GatekeeperLog { Id = 27, PassOver = DateTime.Today.AddDays(-8).AddHours(08).AddMinutes(30), Direction = PassOverDirection.In,  LicensePlate = "ABC125" },
                new GatekeeperLog { Id = 28, PassOver = DateTime.Today.AddDays(-8).AddHours(08).AddMinutes(35), Direction = PassOverDirection.In,  LicensePlate = "ABC126" },
                new GatekeeperLog { Id = 29, PassOver = DateTime.Today.AddDays(-8).AddHours(08).AddMinutes(40), Direction = PassOverDirection.In,  LicensePlate = "ABC127" },
                new GatekeeperLog { Id = 30, PassOver = DateTime.Today.AddDays(-8).AddHours(09).AddMinutes(15), Direction = PassOverDirection.In,  LicensePlate = "ABC128" },
                new GatekeeperLog { Id = 31, PassOver = DateTime.Today.AddDays(-8).AddHours(09).AddMinutes(55), Direction = PassOverDirection.In,  LicensePlate = "ABC129" },
                new GatekeeperLog { Id = 32, PassOver = DateTime.Today.AddDays(-8).AddHours(16).AddMinutes(30), Direction = PassOverDirection.Out, LicensePlate = "ABC123" },
                new GatekeeperLog { Id = 33, PassOver = DateTime.Today.AddDays(-8).AddHours(17).AddMinutes(10), Direction = PassOverDirection.Out, LicensePlate = "ABC124" },
                new GatekeeperLog { Id = 34, PassOver = DateTime.Today.AddDays(-8).AddHours(17).AddMinutes(15), Direction = PassOverDirection.Out, LicensePlate = "ABC125" },
                new GatekeeperLog { Id = 35, PassOver = DateTime.Today.AddDays(-8).AddHours(17).AddMinutes(20), Direction = PassOverDirection.Out, LicensePlate = "ABC126" },
                new GatekeeperLog { Id = 36, PassOver = DateTime.Today.AddDays(-8).AddHours(18).AddMinutes(10), Direction = PassOverDirection.Out, LicensePlate = "ABC127" },
                new GatekeeperLog { Id = 37, PassOver = DateTime.Today.AddDays(-8).AddHours(18).AddMinutes(50), Direction = PassOverDirection.Out, LicensePlate = "ABC128" },
                new GatekeeperLog { Id = 38, PassOver = DateTime.Today.AddDays(-8).AddHours(19).AddMinutes(10), Direction = PassOverDirection.Out, LicensePlate = "ABC129" },
                // --
                new GatekeeperLog { Id = 39, PassOver = DateTime.Today.AddDays(-8).AddHours(20).AddMinutes(10), Direction = PassOverDirection.In,  LicensePlate = "ABC123" },
                new GatekeeperLog { Id = 40, PassOver = DateTime.Today.AddDays(-7).AddHours(07).AddMinutes(10), Direction = PassOverDirection.In,  LicensePlate = "ABC124" },
                new GatekeeperLog { Id = 41, PassOver = DateTime.Today.AddDays(-7).AddHours(07).AddMinutes(35), Direction = PassOverDirection.In,  LicensePlate = "ABC125" },
                new GatekeeperLog { Id = 42, PassOver = DateTime.Today.AddDays(-7).AddHours(07).AddMinutes(45), Direction = PassOverDirection.In,  LicensePlate = "ABC126" },
                new GatekeeperLog { Id = 43, PassOver = DateTime.Today.AddDays(-7).AddHours(08).AddMinutes(15), Direction = PassOverDirection.In,  LicensePlate = "ABC127" },
                new GatekeeperLog { Id = 44, PassOver = DateTime.Today.AddDays(-7).AddHours(09).AddMinutes(25), Direction = PassOverDirection.In,  LicensePlate = "ABC128" },
                new GatekeeperLog { Id = 45, PassOver = DateTime.Today.AddDays(-7).AddHours(10).AddMinutes(35), Direction = PassOverDirection.In,  LicensePlate = "ABC129" },
                new GatekeeperLog { Id = 46, PassOver = DateTime.Today.AddDays(-7).AddHours(16).AddMinutes(10), Direction = PassOverDirection.Out, LicensePlate = "ABC123" },
                new GatekeeperLog { Id = 47, PassOver = DateTime.Today.AddDays(-7).AddHours(17).AddMinutes(10), Direction = PassOverDirection.Out, LicensePlate = "ABC124" },
                new GatekeeperLog { Id = 48, PassOver = DateTime.Today.AddDays(-7).AddHours(18).AddMinutes(15), Direction = PassOverDirection.Out, LicensePlate = "ABC125" },
                new GatekeeperLog { Id = 49, PassOver = DateTime.Today.AddDays(-7).AddHours(19).AddMinutes(20), Direction = PassOverDirection.Out, LicensePlate = "ABC126" },
                new GatekeeperLog { Id = 50, PassOver = DateTime.Today.AddDays(-7).AddHours(20).AddMinutes(25), Direction = PassOverDirection.Out, LicensePlate = "ABC127" },
                new GatekeeperLog { Id = 51, PassOver = DateTime.Today.AddDays(-7).AddHours(21).AddMinutes(30), Direction = PassOverDirection.Out, LicensePlate = "ABC128" }
            );                                                                                                                                             
        }
    }
}