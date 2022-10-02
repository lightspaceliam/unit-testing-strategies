using Api.Controllers;
using EntityServices;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Api.Tests.PersonControllerTests
{
    public abstract class BasePersonController
    {
        private readonly DbContextOptions<UnitTestingDbContext> _options;
        protected readonly UnitTestingDbContext Context;
        protected readonly PersonController Controller;

        public BasePersonController()
        {
            _options = new DbContextOptionsBuilder<UnitTestingDbContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(databaseName: $"TESTING_{this.GetType().Name}_{DateTime.Now.Ticks}")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            Context = new UnitTestingDbContext(_options);
            var personService = new PersonDataService(new UnitTestingDbContext(_options));

            var services = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            Controller = new PersonController(services.GetService<ILogger<PersonController>>(), personService);
        }

        public void InitializeData(List<Person> people)
        {
            using var context = new UnitTestingDbContext(_options);
            foreach (var entity in people)
            {
                context.Add(entity);
            }
            context.SaveChanges();
        }
    }
}
