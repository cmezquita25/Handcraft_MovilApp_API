using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Handcraft_Route.domain.Entities;
#nullable disable

namespace Handcraft_Route.infraestructure.Data
{
    public partial class CFPHandcraftRouteContext : DbContext
    {
        public CFPHandcraftRouteContext()
        {
        }

        public CFPHandcraftRouteContext(DbContextOptions<CFPHandcraftRouteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artesano> Artesanos { get; set; }
        public virtual DbSet<ArtesanosCooperativa> ArtesanosCooperativas { get; set; }
        public virtual DbSet<ProductosArtesano> ProductosArtesanos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Artesano>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Artesano");

                entity.Property(e => e.GeoUbicacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdArtesanos).ValueGeneratedOnAdd();

                entity.Property(e => e.LogotipoNegocio)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MunicipioLocalidad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreArtesano)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RedesSociales)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TallerNegocio)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArtesanosCooperativa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ArtesanosCooperativa");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeoUbicacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdCooperativa).ValueGeneratedOnAdd();

                entity.Property(e => e.NombreComercio)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Platillo1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Platillo2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Platillo3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductosArtesano>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductosArtesano");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fotografia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdProductos).ValueGeneratedOnAdd();

                entity.Property(e => e.MaterialElaborado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
