﻿using Membership_.Areas.Admin.Models;
using Membership_.Entities;
using Membership_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Membership_.Areas.Admin.Extensions
{
    public static class ConversionExtensions
    {
        public static async Task<IEnumerable<ProductModel>> Convert(this IEnumerable<Product> products,ApplicationDbContext db )
        {
            if(products.Count().Equals(0))
                return new List<ProductModel>();
            var types = await db.ProductTypes.ToListAsync();
            var texts = await db.ProductLinkTexts.ToListAsync();

            return from p in products
                   select new ProductModel
                   {
                       Id = p.Id,
                       Title = p.Title,
                       Description = p.Description,
                       ImageUrl = p.ImageUrl,
                       ProductLinkTextId = p.ProductLinkTextId,
                       ProductTypeId = p.ProductTypeId,
                       ProductLinkTexts = texts,
                       ProductTypes = types
                   };
        }

        public static async Task<ProductModel> Convert(this Product product, ApplicationDbContext db)
        {
           
            var type = await db.ProductTypes.FirstOrDefaultAsync(p=>p.Id==product.ProductTypeId);
            var text = await db.ProductLinkTexts.FirstOrDefaultAsync(p => p.Id == product.ProductLinkTextId);

           var model=new ProductModel
                   {
                       Id = product.Id,
                       Title = product.Title,
                       Description = product.Description,
                       ImageUrl = product.ImageUrl,
                       ProductLinkTextId = product.ProductLinkTextId,
                       ProductTypeId = product.ProductTypeId,
                       ProductLinkTexts = new List<ProductLinkText>(),
                       ProductTypes = new List<ProductType>(),
           };
            model.ProductLinkTexts.Add(text);
            model.ProductTypes.Add(type);

            return model;
        }
    }
}