using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using permita_se.Data.Carrinho;
using permita_se.Data.Services;
using permita_se.Data.ViewModel;
using permita_se.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace permita_se.Controllers
{
    [Authorize]
    public class PedidosController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly CarrinhoDeCompra _carrinhoDeCompra;
        private readonly IPedidosService _pedidosService;

        public PedidosController(IProdutoService produtoService, CarrinhoDeCompra carrinhoDeCompra, IPedidosService pedidosService)
        {
            _produtoService = produtoService;
            _carrinhoDeCompra = carrinhoDeCompra;
            _pedidosService = pedidosService;
        }

        public async Task<IActionResult> Index()
        {
            string idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var pedidos = await _pedidosService.GetPedidosByUserIdAndRoleAsync(idUsuario, userRole);
            return View(pedidos);
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
        
        public async Task<IActionResult> AdicionarItem(int id)
        {
            var item = await _produtoService.GetProdutoByIdAsync(id);
            if (item != null)
            {
                _carrinhoDeCompra.AddItemAoCarrinho(item);
            }

            return RedirectToAction(nameof(CarrinhoDeCompra));
        }

        public async Task<IActionResult> RemoverItem(int id)
        {
            var item = await _produtoService.GetProdutoByIdAsync(id);
            if (item != null)
            {
                _carrinhoDeCompra.RemoverItemDoCarrinho(item);
            }
            return RedirectToAction(nameof(CarrinhoDeCompra));

        }

        public async Task<IActionResult> FinalizarPedido()
        {
            var items = _carrinhoDeCompra.GetCarrinhoItems();
            string IdUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _pedidosService.CriarPedidoAsync(items, IdUsuario);

            string texto = "Olá! Vim do site e desejo receber atendimento. \nPedido:";       

            foreach (var item in items)
            {
                    texto += 
                    " \nNome do Produto: " + item.Produto.Nome +
                    " \nQuantidade: " + item.Quantidade +
                    " \nValor: " + item.Produto.Preco;
            }

            texto += " \nTotal Da Compra: " + _carrinhoDeCompra.GetCarrinhoTotal();
            await _carrinhoDeCompra.LimparCarrinhoDeCompraAsync();

            ViewBag.HideCarrinho = true;

            string textoCodificado = Uri.EscapeDataString(texto);
            string link = "https://wa.me/5531982493554?text=" + textoCodificado;

            return View();
        }
    }
}
