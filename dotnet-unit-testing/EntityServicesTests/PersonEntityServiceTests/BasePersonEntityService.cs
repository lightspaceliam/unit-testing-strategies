using EntityServices;
using EntityServices.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityServicesTests.PersonEntityServiceTests
{
    public abstract class BasePersonEntityService
    {
        protected IEntityService<Person> Service;
        private readonly DbContextOptions<UnitTestingDbContext> _options;
        protected readonly UnitTestingDbContext Context;

        public BasePersonEntityService() 
        {
            _options = new DbContextOptionsBuilder<UnitTestingDbContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(databaseName: $"TESTING_{this.GetType().Name}_{DateTime.Now.Ticks}")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            Context = new UnitTestingDbContext(_options);

            Service = new PersonEntityService(new UnitTestingDbContext(_options));
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