using Microsoft.EntityFrameworkCore;
using permita_se.Data.Base.Impl;
using permita_se.Data.ViewModel;
using permita_se.Model;
using permita_se.Models;
using System.Linq;
using System.Threading.Tasks;

namespace permita_se.Data.Services.Impl
{
    public class ProdutoService:EntityBaseRepository<Produto>, IProdutoService
    {
        private readonly PermitaSeDbContext _context;
        public ProdutoService(PermitaSeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProdutoAsync(NewProdutoVM data)
        {
            var newProduto = new Produto()
            {
                Nome = data.Nome,
                Descricao = data.Descricao,
                Preco = data.Preco,
                ImagemUrl = data.ImagemURL,
                IdCategoria = data.IdCategoria
            };
            await _context.Produtos.AddAsync(newProduto);
            await _context.SaveChangesAsync();
        }

        public async Task EditarProdutoAsync(NewProdutoVM data)
        {
            var dbProduto = await _context.Produtos.FirstOrDefaultAsync(n => n.Id == data.Id);
            
            if (dbProduto != null)
            {
                dbProduto.Nome = data.Nome;
                dbProduto.Descricao = data.Descricao;
                dbProduto.Preco = data.Preco;
                dbProduto.ImagemUrl = data.ImagemURL;
                dbProduto.IdCategoria = data.IdCategoria;               
                await _context.SaveChangesAsync();
            }

        }
        public async Task<NewProdutoDropdownVM> GetNewProdutoDropdownValues()
        {
            var response = new NewProdutoDropdownVM();
            response.Categorias = await _context.Categorias.OrderBy(n => n.Nome).ToListAsync();
            return response;
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            var produtoDetails = await _context.Produtos
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(n => n.Id == id);

            return produtoDetails;
        }

    }
}