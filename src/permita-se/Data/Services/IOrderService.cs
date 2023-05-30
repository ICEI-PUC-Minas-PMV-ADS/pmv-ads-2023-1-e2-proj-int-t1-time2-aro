using permita_se.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace permita_se.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<PedidoItem> items, string userId, string userEmailAddress);
        Task<List<Pedido>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}