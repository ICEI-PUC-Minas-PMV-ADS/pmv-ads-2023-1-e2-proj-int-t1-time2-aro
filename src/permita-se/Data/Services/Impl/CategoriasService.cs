using Microsoft.EntityFrameworkCore;
using permita_se.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace permita_se.Data.Services.Impl
{
    public class CategoriasService : ICategoriasService
    {
        private readonly PermitaSeDbContext _context;
        public CategoriasService(PermitaSeDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _context.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> UpdateAsync(int id, Categoria newCategoria)
        {
            _context.Update(newCategoria);
            await _context.SaveChangesAsync();
            return newCategoria;
        }
    }
}
