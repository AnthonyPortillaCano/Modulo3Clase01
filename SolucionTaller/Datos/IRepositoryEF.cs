using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public interface IRepositoryEF<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetEntityByIdAsync(int id);
        T GetEntityById(int id);
        void Update(T entity);
        void UpdateFieldsSave(T entity, params Expression<Func<T, object>>[] includeProperties);
        void Delete(T entity);
        Task<T> Obtener<T>(Expression<Func<T, bool>> condicion) where T : class;
        Task<List<T>> ObtenerList<T>(Expression<Func<T, bool>> condicion) where T : class;
        Task Insert(T entity);
        void DeleteList(List<T> entity);
    }
}
