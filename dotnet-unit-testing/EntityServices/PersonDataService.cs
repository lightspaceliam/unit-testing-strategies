using EntityServices.Abstract;
using Entities;

namespace EntityServices
{
    public class PersonDataService : DataServiceBase<Person>
    {
        public PersonDataService(UnitTestingDbContext context)
            : base(context)
        { }
    }
}