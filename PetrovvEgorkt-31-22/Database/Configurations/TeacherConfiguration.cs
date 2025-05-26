using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetrovvEgorkt_31_22.Database.Helpers;
using PetrovvEgorkt_31_22.Models;

namespace PetrovvEgorkt_31_22.Database.Configurations
{
    public class TeacherConfiguration: IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.TeacherId)
                   .HasName($"pk_{TableName}_teacher_id");

            builder.Property(p => p.TeacherId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("teacher_id")
                   .HasComment("Идентификатор преподавателя");

            builder.Property(p => p.FirstName)
                   .IsRequired()
                   .HasColumnName("c_teacher_firstname")
                   .HasColumnType(ColumnType.String).HasMaxLength(50)
                   .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                   .IsRequired()
                   .HasColumnName("c_teacher_lastname")
                   .HasColumnType(ColumnType.String).HasMaxLength(50)
                   .HasComment("Фамилия преподавателя");

            builder.Property(p => p.MiddleName)
                   .HasColumnName("c_teacher_middlename")
                   .HasColumnType(ColumnType.String).HasMaxLength(50)
                   .HasComment("Отчество преподавателя");

            builder.Property(p => p.CathedralId)
                   .HasColumnName("f_cathedral_id")
                   .HasComment("Идентификатор кафедры");

            builder.Property(p => p.AcademicDegreeId)
                   .HasColumnName("f_academic_degree_id")
                   .HasComment("Идентификатор ученой степени");

            builder.Property(p => p.PositionId)
                   .HasColumnName("f_position_id")
                   .HasComment("Идентификатор должности");
            // Soft-delete columns
            builder.Property(p => p.IsDeleted)
                .HasColumnName("c_is_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasDefaultValue(false)
                .IsRequired()
                .HasComment("Флаг мягкого удаления (true - запись удалена)");

            builder.HasOne(p => p.Cathedral)
                   .WithMany()
                   .HasForeignKey(p => p.CathedralId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("fk_teacher_cathedral");

            builder.HasOne(p => p.AcademicDegree)
                   .WithMany()
                   .HasForeignKey(p => p.AcademicDegreeId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("fk_teacher_academic_degree");

            builder.HasOne(p => p.Position)
                   .WithMany()
                   .HasForeignKey(p => p.PositionId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("fk_teacher_position");

            builder.HasOne(p => p.Cathedral)
                   .WithMany(c => c.Teachers)  // Укажите обратную навигацию
                   .HasForeignKey(p => p.CathedralId);




            builder.Navigation(p => p.Cathedral)
                .AutoInclude();
        }
    }
}
