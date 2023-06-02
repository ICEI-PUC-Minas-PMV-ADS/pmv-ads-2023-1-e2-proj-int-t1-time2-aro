using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using permita_se.Data.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace permita_se.Controllers
{
    [Authorize]
    public class Favoritos : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IFavoritoService _favoritosService;

        public Favoritos(IProdutoService produtoService, IFavoritoService faviritosService)
        {
            _produtoService = produtoService;
            _favoritosService = faviritosService;
        }

        public async Task<IActionResult> Index()
        {
            string idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favoritos = await _favoritosService.GetFavoritosByUserIdAsync(idUsuario);

            return View(favoritos);
        }
        
        public async Task<IActionResult> AddFavorito(int id)
        {
            string idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var item = await _produtoService.GetProdutoByIdAsync(id);

            if (item != null) 
            {
                _favoritosService.AddFavorito(item, idUsuario);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoverFavorito(int id)
        {
            string idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var item = await _produtoService.GetProdutoByIdAsync(id);

            if (item != null)
            {
                _favoritosService.RemoverFavorito(item, idUsuario);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
