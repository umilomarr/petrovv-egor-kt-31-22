using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetrovvEgorkt_31_22.Database.Helpers;
using PetrovvEgorkt_31_22.Models;

namespace PetrovvEgorkt_31_22.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.DisciplineId)
                   .HasName($"pk_{TableName}_discipline_id");

            builder.Property(p => p.DisciplineId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("discipline_id")
                   .HasComment("Идентификатор дисциплины");

            builder.Property(p => p.DisciplineName)
                   .IsRequired()
                   .HasColumnName("c_discipline_name")
                   .HasColumnType(ColumnType.String).HasMaxLength(100)
                   .HasComment("Название дисциплины");

            // Soft-delete columns
            builder.Property(p => p.IsDeleted)
                .HasColumnName("c_is_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasDefaultValue(false)
                .IsRequired()
                .HasComment("Флаг мягкого удаления (true - запись удалена)");
        }
    }
}
