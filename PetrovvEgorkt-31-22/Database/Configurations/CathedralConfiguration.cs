using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetrovvEgorkt_31_22.Database.Helpers;
using PetrovvEgorkt_31_22.Models;

namespace PetrovvEgorkt_31_22.Database.Configurations
{
    public class CathedralConfiguration : IEntityTypeConfiguration<Cathedral>
    {
        private const string TableName = "cd_cathedral";
        public void Configure(EntityTypeBuilder<Cathedral> builder)
        {
            builder.ToTable(TableName);

            builder
                .HasKey(p => p.CathedralId)
                .HasName($"pk_{TableName}_cathedral_id");

            builder.Property(p => p.CathedralId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CathedralId)
                .HasColumnName("cathedral_id")
                .HasComment("Идентификатор записи кафедры");

            builder.Property(p => p.CathedralName)
                .IsRequired()
                .HasColumnName("c_cathedralname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя кафедры");

            // Soft-delete columns
            builder.Property(p => p.IsDeleted)
                .HasColumnName("c_is_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasDefaultValue(false)
                .IsRequired()
                .HasComment("Флаг мягкого удаления (true - запись удалена)");

            builder.Property(p => p.HeadTeacherId)
                   .HasColumnName("f_head_teacher_id")
                   .HasComment("Идентификатор заведующего кафедрой");

            builder.HasMany(c => c.Teachers)
            .WithOne(t => t.Cathedral)
            .HasForeignKey(t => t.CathedralId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.HeadTeacher)
                   .WithOne()
                   .HasForeignKey<Cathedral>(p => p.HeadTeacherId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("fk_cathedral_head_teacher");


        }
    }
}