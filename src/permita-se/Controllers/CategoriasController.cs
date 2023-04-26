using Microsoft.AspNetCore.Mvc;
using permita_se.Data.Services;
using permita_se.Model;
using System.Threading.Tasks;

namespace permita_se.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriasService _service;

        public CategoriasController(ICategoriasService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCategorias = await _service.GetAllAsync();
            return View(allCategorias);
        }

        public IActionResult Criar()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar([Bind("Nome,Descricao")]Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var categoria = await _service.GetByIdAsync(id);

            return categoria == null ? View("NotFound") : View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var categoria = await _service.GetByIdAsync(id);

            return categoria == null ? View("NotFound") : View(categoria);
        }

        [HttpPost, ActionName("Deletar")]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
