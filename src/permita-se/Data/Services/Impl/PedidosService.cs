using Microsoft.EntityFrameworkCore;
using permita_se.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace permita_se.Data.Services.Impl
{
    public class PedidosService : IPedidosService

    {

        private readonly PermitaSeDbContext _context;
        public PedidosService(PermitaSeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> GetPedidosByUserIdAndRoleAsync(string IdUsuario, string userRole)
        {
            var pedidos = await _context.Pedidos.Include(n => n.PedidoItems).ThenInclude(n => n.Produto).Include(n => n.Usuario).ToListAsync();

            if(userRole != "Admin")
            {
                pedidos = pedidos.Where(n => n.IdUsuario == IdUsuario).ToList();
            }

            return pedidos;
        }

        public async Task CriarPedidoAsync(List<CarrinhoItem> items, string IdUsuario)
        {
            var pedido = new Pedido()
            {
                IdUsuario = IdUsuario,
                DataPedido = System.DateTime.Now
            };

            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var pedidoItem = new PedidoItem()
                {
                    Quantidade = item.Quantidade,
                    IdProduto = item.Produto.Id,
                    IdPedido = pedido.Id,
                    Preco = item.Produto.Preco,
                };
                await _context.PedidoItems.AddAsync(pedidoItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}