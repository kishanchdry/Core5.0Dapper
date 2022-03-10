using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using Data.IFactory;
using Data.IRepository.IGeneric;

namespace Data.Repository.GenericRepository
{
    public class GenericDataRepository<T> : IGenericDataRepository<T>, IDisposable where T : class
    {
        //public GenericDataRepository()
        //{
        //}

        #region properties
        private readonly IDbConnectionFactory dBConnection;

        #endregion

        #region constructor 
        public GenericDataRepository(IDbConnectionFactory connectionFactory)
        {
            dBConnection = connectionFactory;
        }
        #endregion

        public bool Add(params T[] items)
        {
            throw new NotImplementedException();
        }

        public bool Remove(params T[] items)
        {
            throw new NotImplementedException();
        }

        public bool Remove(long id)
        {
            throw new NotImplementedException();
        }

        public bool ChangeStatus(long id)
        {
            throw new NotImplementedException();
        }

        public bool Update(params T[] items)
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public virtual T GetSingle(long id, params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public virtual T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;

            return item;
        }


        public void Dispose()
        {
            //IDisposable disposable = this as IDisposable;
            //if (disposable != null)
            //    disposable.Dispose();
        }

        public IList<T> GetAllWitnInActive()
        {
            throw new NotImplementedException();
        }

        #region Added By Sharad



        public void Insert(T obj)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            connection.Insert(obj);
        }
        public async Task InsertAsync(T obj)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            await connection.InsertAsync(obj);
        }
        public void InsertAll(ICollection<T> obj)
        {

            using IDbConnection connection = dBConnection.CreateDBConnection();
            connection.Insert(obj);
        }

        public async Task InsertAllAsync(ICollection<T> obj)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            await connection.InsertAsync(obj);
        }

        public T InsertWithReturnId(T obj)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            connection.Insert(obj);
            return obj;
        }

        public async Task<T> InsertWithReturnIdAsync(T obj)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            await connection.InsertAsync(obj);
            return obj;
        }
        public void Update(T obj)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            connection.Update(obj);
        }
        public async Task UpdateAsync(T obj)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            await connection.UpdateAsync(obj);
        }

        public void UpdateAll(List<T> entities)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            connection.Update(entities);
        }

        public async Task UpdateAllAsync(List<T> entities)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            await connection.UpdateAsync(entities);
        }

        public void RemoveAll(List<T> entities)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            connection.Delete(entities);
        }


        public void Delete(T entity)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            connection.Delete(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            await connection.DeleteAsync(entity);
        }

        public void DeleteById(object id)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            var entity = connection.Get<T>(id);
            connection.Delete(entity);

        }

        public async Task DeleteByIdAsync(object id)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            var entity = await connection.GetAsync<T>(id);
            await connection.DeleteAsync(entity);

        }
        public virtual void DeleteAll(List<T> entityCollection)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            connection.Delete(entityCollection);
        }

        public T GetById(object id)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            return connection.Get<T>(id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            return await connection.GetAsync<T>(id);
        }




        public bool ExecuteSqlCommand(string query, object param)
        {
            bool status;
            using IDbConnection connection = dBConnection.CreateDBConnection();
            connection.Execute(query, param, commandType: CommandType.Text);
            status = true;
            return status;
        }

        public async Task<bool> ExecuteSqlCommandAsync(string query, object param)
        {
            bool status;
            using IDbConnection connection = dBConnection.CreateDBConnection();
            await connection.ExecuteAsync(query, param, commandType: CommandType.Text);
            status = true;
            return status;
        }

        public T GetSignleRawSP(string name, object param)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            return connection.QueryFirstOrDefault<T>(name, param, commandType: CommandType.StoredProcedure);

        }

        public async Task<T> GetSignleRawSPAsync(string name, object param)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(name, param, commandType: CommandType.StoredProcedure);

        }


        public IEnumerable<T> GetMultipleRawSP(string name, object param)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            return connection.Query<T>(name, param, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<T>> GetMultipleRawSPAsync(string name, object param)
        {
            using IDbConnection connection = dBConnection.CreateDBConnection();
            return await connection.QueryAsync<T>(name, param, commandType: CommandType.StoredProcedure);

        }
        #endregion
    }

    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
