using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Super_Shop.Models;
using System.Collections.Generic;

namespace Super_Shop.Dal
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            #region table definition
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnType("nchar(256)");

            builder.Property(t => t.ImageUri)
               .HasColumnType("nvarchar(512)")
               .HasDefaultValue("~/img/employees/default_employee.png");

            
            builder.Ignore(t => t.MemberIds);
            #endregion

            #region dataseed
            builder.HasData(
                new Team() { Id = 1, Name = "The dream team", MemberIds = new[] { 1, 2, 3 }, ImageUri = "" },
                new Team() { Id = 2, Name = "The unbrella accademy", MemberIds = new[] { 2, 3, 4 }, ImageUri = "" },
                new Team() { Id = 3, Name = "Dharma Initiative", MemberIds = new[] { 3, 4, 5 }, ImageUri = "" });
            #endregion

            /// Join table between Team and Heroes
            builder.HasMany(t => t.Heroes)
                .WithMany(h => h.Teams)
                .UsingEntity(join => join
                .HasData(
                    new { TeamsId = 1, HeroesId = 1 },
                    new { TeamsId = 1, HeroesId = 2 },
                    new { TeamsId = 1, HeroesId = 3 },
                    new { TeamsId = 2, HeroesId = 2 },
                    new { TeamsId = 2, HeroesId = 3 },
                    new { TeamsId = 2, HeroesId = 4 },
                    new { TeamsId = 3, HeroesId = 3 },
                    new { TeamsId = 3, HeroesId = 4 },
                    new { TeamsId = 3, HeroesId = 5 }
                    ));


        }
    }
}