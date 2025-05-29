using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using PetrovvEgorkt_31_22.Database;
using PetrovvEgorkt_31_22.Interfaces;
using PetrovvEgorkt_31_22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrovv_egor_kt_31_22.Tests
{
    public class WorkloadIntegrationTest
    {
        public readonly DbContextOptions<CathedralDbContext> _dbContextOptions;

        public WorkloadIntegrationTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<CathedralDbContext>()
            .UseInMemoryDatabase(databaseName: "workloads_db")
            .Options;
        }
        [Fact]
        public async Task GetWorkloads_KT3122_TwoObjects()
        {
            // Arrange
            var ctx = new CathedralDbContext(_dbContextOptions);
            var workloadService = new WorkloadService(ctx);
            var positions = new List<Position>
            {
                new Position
                {
                    PositionName = "Доцент"
                },
                new Position
                {
                    PositionName = "Преподаватель"
                },
                new Position
                {
                    PositionName = "Помощник"
                }
            };
            await ctx.Set<Position>().AddRangeAsync(positions);

            await ctx.SaveChangesAsync();

            var disciplines = new List<Discipline>
            {
                new Discipline
                {
                    DisciplineName = "Матанализ"
                },
                new Discipline
                {
                    DisciplineName = "Программирование"
                },
                new Discipline
                {
                    DisciplineName = "Чувашский язык"
                }
            };
            await ctx.Set<Discipline>().AddRangeAsync(disciplines);

            await ctx.SaveChangesAsync();

            var academicedegrees = new List<AcademicDegree>
            {
                new AcademicDegree
                {
                    DegreeName = "Бакалавр"
                },
                new AcademicDegree
                {
                    DegreeName = "Магистр"
                },
                new AcademicDegree
                {
                    DegreeName = "8 классов образования"
                }
            };
            await ctx.Set<AcademicDegree>().AddRangeAsync(academicedegrees);

            await ctx.SaveChangesAsync();
            var cathedrals = new List<Cathedral>
            {
                new Cathedral
                {
                    CathedralName = "Кафедра информатики",
                    HeadTeacherId = 1
                },
                new Cathedral
                {
                    CathedralName = "Кафедра математики",
                    HeadTeacherId = 2
                },
                new Cathedral
                {
                    CathedralName = "Кафедра дота 2",
                    HeadTeacherId = 3
                }
            };
            await ctx.Set<Cathedral>().AddRangeAsync(cathedrals);

            await ctx.SaveChangesAsync();
            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    FirstName = "volodya",
                    LastName = "vladimirov",
                    MiddleName = "vladimirovich",
                    CathedralId = 1,
                    PositionId = 1,
                    AcademicDegreeId = 1,
                },
                new Teacher
                {
                    FirstName = "jendos",
                    LastName = "evgenevich",
                    MiddleName = "evgeniev",
                    CathedralId = 2,
                    PositionId = 2,
                    AcademicDegreeId = 2,
                },
                new Teacher
                {
                    FirstName = "serega",
                    LastName = "pirat",
                    MiddleName = "solo",
                    CathedralId = 3,
                    PositionId = 3,
                    AcademicDegreeId = 3,
                }
            };
            await ctx.Set<Teacher>().AddRangeAsync(teachers);

            await ctx.SaveChangesAsync();
            var workloads = new List<Workload>
            {
                new Workload
                {
                    TeacherId=1,
                    DisciplineId=1,
                    Hours=120,
                    LessonType="Лекции"
                },
                new Workload
                {
                    TeacherId=2,
                    DisciplineId=2,
                    Hours=210,
                    LessonType="Практика"
                },
                new Workload
                {
                    TeacherId=3,
                    DisciplineId=3,
                    Hours=90,
                    LessonType="Лабораторные"
                }
            };
            await ctx.Set<Workload>().AddRangeAsync(workloads);

            await ctx.SaveChangesAsync();
            // Act
            var workloadsResult = await workloadService.GetWorkloadsAsync(CancellationToken.None);
            // Assert
            Assert.Equal(3, workloadsResult.Length);
        }
    }
}

