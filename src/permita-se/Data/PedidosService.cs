using permita_se.Data.Services;
using permita_se.Model;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace permita_se.Data
{
    public class PedidosService : IPedidosService
    {

        private readonly PermitaSeDbContext _context;
        public PedidosService(PermitaSeDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pedido>> GetPedidosByUserIdAsync(string userId)
        {
            var pedidos = await _context.Pedidos.Include(n => n.PedidoItems).ThenInclude(n => n.Produtos).Where(n => n.UserId)
                == userId).ToListAsync();
            return pedidos;
        }

        public async Task PedidoDaLojaAsync(List<CarrinhoItem> items, string userId, string userEmailAddress)
        {
            var pedido = new Pedido();
            {
                UserId = userId;
                Email = userEmailAddress;
            };
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var pedidoItem = new PedidoItem()
                {
                    Quantidade = item.Quantidade,
                    IdProduto = item.Produto.Id,
                    IdPedido = item.Id,
                    Preco = item.Preco,
                };
                await _context.PedidoItems.AddAsync(pedidoItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
