using Microsoft.AspNetCore.Mvc;
using permita_se.Data.Carrinho;
using permita_se.Data.Services;
using permita_se.Data.ViewModel;

namespace permita_se.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly Carrinho _carrinho;
        public PedidosController(IProdutoService produtoService, Carrinho carrinho)
        {
            _produtoService = produtoService;
            _carrinho = carrinho;
        }

        public IActionResult Index()
        {
            var items = _carrinho.GetCarrinhoItems();
            _carrinho.CarrinhoItems = items

            var response = new CarrinhoVM()
            {
                Carrinho = _carrinho,
                CarrinhoTotal = _carrinho.GetCarrinhoTotal(),
            };

            return View(response);
        }
    }
}
