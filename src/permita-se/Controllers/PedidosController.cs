using Microsoft.AspNetCore.Mvc;
using permita_se.Data.Carrinho;
using permita_se.Data.Services;
using permita_se.Data.ViewModel;
using System.Threading.Tasks;

namespace permita_se.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly CarrinhoDeCompra _carrinhoDeCompra;
        public PedidosController(IProdutoService produtoService, CarrinhoDeCompra carrinhoDeCompra)
        {
            _produtoService = produtoService;
            _carrinhoDeCompra = carrinhoDeCompra;
        }

        public IActionResult CarrinhoDeCompra()
        {
            var items = _carrinhoDeCompra.GetCarrinhoItems();
            _carrinhoDeCompra.CarrinhoItems = items;

            var response = new CarrinhoVM()
            {
                CarrinhoDeCompra = _carrinhoDeCompra,
                CarrinhoTotal = _carrinhoDeCompra.GetCarrinhoTotal()
            };

            return View(response);
        }
        
        public async Task<RedirectToActionResult> AddAoCarrinhoDeCompra(int id)
        {
            var item = await _produtoService.GetProdutoByIdAsync(id);
            if (item != null) 
            {
                _carrinhoDeCompra.AddItemAoCarrinhoDeCompra(item);
            }
            return RedirectToAction(nameof(CarrinhoDeCompra));

        }
    }
}
