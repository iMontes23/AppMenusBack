using Navistar.Utils.Core;
using System.Threading.Tasks;

namespace Navistar.Repository.Carga
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int Id);
        Task<int> Add(TEntity entity);
        void Update(TEntity entity);
    }
}
