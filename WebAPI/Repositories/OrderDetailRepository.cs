using Models.Entity;
using Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Data.Models;

namespace WebAPI.Repositories
{
    public class OrderDetailRepository
    {
        public TMP_DEMOContext context { get; set; }

        public OrderDetailRepository(TMP_DEMOContext dbContext)
        {
            context = dbContext;
        }

        public OrderDetailEntity Get(long id)
        {
            var item = (from a in context.OrderDetail
                        where a.PkOrderDetail == id
                        join b in context.Order
                        on a.FkOrder  equals b.PkOrder 
                        join c in context.Product
                            on a.FkProduct equals c.PkProduct
                        join d in context.Category
                            on c.FkCategory equals d.PkCategory
                        select new OrderDetailEntity
                        {
                            Id = a.PkOrderDetail,
                            Order = a.FkOrder,
                            Product = new ProductEntity
                            {
                               Id = c.PkProduct,
                               Name = c.Name,
                               Price = c.Price,
                               Category = new CategoryEntity
                               {
                                   Id = d.PkCategory,
                                   Name = d.Name
                               }
                            }
                        }).FirstOrDefault();
            return item;
        }

        public List<OrderDetailEntity> GetByOrder(long id)
        {
            var item = (from a in context.Order
                        where a.Active.Value && a.PkOrder == id
                        join b in context.OrderDetail
                    on a.PkOrder equals b.FkOrder
                        join c in context.Product
                            on b.FkProduct equals c.PkProduct
                        join d in context.Category
                            on c.FkCategory equals d.PkCategory
                        select new OrderDetailEntity
                        {
                            Id = b.PkOrderDetail,
                            Order = b.FkOrder,
                            Product = new ProductEntity
                            {
                                Id = c.PkProduct,
                                Name = c.Name,
                                Price = c.Price,
                                Category = new CategoryEntity
                                {
                                    Id = d.PkCategory,
                                    Name = d.Name
                                }
                            }
                        }).ToList();
            return item;
        }

        public long Save (CreateOrderDetailParam param)
        {
            var query = context.Set<OrderDetail>().AsQueryable();

            var orderObj = context.Order.Where(x => x.Active.Value && x.PkOrder == param.Order).FirstOrDefault();
            if (orderObj == null)
                return -1;

            var model = new OrderDetail
            {
                FkOrder = param.Order,
                FkProduct = param.Product,
                };

            context.Set<OrderDetail>().Add(model);

            context.SaveChanges();

            return model.PkOrderDetail;
        }

        public bool Delete(long id)
        {
            Order model = context.Order.Where(x => x.PkOrder == id && x.Active.Value).FirstOrDefault();

            if (model == null)
                return false;

            model.Active = false;
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }
    }
}
