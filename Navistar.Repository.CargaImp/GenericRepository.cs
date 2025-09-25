using Navistar.Repository.Carga;
using System;
using System.Threading.Tasks;

namespace Navistar.Repository.CargaImp
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public Task<int> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(int Id)
        {
            throw new NotImplementedException();
        }

    }
}