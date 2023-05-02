using permita_se.Model;
using System.Collections.Generic;

namespace permita_se.Data.ViewModel
{
    public class NewProdutoDropdownVM
    {
        public NewProdutoDropdownVM()
        {
            Categorias   = new List<Categoria>();
        }
        public List<Categoria> Categorias{ get; set; }
    }
}
