using EntityServices;
using EntityServices.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityServicesTests.PersonDataServiceTests
{
    public abstract class BasePersonDataService
    {
        protected IDataService<Person> Service;
        private readonly DbContextOptions<UnitTestingDbContext> _options;
        protected readonly UnitTestingDbContext Context;

        public BasePersonDataService() 
        {
            _options = new DbContextOptionsBuilder<UnitTestingDbContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(databaseName: $"TESTING_{this.GetType().Name}_{DateTime.Now.Ticks}")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            Context = new UnitTestingDbContext(_options);

            Service = new PersonDataService(new UnitTestingDbContext(_options));
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