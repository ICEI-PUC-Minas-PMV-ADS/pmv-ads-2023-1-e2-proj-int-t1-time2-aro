﻿using Microsoft.EntityFrameworkCore;
using permita_se.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace permita_se.Data.Carrinho
{
    public class CarrinhoDeCompra
    {
        public PermitaSeDbContext _context { get; set; }
        
        public int IdCarrinho { get; set; }

        public List<CarrinhoItem> CarrinhoItems { get; set; }

        public CarrinhoDeCompra(PermitaSeDbContext context)

        { _context = context; }

        public static CarrinhoDeCompra GetCarrinhoDeCompra(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<PermitaSeDbContext>();

            string IdCarrinho = session.GetString("IdCarrinho") ?? Guid.NewGuid().ToString().ToString();    
            session.SetString("IdCarrinho", IdCarrinho);

            return new CarrinhoDeCompra(context) { IdCarrinho = IdCarrinho };
        }

        public void AddItemaoCarrinho(Produto produto)
        {
            var CarrinhoItem = _context.CarrinhoItems.FirstOrDefault(n => n.Produto.Id == produto.Id && n.IdCarrinho == IdCarrinho);

            if (CarrinhoItem == null)
            {
                CarrinhoItem = new CarrinhoItem()
                {
                    IdCarrinho = IdCarrinho,
                    Produto = produto,
                    Quantidade = 1
                };

                _context.CarrinhoItems.Add(CarrinhoItem);
            }
            else
            {
                CarrinhoItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public void RemoverItemdoCarrinho(Produto produto)
        {
            var CarrinhoItem = _context.CarrinhoItems.FirstOrDefault(n => n.Produto.Id == produto.Id && n.IdCarrinho == IdCarrinho);

            if (CarrinhoItem != null)
            {
                if (CarrinhoItem.Quantidade > 1)
                {
                    CarrinhoItem.Quantidade--;
                }
                else
                {
                    _context.CarrinhoItems.Remove(CarrinhoItem);

                }

            }
            _context.SaveChanges();
        }

        public List<CarrinhoItem> GetCarrinhoItems()
        {
            return CarrinhoItems ?? (CarrinhoItems = _context.CarrinhoItems.Where(n => n.IdCarrinho ==
            IdCarrinho).Include(n => n.Produto).ToList());
        }

        public double GetCarrinhoTotal()
        {
            return ((double)_context.CarrinhoItems.Where(n => n.IdCarrinho == IdCarrinho).Select(selector: n => n.Produto.Preco * n.Quantidade).Sum());
        }
    }
}