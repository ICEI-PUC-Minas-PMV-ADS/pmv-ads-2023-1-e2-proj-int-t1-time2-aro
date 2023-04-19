using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using permita_se.Data;
using System.Threading.Tasks;

namespace permita_se.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly PermitaSeDbContext _context;

        public ProdutosController(PermitaSeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allProdutos = await _context.Produtos.Include(p => p.Categoria).ToListAsync();
             return View(allProdutos);
        }
    }
}
