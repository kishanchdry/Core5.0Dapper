using Data.IRepository;
using Data.IRepository.IGeneric;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data.Repository.GenericRepository
{
    public class GenericDataRepository<T> : IGenericDataRepository<T>, IDisposable where T : BaseEntity
    {
        public GenericDataRepository()
        {
        }
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
    }

    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
