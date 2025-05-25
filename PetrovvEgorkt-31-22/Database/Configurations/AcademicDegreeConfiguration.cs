using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetrovvEgorkt_31_22.Database.Helpers;
using PetrovvEgorkt_31_22.Models;

namespace PetrovvEgorkt_31_22.Database.Configurations
{
    public class AcademicDegreeConfiguration: IEntityTypeConfiguration<AcademicDegree>
    {
        private const string TableName = "cd_academic_degree";

        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.AcademicDegreeId)
                   .HasName($"pk_{TableName}_academic_degree_id");

            builder.Property(p => p.AcademicDegreeId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("academic_degree_id")
                   .HasComment("Идентификатор ученой степени");

            builder.Property(p => p.DegreeName)
                   .IsRequired()
                   .HasColumnName("c_degree_name")
                   .HasColumnType(ColumnType.String).HasMaxLength(50)
                   .HasComment("Название степени");
        }
    }
}