using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using permita_se.Data;
using permita_se.Data.Services;
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
    }
}
