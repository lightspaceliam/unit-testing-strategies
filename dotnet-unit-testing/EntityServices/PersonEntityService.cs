using EntityServices.Abstract;
using Entities;

namespace EntityServices
{
    public class PersonEntityService : EntityService<Person>
    {
        public PersonEntityService(UnitTestingDbContext context)
            : base(context)
        { }
    }
}