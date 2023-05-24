using permita_se.Data.Services;
using permita_se.Model;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace permita_se.Data.Services
{
    public interface IPedidosService
    {
        Task PedidoDaLojaAsync(List<CarrinhoItem> items, string userId, string userEmailAddress);
        Task<List<Pedido>> GetPedidosByUserIdAsync(string userId);
    }
}
