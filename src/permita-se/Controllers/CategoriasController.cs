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
            var allCategorias = await _service.GetAll();
            return View(allCategorias);
        }

        public IActionResult Criar()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _service.Add(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }
    }
}
