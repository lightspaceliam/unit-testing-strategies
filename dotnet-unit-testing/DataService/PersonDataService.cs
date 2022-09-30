using DataService.Abstract;
using Entities;

namespace DataService
{
    public class PersonDataService : DataServiceBase<Person>
    {
        public PersonDataService(UnitTestingDbContext context)
            : base(context)
        { }
    }
}