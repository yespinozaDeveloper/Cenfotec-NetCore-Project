using Models.Entity;
using Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Data.Models;

namespace WebAPI.Repositories
{
    public class ReviewRepository
    {
        public TMP_DEMOContext context { get; set; }

        public ReviewRepository(TMP_DEMOContext dbContext)
        {
            context = dbContext;
        }

        public List<ReviewEntity> Get()
        {
            var list = (from a in context.ProductReview
                        where a.Active.Value 
                        join b in context.Product
                        on a.FkProduct equals b.PkProduct
                        join c in context.User
                            on a.FkUser equals c.PkUser
                        join d in context.Category
                            on b.FkCategory equals d.PkCategory
                        select new ReviewEntity
                        {
                            Id = a.PkProductReview,
                            Detail = a.Detail,
                            Product = new ProductEntity
                            {
                                Id = b.PkProduct,
                                Name = b.Name,
                                Price = b.Price,
                                Category = new CategoryEntity
                                {
                                    Id = d.PkCategory,
                                    Name = d.Name
                                }
                            },
                            User = new UserEntity
                            {
                                Id = c.PkUser,
                                Name = c.Name,
                                PersonalIdentification = c.PersonalIdentification,
                                Address = c.Address,
                                Email = c.Email
                            }
                        }).ToList();
            return list;
        }

        public ReviewEntity Get(long id)
        {
            var item = (from a in context.ProductReview
                        where a.Active.Value && a.PkProductReview == id
                        join b in context.Product
                        on a.FkProduct equals b.PkProduct
                        join c in context.User
                            on a.FkUser equals c.PkUser
                        join d in context.Category
                            on b.FkCategory equals d.PkCategory
                        select new ReviewEntity
                        {
                            Id = a.PkProductReview,
                            Detail = a.Detail,
                            Product = new ProductEntity
                            {
                                Id = b.PkProduct,
                                Name = b.Name,
                                Price = b.Price,
                                Category = new CategoryEntity
                                {
                                    Id = d.PkCategory,
                                    Name = d.Name
                                }
                            },
                            User = new UserEntity
                            {
                                Id = c.PkUser,
                                Name = c.Name,
                                PersonalIdentification = c.PersonalIdentification,
                                Address = c.Address,
                                Email = c.Email
                            }
                        }).FirstOrDefault();
            return item;
        }

        public List<ReviewEntity> GetByProduct(long id)
        {
            var list = (from a in context.ProductReview
                        where a.Active.Value && a.FkProduct == id
                        join b in context.Product
                        on a.FkProduct equals b.PkProduct
                        join c in context.User
                            on a.FkUser equals c.PkUser
                        join d in context.Category
                            on b.FkCategory equals d.PkCategory
                        select new ReviewEntity
                        {
                            Id = a.PkProductReview,
                            Detail = a.Detail,
                            Product = new ProductEntity
                            {
                                Id = b.PkProduct,
                                Name = b.Name,
                                Price = b.Price,
                                Category = new CategoryEntity
                                {
                                    Id = d.PkCategory,
                                    Name = d.Name
                                }
                            },
                            User = new UserEntity
                            {
                                Id = c.PkUser,
                                Name = c.Name,
                                PersonalIdentification = c.PersonalIdentification,
                                Address = c.Address,
                                Email = c.Email
                            }
                        }).ToList();
            return list;
        }

        public long Save(MaintenanceProductReviewParam data)
        {
            var query = context.Set<ProductReview>().AsQueryable();

            var productObj = context.Product.Where(x => x.Active.Value && (x.PkProduct == data.Product)).FirstOrDefault();
            if (productObj == null)
                return -1;

            var userObj = context.User.Where(x => x.Active.Value && (x.PkUser == data.User)).FirstOrDefault();
            if (userObj == null)
                return -1;

            var model = new ProductReview
            {
                Detail = data.Detail,
                FkProduct = data.Product,
                FkUser = data.User,
                Active = true,
            };

            context.Set<ProductReview>().Add(model);

            context.SaveChanges();

            return model.PkProductReview;
        }

        public bool Update(MaintenanceProductReviewParam data)
        {
            ProductReview model = context.ProductReview.Where(x => x.PkProductReview == data.Id && x.Active.Value).FirstOrDefault();

            if (model == null)
                return false;

            model.FkProduct = data.Product;
            model.Detail = data.Detail;
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }

        public bool Delete(long id)
        {
            ProductReview model = context.ProductReview.Where(x => x.PkProductReview == id && x.Active.Value).FirstOrDefault();

            if (model == null)
                return false;

            model.Active = false;
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }
    }
}
