using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using permita_se.Data.Services;
using System.Threading.Tasks;

namespace permita_se.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoriasService _categoriasService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICategoriasService categoriasService, ILogger<HomeController> logger)
        {
            _categoriasService = categoriasService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriasService.GetAllAsync();
            return View(categorias);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
