using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using permita_se.Data;
using System.Threading.Tasks;

namespace permita_se.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly PermitaSeDbContext _context;

        public CategoriasController(PermitaSeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allCategorias = await _context.Categorias.ToListAsync();
            return View(allCategorias);
        }
    }
}
