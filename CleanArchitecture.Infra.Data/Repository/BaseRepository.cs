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
    // implementa a interface generica
    public class BaseRepository<T> : IBaseRepository<T> where T : ModelBase
    {
        private readonly CleanArchictetureContext _context; 

        public BaseRepository(CleanArchictetureContext context)
        {
            _context = context; // _context uma representação do banco de dados
        }

        // retorna uma lista onde o status e ativo(T representa uma classe que é definida no repositorio próprio)
        // exemplo Lista<Produto>
        public async Task<List<T>> ListAllActive()
        {
            return await _context.Set<T>()
                .Where(x => x.Status == EnumStatus.Active)
                .ToListAsync(); // Converte o tipo para lista
        }

        public async Task<T> Add(T model)
        {
            _context.Set<T>().Add(model); // Adiciona o objeto
            await _context.SaveChangesAsync(); // Aqui é onde realmente ele faz o commit pro banco
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
