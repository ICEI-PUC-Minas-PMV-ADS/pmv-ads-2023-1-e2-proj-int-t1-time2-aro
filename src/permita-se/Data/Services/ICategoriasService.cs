using permita_se.Data.Base;
using permita_se.Data.ViewModel;
using permita_se.Model;
using System.Threading.Tasks;

namespace permita_se.Data.Services
{
    public interface ICategoriasService:IEntityBaseRepository<Categoria>
    {
        Task AddCategoriaAsync(CategoriaVM data);
        Task EditarCategoriaAsync(CategoriaVM data);
    }
}
