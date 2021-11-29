using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : ModelBase
    {
        private readonly CleanArchictetureContext _context;

        public BaseRepository(CleanArchictetureContext context)
        {
            _context = context;
        }

        public async Task<List<T>> ListAllActive()
        {
            return await _context.Set<T>()
                .Where(x => x.Status == EnumStatus.Active)
                .ToListAsync();
        }

        public async Task<T> Add(T model)
        {
            _context.Set<T>().Add(model);
            await _context.SaveChangesAsync();
            return model;
        }        

        public async Task<T> FindById(long id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }        

        public async Task<T> Update(T model)
        {
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task Delete(T model)
        {
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
