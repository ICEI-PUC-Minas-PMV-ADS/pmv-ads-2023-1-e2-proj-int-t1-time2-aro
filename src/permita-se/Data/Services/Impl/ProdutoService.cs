using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using permita_se.Data.Base.Impl;
using permita_se.Data.ViewModel;
using permita_se.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace permita_se.Data.Services.Impl
{
    public class ProdutoService:EntityBaseRepository<Produto>, IProdutoService
    {
        private readonly PermitaSeDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProdutoService(PermitaSeDbContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<Pedido>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Pedidos.Include(n => n.PedidoItems).ThenInclude(n => n.Produto).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.IdUsuario == userId).ToList();
            }

            return orders;
        }

        public async Task AddNewProdutoAsync(NewProdutoVM data)
        {
            var newProduto = new Produto()
            {   
                Nome = data.Nome,
                Descricao = data.Descricao,
                Preco = data.Preco.Value,
                IdCategoria = data.IdCategoria,
                ProdutoStatus = data.ProdutoStatus
            };

            if(data.ImagemUpload != null)
            {
                newProduto.ImagemUrl = UploadArquivo(data.ImagemUpload);
            }

            await _context.Produtos.AddAsync(newProduto);
            await _context.SaveChangesAsync();
        }

        public async Task EditarProdutoAsync(NewProdutoVM data)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(n => n.Id == data.Id);
            
            if (produto != null)
            {
                produto.Nome = data.Nome;
                produto.Descricao = data.Descricao;
                produto.Preco = data.Preco.Value;
                produto.IdCategoria = data.IdCategoria;
                produto.ProdutoStatus = data.ProdutoStatus;

                if(data.ImagemUpload != null)
                {
                    if (!string.IsNullOrEmpty(produto.ImagemUrl))
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", produto.ImagemUrl);
                        File.Delete(filePath);
                    }
                    produto.ImagemUrl = UploadArquivo(data.ImagemUpload);
                }

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

        private string UploadArquivo(IFormFile arquivo)
        {
            string nomeArquivo = Guid.NewGuid().ToString() + "-" + arquivo.FileName;
            string pathArquivo = Path.Combine(_webHostEnvironment.WebRootPath, "img", nomeArquivo);
            using (var fileStream = new FileStream(pathArquivo, FileMode.Create))
            {
                arquivo.CopyTo(fileStream);
            }

            return nomeArquivo;
        }

    }
}