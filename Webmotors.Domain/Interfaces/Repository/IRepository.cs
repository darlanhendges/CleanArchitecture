using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Webmotors.Domain.Entities;

namespace Webmotors.Repository.Interfaces
{
    public interface IRepository<TObject> where TObject : Entity
    {
       Task<TObject> GetAsync(int id);
        Task<ICollection<TObject>> GetAllAsync();
        Task<TObject> FindAsync(Expression<Func<TObject, bool>> match);
        Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match);
        Task<TObject> AddAsync(TObject t);
        Task<TObject> UpdateAsync(TObject updated, int key);
        Task<int> DeleteAsync(TObject t);
        Task<int> CountAsync();

    }
}
