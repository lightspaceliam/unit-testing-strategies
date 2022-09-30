using System.Linq.Expressions;

namespace DataService.Abstract
{
    public interface IDataService<T>
    {
        List<T> Find(Expression<Func<T, bool>> filter);
    }
}
