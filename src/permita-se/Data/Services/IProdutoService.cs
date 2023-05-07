using permita_se.Data.Base;
using permita_se.Data.ViewModel;
using permita_se.Model;
using System.Threading.Tasks;

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
