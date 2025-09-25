using System.Threading.Tasks;

namespace Navistar.DAO.Core
{
    /// <summary>
    /// Interface que contiene los método genericos para la administración de los catálogos de la aplicación
    /// </summary>
    /// <typeparam name="TEntity">Entidad</typeparam>
    public interface IDao<TEntity> where TEntity : class
    {
        /// <summary>
        /// Obtiene la entidad por medio de su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> Get(int id);

        /// <summary>
        /// Método que persiste la entidad
        /// </summary>
        /// <param name="entity">Entidad</param>
        /// <returns></returns>
        Task<int> Add(TEntity entity);

        /// <summary>
        /// Método que actualiza los datos de la entidad proporcionada
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entidad</returns>
        Task<int> Update(TEntity entity);
    }
}
