using Microsoft.EntityFrameworkCore;
using PetrovvEgorkt_31_22.Database;
using PetrovvEgorkt_31_22.Models;

namespace PetrovvEgorkt_31_22.Interfaces
{
    public interface ICathedralService
    {
        Task AddCathedralAsync(string cathedralName, int headTeacherID, CancellationToken cancellationToken);
        public Task<Cathedral[]> GetCathedralsAsync(CancellationToken cancellationToken);
        Task ChangeCathedralAsync(int cathedralId, string newCathedralName, int headTeacherID, CancellationToken cancellationToken);
        Task SoftDeleteCathedralAsync(int cathedralId, CancellationToken cancellationToken);
    }
    public class CathedralService : ICathedralService
    {
        private readonly CathedralDbContext _dbContext;
        public CathedralService(CathedralDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Cathedral[]> GetCathedralsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Cathedrals
                .Where(d => !d.IsDeleted)
                .ToArrayAsync(cancellationToken);
        }
        public async Task AddCathedralAsync(string cathedralName, int headTeacherID, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers
                .FirstOrDefaultAsync(t => t.TeacherId == headTeacherID && !t.IsDeleted, cancellationToken);

            if (teacher == null)
            {
                throw new InvalidOperationException($"Invalid Teacher ID");
            }

            var newCathedral = new Cathedral
            {
                CathedralName = cathedralName,
                HeadTeacherId = headTeacherID
            };

            await _dbContext.Cathedrals.AddAsync(newCathedral, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task ChangeCathedralAsync(int cathedralId, string cathedralName, int headTeacherID, CancellationToken cancellationToken)
        {
            var cathedral = await _dbContext.Cathedrals.FirstOrDefaultAsync(d => d.CathedralId == cathedralId && !d.IsDeleted, cancellationToken);
            var teacher = await _dbContext.Teachers
                .FirstOrDefaultAsync(t => t.TeacherId == headTeacherID && !t.IsDeleted, cancellationToken);

            if (teacher == null)
             throw new InvalidOperationException($"Invalid Teacher ID");
            
            if (cathedral == null)
                throw new Exception("The Cathedral with this Id is missing!");

            cathedral.CathedralName = cathedralName;
            cathedral.HeadTeacherId = headTeacherID;

            await _dbContext.SaveChangesAsync();
        }
        public async Task SoftDeleteCathedralAsync(int cathedralId, CancellationToken cancellationToken)
        {
            var cathedral = await _dbContext.Cathedrals
                .Include(c => c.Teachers) // Подгружаем связанных преподавателей
                .FirstOrDefaultAsync(c => c.CathedralId == cathedralId, cancellationToken);
            if (cathedral == null)
            {
                throw new Exception($"Cathedral with ID {cathedralId} not found!");
            }

            if (cathedral.IsDeleted)
            {
                throw new Exception($"Cathedral with ID {cathedralId} was already deleted!");
            }
            if (cathedral != null)
            {
                cathedral.IsDeleted = true;
                foreach (var teacher in cathedral.Teachers.Where(t => !t.IsDeleted))
                {
                    teacher.IsDeleted = true;
                }
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
