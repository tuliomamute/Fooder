namespace Fooder.WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FooderModel : DbContext
    {
        public FooderModel()
            : base("name=FooderModels")
        {
        }

        public virtual DbSet<CATEGORIAS> CATEGORIAS { get; set; }
        public virtual DbSet<ESTOQUE> ESTOQUE { get; set; }
        public virtual DbSet<MERCADOS> MERCADOS { get; set; }
        public virtual DbSet<PRODUTOS> PRODUTOS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORIAS>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<ESTOQUE>()
                .Property(e => e.ULTIMA_ATUALIZACAO)
                .IsUnicode(false);

            modelBuilder.Entity<ESTOQUE>()
                .Property(e => e.PRECO)
                .HasPrecision(20, 2);

            modelBuilder.Entity<MERCADOS>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<MERCADOS>()
                .Property(e => e.MAPA)
                .IsUnicode(false);

            modelBuilder.Entity<MERCADOS>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<MERCADOS>()
                .Property(e => e.URL_OFICIAL)
                .IsUnicode(false);

            modelBuilder.Entity<MERCADOS>()
                .Property(e => e.URL_MAPA)
                .IsUnicode(false);

            modelBuilder.Entity<MERCADOS>()
                .HasMany(e => e.ESTOQUE)
                .WithRequired(e => e.MERCADOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUTOS>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUTOS>()
                .HasMany(e => e.ESTOQUE)
                .WithRequired(e => e.PRODUTOS)
                .WillCascadeOnDelete(false);
        }
    }
}
