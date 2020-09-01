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

        public List<ProductEntity> GetByCategory(long id)
        {
            var productList = context.Product.Where(x => x.Active.Value).Join(context.Category.Where(z => z.Active.Value && z.PkCategory == id),
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
            return productList;
        }

        public List<ProductEntity> GetByOrder(long id)
        {
            var productList = (from a in context.Order
                       where a.Active.Value && a.PkOrder == id
                       join b in context.OrderDetail
                       on a.PkOrder equals b.FkOrder
                       join c in context.Product
                       on b.FkProduct equals c.PkProduct
                       join d in context.Category
                       on c.FkCategory equals d.PkCategory
                       select new ProductEntity
                       {
                           Id = c.PkProduct,
                           Name = c.Name,
                           Price = c.Price,
                           Category = new CategoryEntity
                           {
                               Id = d.PkCategory,
                               Name = d.Name
                           }
                       }).ToList();
            return productList;
        }

        public long Save(ProductEntity param)
        {
            var query = context.Set<Product>().AsQueryable();

            var categoryObj = context.Category.Where(x => x.Active.Value && x.PkCategory == param.Category.Id).FirstOrDefault();
            if (categoryObj == null)
                return -1;


            var model = new Product
            {
                Name = param.Name,
                Price = param.Price,
                Active = true,
                FkCategory = param.Category.Id,
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
