using Microsoft.EntityFrameworkCore;
using PetrovvEgorkt_31_22.Database.Configurations;
using PetrovvEgorkt_31_22.Models;

namespace PetrovvEgorkt_31_22.Database
{

    public class CathedralDbContext: DbContext
    {
        public DbSet<Cathedral> Cathedrals { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<Workload> Workloads { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Заполнение ученых степеней
;
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
