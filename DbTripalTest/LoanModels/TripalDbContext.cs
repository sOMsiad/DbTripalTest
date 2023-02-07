using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



#nullable disable

namespace DbTripalTest.LoanModels
{
    public partial class TripalDbContext : DbContext
    {
        public TripalDbContext()
        {
        }

        public TripalDbContext(DbContextOptions<TripalDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pakiet> Pakiety { get; set; }
        public virtual DbSet<Paleta> Palety { get; set; }
        public virtual DbSet<Produkt> Produkty { get; set; }
        public virtual DbSet<Uklad> Uklady { get; set; }
        public virtual DbSet<Poziomy> Poziomy { get; set; }
        public virtual DbSet<Warstwa> Warstwy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:127.0.0.1,1433\\SQLEXPRESS;Database=TripalDb;;User ID=adam;Password=adam;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Pakiet>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");
                entity.Property(e => e.WarstwaId)
                    .IsRequired();              

                entity.ToTable("Pakiety");

                entity.Property(e => e.Data).HasColumnType("datetime");
                
                

            });
            
            modelBuilder.Entity<Paleta>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("Palety");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");


            });

            modelBuilder.Entity<Produkt>(entity =>
            {
             //   entity.HasNoKey();

                entity.ToTable("Produkty");

             
                entity.Property(e => e.DataUtworzenia)
                    .HasColumnType("datetime")
                    .HasColumnName("DataUworzenia")
                    .HasDefaultValueSql("getdate()")
                    .ValueGeneratedOnAddOrUpdate();
                entity.Property(e => e.DataOstatniejAktualizacji)
                   .HasColumnType("datetime")
                   .HasColumnName("DataOstatniejAktualizacji")
                   .ValueGeneratedOnUpdate();


                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

              });

            modelBuilder.Entity<Uklad>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("Uklady");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");
                entity.Property(e => e.ProduktId)
                    .IsRequired();
                entity.Property(e => e.PaletaId)
                    .IsRequired();
            });

            modelBuilder.Entity<Poziomy>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");
             //   entity.HasNoKey();

                entity.ToTable("Poziomy");

                entity.Property(e => e.Data).HasColumnType("datetime");
            });
            modelBuilder.Entity<Warstwa>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");
                //   entity.HasNoKey();

                entity.ToTable("Warstwy");

                entity.Property(e => e.ProduktId)
                    .IsRequired();

                entity.Property(e => e.DataUtworzenia)
                 .HasColumnType("datetime")
                 .HasColumnName("DataUworzenia")
                 .HasDefaultValueSql("getdate()")
                 .ValueGeneratedOnAddOrUpdate();
                entity.Property(e => e.DataOstatniejAktualizacji)                
                   .HasColumnType("datetime")
                   .HasColumnName("DataOstatniejAktualizacji")
                   .HasDefaultValueSql("getdate()")
                   .ValueGeneratedOnUpdate();
                   

            });
           
            modelBuilder.Entity<Uklad>()
                .HasOne(u => u.Produkt)
                .WithMany(p => p.Uklady)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Warstwa>()
                .HasOne(u => u.Produkt)
                .WithMany(p => p.Warstwy)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Pakiet>()
                .HasOne(u => u.Warstwa)
                .WithMany(p => p.Pakiety)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Paleta>()
                .HasMany(u => u.Uklady)
                .WithOne(p => p.Paleta)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Poziomy>()
                .HasOne(u => u.Warstwa)
                .WithMany(p => p.Poziomy)
                .OnDelete(DeleteBehavior.NoAction);



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
