using Shared.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.IRepository.IGeneric
{
    public interface IGenericDataRepository<T> : IDisposable where T : class
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(long id, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        bool Add(params T[] items);
        bool Update(params T[] items);
        bool Remove(params T[] items);
        bool Remove(long Id);
        bool ChangeStatus(long id);
        IList<T> GetAllWitnInActive();

        #region Added By Sharad
        void Insert(T obj);
        Task InsertAsync(T obj);
        void InsertAll(ICollection<T> obj);
        Task InsertAllAsync(ICollection<T> obj);
        T InsertWithReturnId(T obj);
        Task<T> InsertWithReturnIdAsync(T obj);
        void Update(T obj);
        Task UpdateAsync(T obj);
        void UpdateAll(List<T> entities);
        Task UpdateAllAsync(List<T> entities);
        void RemoveAll(List<T> entities);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        void DeleteById(object id);
        Task DeleteByIdAsync(object id);
        void DeleteAll(List<T> entityCollection);
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        bool ExecuteSqlCommand(string query, object param);
        Task<bool> ExecuteSqlCommandAsync(string query, object param);

        #endregion
    }
}
