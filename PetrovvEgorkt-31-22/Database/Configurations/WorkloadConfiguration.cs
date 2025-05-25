using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetrovvEgorkt_31_22.Database.Helpers;
using PetrovvEgorkt_31_22.Models;

namespace PetrovvEgorkt_31_22.Database.Configurations
{
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
    {
        private const string TableName = "cd_workload";

        public void Configure(EntityTypeBuilder<Workload> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.WorkloadId)
                   .HasName($"pk_{TableName}_workload_id");

            builder.Property(p => p.WorkloadId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("workload_id")
                   .HasComment("Идентификатор нагрузки");

            builder.Property(p => p.TeacherId)
                   .HasColumnName("f_teacher_id")
                   .HasComment("Идентификатор преподавателя");

            builder.Property(p => p.DisciplineId)
                   .HasColumnName("f_discipline_id")
                   .HasComment("Идентификатор дисциплины");

            builder.Property(p => p.LessonType)
                   .IsRequired()
                   .HasColumnName("c_lesson_type")
                   .HasColumnType(ColumnType.String).HasMaxLength(20)
                   .HasComment("Тип занятия (лекция/практика)");

            builder.Property(p => p.Hours)
                   .IsRequired()
                   .HasColumnName("c_hours")
                   .HasComment("Количество часов");

            builder.HasOne(p => p.Teacher)
                   .WithMany()
                   .HasForeignKey(p => p.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("fk_workload_teacher");

            builder.HasOne(p => p.Discipline)
                   .WithMany()
                   .HasForeignKey(p => p.DisciplineId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("fk_workload_discipline");
        }
    }
}
