using Zotikov_Leonid_KT_31_21.Database;
using Zotikov_Leonid_KT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Zotikov_Leonid_KT_31_21.Interfaces.StudentsInterfaces
{
    public interface IDisciplineService
    {
        Task AddDisciplineAsync(int studentId, string disciplineName, CancellationToken cancellationToken = default);
    }

    public class DisciplineService : IDisciplineService
    {
        private readonly StudentDbContext _dbContext;

        public DisciplineService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddDisciplineAsync(int studentId, string disciplineName, CancellationToken cancellationToken = default)
        {
            var discipline = await _dbContext.Set<Discipline>().FirstOrDefaultAsync(t => t.StudentId == studentId);

            if (discipline != null)
            {
                var newDiscipline = new Discipline
                {
                    DisciplineName = disciplineName,
                    StudentId = studentId
                };

                _dbContext.Disciplines.Add(newDiscipline);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
