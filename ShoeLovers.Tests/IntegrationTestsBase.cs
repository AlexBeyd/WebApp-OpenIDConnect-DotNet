using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeLovers.Api.Managers;
using ShoeLovers.Repo;

namespace IntegrationTests
{
    [TestClass]
    public class IntegrationTestsBase
    {
        private IUnitOfWork _uow;
        protected IUserSelectionManager _userMgr;        
        protected DbContextOptionsBuilder<RepoContext> _builder;
        protected string _testUserId = "";

        [TestInitialize]
        public void Init()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _builder = new DbContextOptionsBuilder<RepoContext>();
            object p = _builder.UseSqlServer(config.GetConnectionString("ShoeLovers"));

            _uow = new UnitOfWork(new RepoContext(_builder.Options));
            _userMgr = new UserSelectionManager(_uow);
        }
    }
}