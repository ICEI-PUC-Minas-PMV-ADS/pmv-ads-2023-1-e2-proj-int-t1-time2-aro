using Microsoft.AspNetCore.Mvc;
using permita_se.Data.Carrinho;


namespace permita_se.Data.ViewComponents
{
    public class ResumoCarrinhoDeCompra : ViewComponent
    {
        private readonly CarrinhoDeCompra _carrinhoDeCompra;

        public ResumoCarrinhoDeCompra(CarrinhoDeCompra carrinhoDeCompra)
        {
            _carrinhoDeCompra = carrinhoDeCompra;
        }

        public IViewComponentResult Invoke()
        {
            var item = _carrinhoDeCompra.GetCarrinhoItems();
            return View(model: item.Count);
        }

    }
}

