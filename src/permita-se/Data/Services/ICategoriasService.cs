using permita_se.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace permita_se.Data.Services
{
    public interface ICategoriasService
    {
        Task<IEnumerable<Categoria>> GetAll();
        Categoria GetById(int id);
        void Add(Categoria categoria);
        Categoria Update(int id, Categoria newCategoria);
        void Delete(int id);
    }
}
