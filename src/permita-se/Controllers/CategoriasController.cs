using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using permita_se.Data.Services;
using permita_se.Data.Static;
using permita_se.Data.ViewModel;
using System.IO;
using System.Threading.Tasks;

namespace permita_se.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CategoriasController : Controller
    {
        private readonly ICategoriasService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoriasController(ICategoriasService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
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
        public async Task<IActionResult> Criar(CategoriaVM categoria)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCategoriaAsync(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Editar(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null)  return View("NotFound");

            var response = new CategoriaVM
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Descricao = categoria.Descricao,
                ImagemUrl = categoria.ImagemUrl
            };

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, CategoriaVM categoria)
        {
            if (id != categoria.Id) return View("NotFound");

            if (ModelState.IsValid)
            {
                await _service.EditarCategoriaAsync(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null) return View("NotFound");

            var response = new CategoriaVM
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Descricao = categoria.Descricao,
                ImagemUrl = categoria.ImagemUrl
            };

            return View(response);
        }

        [HttpPost, ActionName("Deletar")]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null) return View("NotFound");
            if (!string.IsNullOrEmpty(categoria.ImagemUrl))
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", categoria.ImagemUrl);
                System.IO.File.Delete(filePath);
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
