using Models.Entity;
using Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Data.Models;

namespace WebAPI.Repositories
{
    public class OrderRepository
    {
        public TMP_DEMOContext context { get; set; }

        public OrderRepository(TMP_DEMOContext dbContext)
        {
            context = dbContext;
        }

        public List<OrderEntity> Get()
        {
            var list = (from a in context.Order
                        where a.Active.Value
                        join c in context.User
                        on a.FkUser equals c.PkUser
                        join d in context.Status
                        on a.FkStatus equals d.PkStatus
                        select new OrderEntity
                        {
                            Id = a.PkOrder,
                            Date = a.Date,
                            User = c.PersonalIdentification,
                            Status = d.Name,
                            Products = (from x in context.OrderDetail
                                        where x.FkOrder == a.PkOrder
                                        join y in context.Product
                                         on x.FkProduct equals y.PkProduct
                                        join z in context.Category
                                         on y.FkCategory equals z.PkCategory
                                        select new ProductEntity()
                                        {
                                            Id = y.PkProduct,
                                            Name = y.Name,
                                            Price = y.Price,
                                            Category = new CategoryEntity()
                                            {
                                                Id = z.PkCategory,
                                                Name = z.Name
                                            }
                                        }).ToList()
                        }).ToList();
            return list;
        }

        public OrderEntity Get(long id)
        {
            var item = (from a in context.Order
                        where a.Active.Value && a.PkOrder == id
                        join c in context.User
                        on a.FkUser equals c.PkUser
                        join d in context.Status
                        on a.FkStatus equals d.PkStatus
                        select new OrderEntity
                        {
                            Id = a.PkOrder,
                            Date = a.Date,
                            User = c.PersonalIdentification,
                            Status = d.Name,
                            Products = (from x in context.OrderDetail
                                        where x.FkOrder == a.PkOrder
                                        join y in context.Product
                                         on x.FkProduct equals y.PkProduct
                                        join z in context.Category
                                         on y.FkCategory equals z.PkCategory
                                        select new ProductEntity()
                                        {
                                            Id = y.PkProduct,
                                            Name = y.Name,
                                            Price = y.Price,
                                            Category = new CategoryEntity()
                                            {
                                                Id = z.PkCategory,
                                                Name = z.Name
                                            }
                                        }).ToList()
                        }).FirstOrDefault();
            return item;
        }

        public long Save(string user)
        {
            var query = context.Set<Order>().AsQueryable();

            var userObj = context.User.Where(x => x.Active.Value && x.PkUser.ToString() == user).FirstOrDefault();
            if (userObj == null)
                return -1;
            var model = new Order
            {
                Date = DateTime.Now,
                FkStatus = 1,
                Active = true,
                FkUser = userObj.PkUser,
            };

            context.Set<Order>().Add(model);

            context.SaveChanges();

            return model.PkOrder;
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

        public bool Update(OrderEntity data)
        {
            Order model = context.Order.Where(x => x.PkOrder == data.Id && x.Active.Value).FirstOrDefault();

            if (model == null)
                return false;

            model.FkStatus = context.Status.Where(x => x.Name == data.Status).FirstOrDefault().PkStatus;
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }
    }
}
