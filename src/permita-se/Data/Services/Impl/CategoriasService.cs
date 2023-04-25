using Microsoft.EntityFrameworkCore;
using permita_se.Data.Base.Impl;
using permita_se.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace permita_se.Data.Services.Impl
{
    public class CategoriasService : EntityBaseRepository<Categoria>, ICategoriasService
    {
        public CategoriasService(PermitaSeDbContext context) : base(context)
        {
        }
    }
}
