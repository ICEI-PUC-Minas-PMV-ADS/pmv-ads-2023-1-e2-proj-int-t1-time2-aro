using Microsoft.EntityFrameworkCore;
using permita_se.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace permita_se.Data.Services.Impl
{
    public class FavoritoService : IFavoritoService
    {
        private readonly PermitaSeDbContext _context;

        public FavoritoService(PermitaSeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Favorito>> GetFavoritosByUserIdAsync(string IdUsuario)
        {
            var favoritos = await _context.Favoritos.Include(n => n.Produto).Include(n => n.Usuario).ToListAsync();

            return favoritos.Where(n => n.IdUsuario == IdUsuario).ToList();
        }

        public void AddFavorito(Produto produto, string IdUsuario)
        {
            var favorito = _context.Favoritos.FirstOrDefault(n => n.Produto.Id == produto.Id && n.IdUsuario == IdUsuario);

            if (favorito == null)
            {
                _context.Favoritos.Add(new Favorito()
                {
                    IdProduto = produto.Id,
                    IdUsuario = IdUsuario
                });
            }

            _context.SaveChanges();
        }

        public void RemoverFavorito(Produto produto, string IdUsuario)
        {
            var favorito = _context.Favoritos.FirstOrDefault(n => n.Produto.Id == produto.Id && n.IdUsuario == IdUsuario);

            if (favorito != null)
            {
                _context.Favoritos.Remove(favorito);
            }
            
            _context.SaveChanges();
        }
    }
}
