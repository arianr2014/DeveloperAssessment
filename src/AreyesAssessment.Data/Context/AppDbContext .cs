using Microsoft.EntityFrameworkCore;
using AreyesAssessment.Data.Entities;

namespace AreyesAssessment.Data.Context
{  public class AppDbContext : DbContext
    {
        public DbSet<Donor> Donors { get; set; } = null!;
        public DbSet<Pledge> Pledges { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<ChangeLog> changelog { get; set; } = null!;
        public DbSet<PledgePayment> PledgePayments { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación muchos a muchos entre Pledges y Payments
            modelBuilder.Entity<PledgePayment>()
                .HasKey(pp => new { pp.PledgeID, pp.PaymentID });

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.HasKey(d => d.DonorID);  // Clave primaria
                entity.Property(d => d.DonorID).ValueGeneratedOnAdd();  // Generación de identidad
                // Otros mapeos y configuraciones para Donor
            });
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(d => d.PaymentID);  // Clave primaria
                entity.Property(d => d.PaymentID).ValueGeneratedOnAdd();  // Generación de identidad
                // Otros mapeos y configuraciones para Donor
            });

            modelBuilder.Entity<Pledge>(entity =>
            {
                entity.HasKey(d => d.PledgeID);  // Clave primaria
                entity.Property(d => d.PledgeID).ValueGeneratedOnAdd();  // Generación de identidad
                // Otros mapeos y configuraciones para Donor
            });


         

            modelBuilder.Entity<PledgePayment>()
                .HasOne(pp => pp.Pledge)
                .WithMany(p => p.PledgePayments)
                .HasForeignKey(pp => pp.PledgeID);

            modelBuilder.Entity<PledgePayment>()
                .HasOne(pp => pp.Payment)
                .WithMany(p => p.PledgePayments)
                .HasForeignKey(pp => pp.PaymentID);

            // Configuración de la relación uno a muchos entre Donor y Pledge
            modelBuilder.Entity<Pledge>()
                .HasOne(p => p.Donor)
                .WithMany(d => d.Pledges)
                .HasForeignKey(p => p.DonorID);

            // Configuración de la relación uno a muchos entre Donor y Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Donor)
                .WithMany(d => d.Payments)
                .HasForeignKey(p => p.DonorID);


            base.OnModelCreating(modelBuilder);
        }

    }
}
