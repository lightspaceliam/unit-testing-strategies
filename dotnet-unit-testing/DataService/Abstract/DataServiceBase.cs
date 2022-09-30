using Entities;
using Entities.Abstract;
using System.Linq.Expressions;

namespace DataService.Abstract
{
    public abstract class DataServiceBase<T> : IDataService<T> 
        where T : class, IEntity
    {
        protected readonly UnitTestingDbContext Context;

        public DataServiceBase(UnitTestingDbContext context) 
        {
            Context = context;
        }

        public  virtual List<T> Find(Expression<Func<T, bool>> filter)
        {
            var results = Context.Set<T>()
                .Where(filter)
                .ToList();

            return results;
        }
    }
}
