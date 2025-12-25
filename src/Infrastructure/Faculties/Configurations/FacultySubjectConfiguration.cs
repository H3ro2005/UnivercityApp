using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Faculties;
using Domain.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Faculties.Configurations;
internal sealed class FacultySubjectConfiguration : IEntityTypeConfiguration<FacultyUsedSubject>
{
    public void Configure(EntityTypeBuilder<FacultyUsedSubject> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.Category).IsRequired();

        builder.Property(s => s.Grade)
            .IsRequired();

        builder.Property(s => s.Semester)
            .IsRequired();

        builder.Property(c => c.FacultyId).IsRequired();
    }
}
