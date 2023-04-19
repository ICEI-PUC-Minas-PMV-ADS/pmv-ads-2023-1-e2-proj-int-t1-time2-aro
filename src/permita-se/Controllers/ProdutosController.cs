using Microsoft.AspNetCore.Mvc;
using permita_se.Data;
using System.Linq;

namespace permita_se.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly PermitaSeDbContext _context;

        public ProdutosController(PermitaSeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Produtos.ToList();
            return View();
        }
    }
}
