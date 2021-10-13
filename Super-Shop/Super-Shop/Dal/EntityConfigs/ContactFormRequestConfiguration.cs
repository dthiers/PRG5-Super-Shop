using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Super_Shop.Entities;

namespace Super_Shop.Dal
{
    internal class ContactFormRequestConfiguration : IEntityTypeConfiguration<ContactFormRequest>
    {
        public void Configure(EntityTypeBuilder<ContactFormRequest> builder)
        {
            #region table definition
            builder.HasKey(cfr => cfr.Id);
            builder.Property(cfr => cfr.Title)
                .IsRequired()
                .HasColumnType("nchar(128)");

            builder.Property(cfr => cfr.Message)
                .IsRequired()
                .HasColumnType("nchar(1024)");

            builder.Property(cfr => cfr.Email)
                .IsRequired()
                .HasColumnType("nchar(256)");

            builder.HasOne(cfr => cfr.Hero)
                .WithMany(cfr => cfr.ContactFormRequests);

            #endregion
        }
    }
}