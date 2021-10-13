using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Super_Shop.Models;

namespace Super_Shop.Dal
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            #region table definition
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Role)
                .IsRequired()
                .HasColumnType("nchar(64)")
                .HasDefaultValue("unknown");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("nchar(64)");

            builder.Property(e => e.ImageUri)
                .HasColumnType("nvarchar(512)")
                .HasDefaultValue("~/img/employees/default_employee.png");

            #endregion

            #region dataseed
            builder.HasData(
                new Employee() { Id = 1, Name = "Eric Kuijpers", Role = "CEO", ImageUri = "~/img/employees/eric.jfif" },
                new Employee() { Id = 2, Name = "Carron Schilders", Role = "CTO", ImageUri = "~/img/employees/carron.jfif" },
                new Employee() { Id = 3, Name = "Stijn Smulders", Role = "Service desk", ImageUri = "~/img/employees/stijn.jfif" },
                new Employee() { Id = 4, Name = "Adam Sandler", Role = "Intern", ImageUri = "~/img/interns/adam.jpg" });
            #endregion
        }
    }
}
