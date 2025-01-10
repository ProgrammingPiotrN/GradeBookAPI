using GradeBook.Domain.Entities;
using GradeBook.Infrastructure.Config.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradeBook.Infrastructure.Config
{
    public class StudentConfiguration : BaseEntityConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            //Tworzenie tabeli
            builder.ToTable("Students");

            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            //Index na pole unikalne
            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .HasConversion<DateOnlyConverter>()
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.YearEnrolled)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
