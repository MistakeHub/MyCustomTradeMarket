using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TradeMarket.Product.sakila
{
    public partial class iteminfoContext : DbContext
    {
        public iteminfoContext()
        {
        }

        public iteminfoContext(DbContextOptions<iteminfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Productitem> Products { get; set; } = null!;
        public virtual DbSet<Quality> Qualities { get; set; } = null!;
        public virtual DbSet<Rarity> Rarities { get; set; } = null!;
        public virtual DbSet<Slot> Slots { get; set; } = null!;
        public virtual DbSet<Typeofitem> Types { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;port=3306;user=root;password=.aA1234568_;database=iteminfo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("characters");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Character1)
                    .HasMaxLength(45)
                    .HasColumnName("Character");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("games");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Game1)
                    .HasMaxLength(45)
                    .HasColumnName("Game");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.HasIndex(e => e.Idcharacter, "FK_CHARACTER_idx");

                entity.HasIndex(e => e.Idgame, "FK_GAME_idx");

                entity.HasIndex(e => e.Idquality, "FK_QUALITY_idx");

                entity.HasIndex(e => e.Idrarity, "FK_RARITY_idx");

                entity.HasIndex(e => e.Idslot, "FK_SLOT_idx");

                entity.HasIndex(e => e.Idtype, "FK_TYPE_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Idcharacter).HasColumnName("idcharacter");

                entity.Property(e => e.Idgame).HasColumnName("idgame");

                entity.Property(e => e.Idquality).HasColumnName("idquality");

                entity.Property(e => e.Idrarity).HasColumnName("idrarity");

                entity.Property(e => e.Idslot).HasColumnName("idslot");

                entity.Property(e => e.Idtype).HasColumnName("idtype");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdcharacterNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Idcharacter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHARACTER");

                entity.HasOne(d => d.IdgameNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Idgame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GAME");

                entity.HasOne(d => d.IdqualityNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Idquality)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUALITY");

                entity.HasOne(d => d.IdrarityNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Idrarity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RARITY");

                entity.HasOne(d => d.IdslotNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Idslot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SLOT");

                entity.HasOne(d => d.IdtypeNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Idtype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPE");
            });

            modelBuilder.Entity<Productitem>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.Iditem, "FK_ITEM_idx");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Iditem).HasColumnName("iditem");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.IditemNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Iditem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM");
            });

            modelBuilder.Entity<Quality>(entity =>
            {
                entity.ToTable("qualities");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Quality1)
                    .HasMaxLength(45)
                    .HasColumnName("Quality");
            });

            modelBuilder.Entity<Rarity>(entity =>
            {
                entity.ToTable("rarities");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Rarity1)
                    .HasMaxLength(45)
                    .HasColumnName("Rarity");
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("slots");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Slot1)
                    .HasMaxLength(45)
                    .HasColumnName("Slot");
            });

            modelBuilder.Entity<Typeofitem>(entity =>
            {
                entity.ToTable("types");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Type1)
                    .HasMaxLength(45)
                    .HasColumnName("Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
