using Microsoft.EntityFrameworkCore;
using PetrovvEgorkt_31_22.Database.Configurations;
using PetrovvEgorkt_31_22.Models;

namespace PetrovvEgorkt_31_22.Database
{
    public class CathedralDbContext: DbContext
    {
        DbSet<Cathedral> Cathedrals { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<AcademicDegree> AcademicDegrees { get; set; }
        DbSet<Workload> Workloads { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CathedralConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
        }
        public CathedralDbContext(DbContextOptions<CathedralDbContext> options): base(options)
        {


        }
    }
}
