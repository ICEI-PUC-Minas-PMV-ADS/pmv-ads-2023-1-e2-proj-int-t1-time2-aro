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
        
        public async Task<IActionResult> AddItemAoCarrinhoDeCompra(int id)
        {
            var item = await _produtoService.GetProdutoByIdAsync(id);
            if (item != null) 
            {
                _carrinhoDeCompra.AddItemAoCarrinho(item);
            }
            return RedirectToAction(nameof(CarrinhoDeCompra));

        }

        public async Task<IActionResult> RemoveItemAoCarrinhoDeCompra(int id)
        {
            var item = await _produtoService.GetProdutoByIdAsync(id);
            if (item != null)
            {
                _carrinhoDeCompra.RemoverItemDoCarrinho(item);
            }
            return RedirectToAction(nameof(CarrinhoDeCompra));

        }
    }
}
