using permita_se.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace permita_se.Data.Services
{
    public interface IFavoritoService
    {
        Task<List<Favorito>> GetFavoritosByUserIdAsync(string IdUsuario);
        void AddFavorito(Produto produto, string IdUsuario);
        void RemoverFavorito(Produto produto, string IdUsuario);
    }
}
