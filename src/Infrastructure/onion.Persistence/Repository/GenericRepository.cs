using Microsoft.EntityFrameworkCore;
using onion.Application.Interfaces.Repository;
using onion.Domain.Common;
using onion.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       
        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;

        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();

        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<T>().FirstAsync(x => x.Id == id);
        }
    }
}
