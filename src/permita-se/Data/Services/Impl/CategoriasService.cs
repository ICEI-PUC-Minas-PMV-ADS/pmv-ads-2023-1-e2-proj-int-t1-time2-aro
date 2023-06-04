using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using permita_se.Data.Base.Impl;
using permita_se.Data.ViewModel;
using permita_se.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace permita_se.Data.Services.Impl
{
    public class CategoriasService : EntityBaseRepository<Categoria>, ICategoriasService
    {

        private readonly PermitaSeDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoriasService(PermitaSeDbContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddCategoriaAsync(CategoriaVM data)
        {
            var categoria = new Categoria()
            {
                Nome = data.Nome,
                Descricao = data.Descricao,
            };

            if (data.ImagemUpload != null)
            {
                categoria.ImagemUrl = UploadArquivo(data.ImagemUpload);
            }

            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task EditarCategoriaAsync(CategoriaVM data)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (categoria != null)
            {
                categoria.Nome = data.Nome;
                categoria.Descricao = data.Descricao;

                if (data.ImagemUpload != null)
                {
                    if (!string.IsNullOrEmpty(categoria.ImagemUrl))
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", categoria.ImagemUrl);
                        File.Delete(filePath);
                    }
                    categoria.ImagemUrl = UploadArquivo(data.ImagemUpload);
                }

                await _context.SaveChangesAsync();
            }
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
