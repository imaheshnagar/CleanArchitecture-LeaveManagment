using LeaveManagement.Application.Contracts.Persistance;
using LeaveManagement.Domain.Common;
using LeaveManagement.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistance.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        protected readonly LmDatabaseContext _context;
        public GenericRepository(LmDatabaseContext lmDatabaseContext)
        {
            this._context = lmDatabaseContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

         public async Task<T> GetByIdAsync(int Id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q=> q.Id == Id);
        }

        public async Task UpdateAsync(T entity)
        {
           // _context.Update(entity); OR
            _context.Entry(entity).State = EntityState.Modified;
           await _context.SaveChangesAsync();
        }
    }
}
