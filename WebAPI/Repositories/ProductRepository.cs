using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Data.Models;

namespace WebAPI.Repositories
{
    public class ProductRepository
    {
        public TMP_DEMOContext context { get; set; }

        public ProductRepository(TMP_DEMOContext dbContext)
        {
            context = dbContext;
        }

        public List<ProductEntity> Get()
        {
            var list = context.Product.Where(x => x.Active.Value).Join(context.Category.Where(z => z.Active.Value),
                      x => x.FkCategory,
                      y => y.PkCategory,
                      (product, category) => new ProductEntity
                      {
                          Id = product.PkProduct,
                          Name = product.Name,
                          Price = product.Price,
                          Category = new CategoryEntity
                          {
                              Id = category.PkCategory,
                              Name = category.Name
                          }
                      }).ToList();
            return list;
        }

        public ProductEntity Get(long id)
        {
            var product = context.Product.Where(x => x.PkProduct == id && x.Active.Value).Join(context.Category.Where(z => z.Active.Value),
                      x => x.FkCategory,
                      y => y.PkCategory,
                      (product, category) => new ProductEntity
                      {
                          Id = product.PkProduct,
                          Name = product.Name,
                          Price = product.Price,
                          Category = new CategoryEntity
                          {
                              Id = category.PkCategory,
                              Name = category.Name
                          }
                      }).FirstOrDefault();
            return product;
        }

        public long Save(ProductEntity data)
        {
            var query = context.Set<Product>().AsQueryable();
            var next = query.Max(p => p.PkProduct) + 1;

            var model = new Product
            {
                Name = data.Name,
                Price = data.Price,
                Active = true,
                FkCategory = data.Category.Id,
                PkProduct = next,
            };

            context.Set<Product>().Add(model);

            context.SaveChanges();

            return model.PkProduct;
        }

        public bool Update(ProductEntity data)
        {
            Product model = context.Product.Where(x => x.PkProduct == data.Id && x.Active.Value).FirstOrDefault();

            if (model == null)
                return false;

            model.Price = data.Price;
            model.Name = data.Name;
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }

        public bool Delete(long id)
        {
            Product model = context.Product.Where(x => x.PkProduct == id && x.Active.Value).FirstOrDefault();

            if (model == null)
                return false;

            model.Active = false;
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }
    }
}
