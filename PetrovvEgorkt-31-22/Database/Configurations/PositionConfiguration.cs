using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetrovvEgorkt_31_22.Database.Helpers;
using PetrovvEgorkt_31_22.Models;

namespace PetrovvEgorkt_31_22.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "cd_position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.PositionId)
                   .HasName($"pk_{TableName}_position_id");

            builder.Property(p => p.PositionId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("position_id")
                   .HasComment("Идентификатор должности");

            builder.Property(p => p.PositionName)
                   .IsRequired()
                   .HasColumnName("c_position_name")
                   .HasColumnType(ColumnType.String).HasMaxLength(50)
                   .HasComment("Название должности");
        }
    }
}
