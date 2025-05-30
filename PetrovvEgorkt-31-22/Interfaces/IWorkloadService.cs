using Microsoft.EntityFrameworkCore;
using PetrovvEgorkt_31_22.Database;
using PetrovvEgorkt_31_22.Models;

namespace PetrovvEgorkt_31_22.Interfaces
{
    public interface IWorkloadService
    {
        Task AddWorkloadAsync(int teacherId, int disciplineId, string lessonType, int hours, CancellationToken cancellationToken);
        Task ChangeWorkloadAsync(int workloadId, int teacherId, int disciplineId, string lessonType, int hours, CancellationToken cancellationToken);

        //Task RemoveWorkloadAsync(int workloadId, CancellationToken cancellationToken);
        public Task<Workload[]> GetWorkloadsAsync(CancellationToken cancellationToken);
        Task SoftDeleteWorkloadAsync(int workloadId, CancellationToken cancellationToken);
        //Task ChangeWorkloadAsync(int workloadId, string newWorkloadName, int headTeacherID, CancellationToken cancellationToken);
    }
    public class WorkloadService : IWorkloadService
    {
        private readonly CathedralDbContext _dbContext;
        public WorkloadService(CathedralDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Workload[]> GetWorkloadsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Workloads
                .Where(d => !d.IsDeleted)
                .Include(w => w.Teacher)
                .ToArrayAsync(cancellationToken);
        }
        public async Task AddWorkloadAsync(int teacherId, int disciplineId, string lessonType, int hours, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers
                .FirstOrDefaultAsync(t => t.TeacherId == teacherId && !t.IsDeleted, cancellationToken);
            var discipline = await _dbContext.Disciplines
                .FirstOrDefaultAsync(t => t.DisciplineId == disciplineId && !t.IsDeleted, cancellationToken);
            if (teacher == null)
                throw new InvalidOperationException($"Invalid Teacher ID");
            if (discipline == null)
                throw new InvalidOperationException($"Invalid discipline ID");
            var newWorkload = new Workload
            {
                TeacherId = teacherId,
                DisciplineId = disciplineId,
                LessonType = lessonType,
                Hours = hours
            };

            await _dbContext.Workloads.AddAsync(newWorkload, cancellationToken);
            await _dbContext.SaveChangesAsync();
        }
        public async Task ChangeWorkloadAsync(int workloadId,int teacherId, int disciplineId, string lessonType, int hours, CancellationToken cancellationToken)
        {
            var workload = await _dbContext.Workloads.FirstOrDefaultAsync(d => d.WorkloadId == workloadId && !d.IsDeleted, cancellationToken);
            var teacher = await _dbContext.Teachers
                .FirstOrDefaultAsync(t => t.TeacherId == teacherId && !t.IsDeleted, cancellationToken);
            var discipline = await _dbContext.Disciplines
                .FirstOrDefaultAsync(t => t.DisciplineId == disciplineId && !t.IsDeleted, cancellationToken);
            if (teacher == null)
                throw new InvalidOperationException($"Invalid Teacher ID");
            if (discipline == null)
                throw new InvalidOperationException($"Invalid discipline ID");
            if (workload == null)
                throw new Exception("The Workload with this Id is missing!");


            workload.TeacherId = teacherId;
            workload.DisciplineId = disciplineId;
            workload.LessonType = lessonType;
            workload.Hours = hours;

            await _dbContext.SaveChangesAsync();
        }
        public async Task SoftDeleteWorkloadAsync(int workloadId, CancellationToken cancellationToken)
        {
            var workload = await _dbContext.Workloads
                .FirstOrDefaultAsync(c => c.WorkloadId == workloadId, cancellationToken);
            if (workload == null)
            {
                throw new Exception($"Workload with ID {workloadId} not found!");
            }

            if (workload.IsDeleted)
            {
                throw new Exception($"Workload with ID {workloadId} was already deleted!");
            }
            if (workload != null)
            {
                workload.IsDeleted = true;

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
