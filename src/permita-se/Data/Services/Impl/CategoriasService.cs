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

        public void Add(Categoria categoria)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public Categoria GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Categoria Update(int id, Categoria newCategoria)
        {
            throw new System.NotImplementedException();
        }
    }
}
