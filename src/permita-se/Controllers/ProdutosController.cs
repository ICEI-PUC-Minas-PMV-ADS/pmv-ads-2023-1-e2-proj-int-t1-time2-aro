using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using permita_se.Data.Services;
using permita_se.Data.Static;
using permita_se.Data.ViewModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace permita_se.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IFavoritoService _favoritoService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProdutosController(IProdutoService produtoService, IFavoritoService favoritoService, IWebHostEnvironment webHostEnvironment)
        {
            _produtoService = produtoService;
            _favoritoService = favoritoService;
            _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favoritos = await _favoritoService.GetFavoritosByUserIdAsync(idUsuario);

            var produtos = await _produtoService.GetAllAsync(n => n.Categoria);

            foreach (var fav in favoritos)
            {
                produtos.FirstOrDefault(n => n.Id == fav.IdProduto).IsFavorito = true;
            }

            return View(produtos);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filtro(string pesquisa)
        {
            var produtos = await _produtoService.GetAllAsync(n => n.Categoria);

            if (!string.IsNullOrEmpty(pesquisa))
            {
                var filtro = produtos.Where(n => n.Nome.ToLower().Contains(pesquisa.ToLower()) ||
                                                            n.Descricao.ToLower().Contains(pesquisa.ToLower())).ToList();
                return View("Index", filtro);
            }

            return View("Index", produtos);
        }

        [AllowAnonymous]
        public async Task<IActionResult> FiltroCategoria(int id)
        {
            var produtos = await _produtoService.GetAllAsync(n => n.Categoria);

            var filtro = produtos.Where(n => n.Categoria.Id == id).ToList();

            return View("Index", filtro);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detalhes(int id)
        {
            var produtoDetail = await _produtoService.GetProdutoByIdAsync(id);
            return View(produtoDetail);
        }

        public async Task<IActionResult> Criar()
        {
            var produtoDropdownData = await _produtoService.GetNewProdutoDropdownValues();
            ViewBag.IdCategoria = new SelectList(produtoDropdownData.Categorias, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(NewProdutoVM produto)
        {
            if (!ModelState.IsValid)
            {
                var produtoDropdownData = await _produtoService.GetNewProdutoDropdownValues();
                ViewBag.IdCategoria = new SelectList(produtoDropdownData.Categorias, "Id", "Nome");

                return View(produto);
            }

            await _produtoService.AddNewProdutoAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var produtoDetail = await _produtoService.GetProdutoByIdAsync(id);
            if (produtoDetail == null) return View("NotFound");

            var response = new NewProdutoVM()
            {
                Id = produtoDetail.Id,
                Nome = produtoDetail.Nome,
                Descricao = produtoDetail.Descricao,
                Preco = produtoDetail.Preco.ToString(CultureInfo.CreateSpecificCulture("pt-BR")),
                ImagemURL = produtoDetail.ImagemUrl,
                IdCategoria = produtoDetail.IdCategoria,
                ProdutoStatus = produtoDetail.ProdutoStatus,
            };

            var produtoDropdownData = await _produtoService.GetNewProdutoDropdownValues();

            ViewBag.IdCategoria = new SelectList(produtoDropdownData.Categorias, "Id", "Nome");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, NewProdutoVM produto)
        {
            if (id != produto.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var produtoDropdownData = await _produtoService.GetNewProdutoDropdownValues();
                ViewBag.IdCategoria = new SelectList(produtoDropdownData.Categorias, "Id", "Nome");

                return View(produto);
            }

            await _produtoService.EditarProdutoAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var produtoDetail = await _produtoService.GetProdutoByIdAsync(id);
            if (produtoDetail == null) return View("NotFound");

            var response = new NewProdutoVM()
            {
                Id = produtoDetail.Id,
                Nome = produtoDetail.Nome,
                Descricao = produtoDetail.Descricao,
                Preco = produtoDetail.Preco.ToString("c", CultureInfo.CreateSpecificCulture("pt-BR")),
                ImagemURL = produtoDetail.ImagemUrl,
                IdCategoria = produtoDetail.IdCategoria,
                ProdutoStatus = produtoDetail.ProdutoStatus,
            };

            var produtoDropdownData = await _produtoService.GetNewProdutoDropdownValues();

            ViewBag.IdCategoria = new SelectList(produtoDropdownData.Categorias, "Id", "Nome");

            return View(response);
        }

        [HttpPost, ActionName("Deletar")]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);

            if (produto == null) return View("NotFound");
            if (!string.IsNullOrEmpty(produto.ImagemUrl))
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", produto.ImagemUrl);
                System.IO.File.Delete(filePath);
            }

            await _produtoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}