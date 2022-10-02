using System.Linq.Expressions;

namespace EntityServices.Abstract
{
    public interface IEntityService<T>
    {
        List<T> Find(Expression<Func<T, bool>> filter);
    }
}
