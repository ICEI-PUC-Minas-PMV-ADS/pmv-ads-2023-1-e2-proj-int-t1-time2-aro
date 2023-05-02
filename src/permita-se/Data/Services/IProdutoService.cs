using permita_se.Model;
using permita_se.Data.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using permita_se.Data.ViewModel;
using permita_se.Models;

namespace permita_se.Data.Services
{
    public interface IProdutoService:IEntityBaseRepository<Produto>
    {
        Task<Produto> GetProdutoByIdAsync(int id);
        Task<NewProdutoDropdownVM> GetNewProdutoDropdownValues();
        Task AddNewProdutoAsync(NewProdutoVM data);
        Task EditarProdutoAsync(NewProdutoVM data);
    }
}
