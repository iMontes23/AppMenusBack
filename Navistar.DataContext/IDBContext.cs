using System.Data;

namespace Navistar.DataContext
{
    public interface IDBContext<T>where T : IDBContext<T>
    {
        IDbConnection DBConnection { get; }
    }
}
