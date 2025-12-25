using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Faculties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Faculties.Configurations;
internal sealed class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.Description)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(f => f.EmployeeId)
            .IsRequired(false);

        builder.Property(f => f.CreatedAt)
            .IsRequired();

      
        // Fix for CS1061 and CS1002: Removed invalid .HasField call
        builder.HasMany(f => f.Classes)
            .WithOne()
            .HasForeignKey(o => o.FacultyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.Subjects)
          .WithOne()
          .HasForeignKey(o => o.FacultyId)
          .OnDelete(DeleteBehavior.Cascade);
    }
}
