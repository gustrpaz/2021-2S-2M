using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_roman_webAPI.Domains;

#nullable disable

namespace senai_roman_webAPI.Contexts
{
    public partial class RomanContext : DbContext
    {
        public RomanContext()
        {
        }

        public RomanContext(DbContextOptions<RomanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Projeto> Projetos { get; set; }
        public virtual DbSet<Tema> Temas { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0113F3\\SQLEXPRESS; initial catalog=ROMAN; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.IdProjeto)
                    .HasName("PK__Projeto__8FCCED7647935791");

                entity.ToTable("Projeto");

                entity.Property(e => e.IdProjeto)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idProjeto");

                entity.Property(e => e.DescricaoProjeto)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("descricaoProjeto");

                entity.Property(e => e.IdTema).HasColumnName("idTema");

                entity.Property(e => e.NomeProjeto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeProjeto");

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdTema)
                    .HasConstraintName("FK__Projeto__idTema__3E52440B");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasKey(e => e.IdTema)
                    .HasName("PK__Tema__BCD9EB486587AB5A");

                entity.ToTable("Tema");

                entity.Property(e => e.IdTema)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTema");

                entity.Property(e => e.NomeTema)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nomeTema");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFFA673DE16");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.TituloUsuario)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("tituloUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A68884DD58");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.EmailUsuario, "UQ__Usuario__ACC1DD99C6F54084")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idUsuario");

                entity.Property(e => e.EmailUsuario)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("emailUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("senhaUsuario");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
