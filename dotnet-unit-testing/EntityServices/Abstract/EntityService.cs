using Entities;
using Entities.Abstract;
using System.Linq.Expressions;

namespace EntityServices.Abstract
{
    public abstract class EntityService<T> : IEntityService<T> 
        where T : class, IEntity
    {
        protected readonly UnitTestingDbContext Context;

        public EntityService(UnitTestingDbContext context) 
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
