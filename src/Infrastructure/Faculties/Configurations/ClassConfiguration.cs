using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Faculties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Faculties.Configurations;
internal sealed class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Grade).IsRequired();
        builder.Property(c => c.IsOnline).IsRequired();
        builder.Property(c => c.FacultyId).IsRequired();







  //      builder.Property<List<Guid>>("_studentIds")
  //   .HasColumnName("StudentIds")
  //   .HasConversion(
  //     v => string.Join(",", v),
  //     v => v
  //       .Split(",", StringSplitOptions.RemoveEmptyEntries)
  //       .Select(Guid.Parse)
  //       .ToList()
  //   ).Metadata
  //.SetValueComparer(new ValueComparer<List<Guid>>(
  //  (a, b) =>
  //a != null && b != null
  //  ? a.SequenceEqual(b)
  //  : a == null && b == null,



        //  v =>
        //    v != null
        //      ? v.Aggregate(0, (h, e) => HashCode.Combine(h, e.GetHashCode()))
        //      : 0,

        //  v =>
        //    v != null
        //      ? new List<Guid>(v)
        //      : new List<Guid>()
        //));


        //      builder
        // .Navigation(c => c.SubjectTeacherConnectorIds)
        // .UsePropertyAccessMode(PropertyAccessMode.Field)
        // .HasField("_subjectTeacherConnectorIds");




        //      builder.UsePropertyAccessMode(PropertyAccessMode.Field).OwnsMany(c => c.SubjectTeacherConnectorIds, stb =>
        //      {


        //          stb.ToTable("SubjectTeachers");
        //          stb.WithOwner().HasForeignKey("ClassId");
        //          stb.Property<Guid>("Id");
        //          stb.HasKey("Id");
        //          stb.Property(st => st.SubjectId).HasColumnName("SubjectId");
        //          stb.Property(st => st.TeacherId).HasColumnName("TeacherId");
        //      });






    }
}
