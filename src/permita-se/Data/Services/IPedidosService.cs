using permita_se.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace permita_se.Data.Services
{
    public interface IPedidosService
    {
        Task<List<Pedido>> GetPedidosByUserIdAsync(string IdUsuario);
        Task CriarPedidoAsync(List<CarrinhoItem> items, string IdUsuario);
    }
}
