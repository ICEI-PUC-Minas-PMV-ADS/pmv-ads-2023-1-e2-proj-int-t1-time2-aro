using System;
using Microsoft.EntityFrameworkCore;


namespace permita_se.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOption<AppDbContext> options) : base(options)
        {

        }
    }
}
