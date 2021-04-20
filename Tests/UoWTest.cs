using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DAL.EF;
using DAL.EF.UoW;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class UoWTest
    {
        private readonly IUnitOfWork _uow;
        private readonly ITestOutputHelper _testOutputHelper;
    
        public UoWTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<UoWTest>()
                .Build();

            // Use actual database - integration tests
            var localDbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(configuration["ConnectionStrings:AzureSqlEdge"])
                .Options;
            
            // Use in-memory database - unit tests
            var inMemoryDbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMemoryDb")
                .Options;
            
            var dbContext = new AppDbContext(localDbOptions);
            var uow = new UnitOfWork(dbContext);
            _uow = uow;
            // Seed().Wait();
        }

        private async Task Seed()
        {
            await _uow.BeginTransactionAsync();
            var work1 = new Work();
            var work2 = new Work();
            var work3 = new Work();
            await _uow.Works.AddRangeAsync(new[] {work1, work2, work3});

            _testOutputHelper.WriteLine(work1.Id.ToString());
            _testOutputHelper.WriteLine("Saved");
            var author1 = new Author
            {
                Name = "Test1"
            };
            var author2 = new Author
            {
                Name = "Test2"
            };
            var author3 = new Author
            {
                Name = "Test3"
            };

            await _uow.Authors.AddRangeAsync(new[] {author1, author2, author3});
            _testOutputHelper.WriteLine(author1.Id.ToString());

            var workAuthor1 = new WorkAuthor
            {
                WorkId = work1.Id,
                AuthorId = author1.Id
            };
            var workAuthor2 = new WorkAuthor
            {
                WorkId = work2.Id,
                AuthorId = author2.Id
            };
            var workAuthor3 = new WorkAuthor
            {
                WorkId = work3.Id,
                AuthorId = author3.Id
            };
            await _uow.WorkAuthors.AddRangeAsync(new[] {workAuthor1, workAuthor2, workAuthor3});
            _testOutputHelper.WriteLine(workAuthor1.Id.ToString());
            await _uow.SaveChangesAsync();
        }

        [Fact]
        public async Task Test1()
        {
            var query = _uow.WorkAuthors
                .AsQueryable()
                .Include(x => x.Author)
                .Where(x => x.Author!.Name.StartsWith("Test1"));
            
            var queryString = query.ToQueryString();
            _testOutputHelper.WriteLine(queryString);

            var workAuthors = await query
                .ToListAsync();
            foreach (var workAuthor in workAuthors)
            {
                _testOutputHelper.WriteLine(workAuthor.Author?.Name);
            }
        }

        [Fact]
        public void Test2()
        {
            var maxId = _uow.Publications.GetMaxSierraId();
            _testOutputHelper.WriteLine(maxId);
        }
        
        [Fact]
        public void Test3()
        {
            var maxId = _uow.Publications.GetMaxSierraId();
            _testOutputHelper.WriteLine(maxId);
        }
    }
}