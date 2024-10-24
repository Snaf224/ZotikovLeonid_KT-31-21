using Zotikov_Leonid_KT_31_21.Database;
using Zotikov_Leonid_KT_31_21.Interfaces.StudentsInterfaces;
using Zotikov_Leonid_KT_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace Zotikov_Leonid_KT_31_21.Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT3121_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-21"
                },
                new Group
                {
                    GroupName = "KT-41-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Leonid",
                    LastName = "Zotikov",
                    MiddleName = "Vladislavich",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "Maksim",
                    LastName = "petrov",
                    MiddleName = "petrovich",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "misha",
                    LastName = "ivanov",
                    MiddleName = "ivanovich",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.StudentFilters.StudentGroupFilter
            {
                GroupName = "KT-31-21"
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);

        }
    }
}
