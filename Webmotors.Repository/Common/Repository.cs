using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Webmotors.Domain.Entities;
using Webmotors.Repository.Interfaces;

namespace Webmotors.Repository.Common
{
    public class Repository<TObject> : IRepository<TObject> where TObject : Entity
    {
        protected DbWebmotorsContext _context;

        public Repository(DbWebmotorsContext context)
        {
            _context = context;
        }
  
        public async Task<TObject> GetAsync(int id)
        {
            return await _context.Set<TObject>().FindAsync(id);
        }


        public async Task<ICollection<TObject>> GetAllAsync()
        {
            return await _context.Set<TObject>().ToListAsync();
        }

        public async Task<TObject> FindAsync(Expression<Func<TObject, bool>> match)
        {
            return await _context.Set<TObject>().SingleOrDefaultAsync(match);
        }

    
        public async Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match)
        {
            return await _context.Set<TObject>().Where(match).ToListAsync();
        }
      
        public async Task<TObject> AddAsync(TObject t)
        {
            _context.Set<TObject>().Add(t);
            await _context.SaveChangesAsync();
            return t;
        }
      
      
        public async Task<TObject> UpdateAsync(TObject updated, int key)
        {
            if (updated == null)
                return null;

            TObject existing = await _context.Set<TObject>().FindAsync(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                await _context.SaveChangesAsync();
            }
            return existing;
        }
      
        public async Task<int> DeleteAsync(TObject t)
        {
            _context.Set<TObject>().Remove(t);
            return await _context.SaveChangesAsync();
        }
     
        public async Task<int> CountAsync()
        {
            return await _context.Set<TObject>().CountAsync();
        }
    }
}
