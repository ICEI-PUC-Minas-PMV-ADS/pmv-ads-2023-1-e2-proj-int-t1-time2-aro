﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IPedidosService _pedidosService;
        public PedidosController(IProdutoService produtoService, CarrinhoDeCompra carrinhoDeCompra, IPedidosService pedidosService)
        {
            _produtoService = produtoService;
            _carrinhoDeCompra = carrinhoDeCompra;
            _pedidosService = pedidosService;
        }

        public async Task<IActionResult> Index()
        {
            string IdUsuario = "";
            
            var pedidos = await _pedidosService.GetPedidosByUserIdAsync(IdUsuario);
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
        
        public async Task<IActionResult> AddItemAoCarrinho(int id)
        {
            var item = await _produtoService.GetProdutoByIdAsync(id);
            if (item != null) 
            {
                _carrinhoDeCompra.AddItemAoCarrinho(item);
            }
            return RedirectToAction(nameof(CarrinhoDeCompra));

        }

        public async Task<IActionResult> RemoveItemAoCarrinho(int id)
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
            string IdUsuario = "";

            await _pedidosService.CriarPedidoAsync(items, IdUsuario);
            await _carrinhoDeCompra.LimparCarrinhoDeCompraAsync();

            return View("PedidoCompleto");
        }
    }
}
