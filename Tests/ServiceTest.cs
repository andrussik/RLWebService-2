using System;
using System.Linq;
using System.Threading.Tasks;
using BLL.Factory;
using DAL.Common.Factory;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class ServiceTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly AppDbContext _dbContext;
        private readonly IServiceCollection _bll;

        public ServiceTest(ITestOutputHelper testOutputHelper, IServiceCollection bll)
        {
            _bll = bll;
            _testOutputHelper = testOutputHelper;
            
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<ServiceTest>()
                .AddJsonFile("appsettings.json")
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
            _dbContext = dbContext;
        }

        [Fact]
        public async Task Test1()
        {
            var a = await _bll.SierraFetchService.GetAndSavePublication();
            _testOutputHelper.WriteLine(a.Entries?.Count.ToString());
            a.Entries?.Select(x => x.Marc)?.FirstOrDefault();
            // var sierraBookRepoMock = new Mock<IBookRepository>();
            // var sierraRepoMock = new Mock<ISierraRepositoryCollection>();
            // sierraRepoMock.Setup(x => x.Books).Returns(sierraBookRepoMock.Object);
            // var dalCollectionMock = new Mock<IDalCollection>();
            // dalCollectionMock.Setup(x => x.Uow).Returns(new UnitOfWork(_dbContext));
            // dalCollectionMock.Setup(x => x.SierraRepo).Returns(sierraRepoMock.Object);
            // var services = new ServiceCollection(dalCollectionMock.Object);
            // await services.SierraFetchService.GetAndSavePublication();
        }
    }
}