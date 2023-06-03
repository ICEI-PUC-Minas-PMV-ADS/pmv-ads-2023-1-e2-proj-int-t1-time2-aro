using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using permita_se.Data.Carrinho;
using permita_se.Data.Services;
using permita_se.Data.ViewModel;
using permita_se.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace permita_se.Controllers
{
    [Authorize]
    public class PedidosController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly CarrinhoDeCompra _carrinhoDeCompra;
        private readonly IPedidosService _pedidosService;
        private readonly UserManager<Usuario> _userManager;

        public PedidosController(IProdutoService produtoService, CarrinhoDeCompra carrinhoDeCompra, IPedidosService pedidosService, UserManager<Usuario> userManager)
        {
            _produtoService = produtoService;
            _carrinhoDeCompra = carrinhoDeCompra;
            _pedidosService = pedidosService;
            _userManager = userManager;
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

            var link = GetLinkRedirecionamento(IdUsuario, items);

            await _carrinhoDeCompra.LimparCarrinhoDeCompraAsync();

            ViewBag.HideCarrinho = true;
            return View(model: link);
        }

        private string GetLinkRedirecionamento(string IdUsuario, List<CarrinhoItem> items)
        {
            var user = _userManager.FindByIdAsync(IdUsuario).Result;

            string texto = "Olá! Gostaria de finalizar o meu pedido. Seguem os detalhes:" +
                "\n\nCliente: " + user.Nome + " " + user.Sobrenome +
                "\nTelefone de Contato: " + string.Format("{0:(##) #####-####}", user.Telefone) +
                "\n\nProdutos:";

            int i = 1;

            foreach (var item in items)
            {
                texto +=
                "\n" + i + ". " + item.Produto.Nome +
                "\nQuantidade: " + item.Quantidade +
                "\nValor: " + (item.Produto.Preco * item.Quantidade).ToString("c", CultureInfo.CreateSpecificCulture("pt-BR")) +
                "\n";
                i++;
            }

            texto += " \nTotal: " + _carrinhoDeCompra.GetCarrinhoTotal().ToString("c", CultureInfo.CreateSpecificCulture("pt-BR")) +
                "\n\nAguardo confirmação e informações sobre a disponibilidade do produto e o prazo de entrega." +
                "\nObrigado!";

            string textoCodificado = Uri.EscapeDataString(texto);
            string link = "https://wa.me/5531982493554?text=" + textoCodificado;

            return link;
        }
    }
}
