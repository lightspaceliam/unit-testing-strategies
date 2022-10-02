using System.Linq.Expressions;

namespace EntityServices.Abstract
{
    public interface IDataService<T>
    {
        List<T> Find(Expression<Func<T, bool>> filter);
    }
}
