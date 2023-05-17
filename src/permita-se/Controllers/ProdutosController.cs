using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using permita_se.Data.Services;
using permita_se.Data.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace permita_se.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProdutos = await _service.GetAllAsync(n => n.Categoria);
            return View(allProdutos);
        }

        public async Task<IActionResult> Filtro(string searchString)
        {
            var allProdutos = await _service.GetAllAsync(n => n.Categoria);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProdutos.Where(n => n.Nome.ToLower().Contains(searchString.ToLower()) || 
                                                            n.Descricao.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allProdutos);
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var produtoDetail = await _service.GetProdutoByIdAsync(id);
            return View(produtoDetail);
        }

        public async Task<IActionResult> Criar()
        {
            var produtoDropdownData = await _service.GetNewProdutoDropdownValues();
            ViewBag.IdCategoria = new SelectList(produtoDropdownData.Categorias, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(NewProdutoVM produto)
        {

            if (!ModelState.IsValid)
            {
                var produtoDropdownData = await _service.GetNewProdutoDropdownValues();
                ViewBag.IdCategoria = new SelectList(produtoDropdownData.Categorias, "Id", "Nome");

                return View(produto);
            }

            await _service.AddNewProdutoAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var produtoDetail = await _service.GetProdutoByIdAsync(id);
            if (produtoDetail == null) return View("NotFound");

            var response = new NewProdutoVM()
            {
                Id = produtoDetail.Id,
                Nome = produtoDetail.Nome,
                Descricao = produtoDetail.Descricao,
                Preco = produtoDetail.Preco,
                ImagemURL = produtoDetail.ImagemUrl,
                IdCategoria = produtoDetail.IdCategoria,
            };

            var produtoDropdownData = await _service.GetNewProdutoDropdownValues();

            ViewBag.IdCategoria = new SelectList(produtoDropdownData.Categorias, "Id", "Nome");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, NewProdutoVM produto)
        {
            if (id != produto.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var produtoDropdownData = await _service.GetNewProdutoDropdownValues();
                ViewBag.IdCategoria = new SelectList(produtoDropdownData.Categorias, "Id", "Nome");

                return View(produto);
            }

            await _service.EditarProdutoAsync(produto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Deletar(int id)
        {
            var produto = await _service.GetByIdAsync(id);

            return produto == null ? View("NotFound") : View(produto);
        }

        [HttpPost, ActionName("Deletar")]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            var produto = await _service.GetByIdAsync(id);
            if (produto == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
