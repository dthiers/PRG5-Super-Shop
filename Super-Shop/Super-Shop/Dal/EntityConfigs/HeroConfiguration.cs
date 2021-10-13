using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Super_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Shop.Dal
{
    internal class HeroConfiguration : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> builder)
        {
            #region table definition
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(256);

            builder.Property(h => h.PowerLevel)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(h => h.ImageUri)
                .HasColumnType("nvarchar(512)")
                .HasDefaultValue("~/img/default_hero.png");

            /// SQL Value Expression ==> CURRENT_TIMESTAMP
            builder.Property(h => h.CreatedAt)
                .HasColumnType("Date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            #endregion

            #region dataseed
            builder.HasData(
                new Hero() { Id = 1, Name = "Iron Man", PowerLevel = 9001, ImageUri = "~/img/iron_man.png" },
                new Hero() { Id = 2, Name = "Kermit the frog", PowerLevel = 5, ImageUri = "~/img/kermit.png" },
                new Hero() { Id = 3, Name = "Batman", PowerLevel = 1, ImageUri = "~/img/batman.png" },
                new Hero() { Id = 4, Name = "Deadpool", PowerLevel = 200, ImageUri = "~/img/deadpool.png" },
                new Hero() { Id = 5, Name = "Wolverine", PowerLevel = 150, ImageUri = "~/img/wolverine.png" });
            #endregion
        }
    }
}
