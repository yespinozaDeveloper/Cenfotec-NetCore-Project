using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Data.Models;

namespace WebAPI.Repositories
{
    public class CategoryRepository
    {
        public TMP_DEMOContext context { get; set; }

        public CategoryRepository(TMP_DEMOContext dbContext)
        {
            context = dbContext;
        }

        public List<CategoryEntity> Get()
        {
            var list = context.Category .Where(x => x.Active.Value)
                                        .Select(x => new CategoryEntity
                                          {
                                              Id = x.PkCategory,
                                              Name = x.Name
                                          }).ToList();
            return list;
        }

        public CategoryEntity Get(long id)
        {
            var category = context.Category.Where(x => x.PkCategory == id && x.Active.Value)
                                        .Select(x => new CategoryEntity
                                        {
                                            Id = x.PkCategory,
                                            Name = x.Name
                                        }).FirstOrDefault();
            return category;
        }

        public long Save(CategoryEntity data)
        {
            var query = context.Set<Category>().AsQueryable();
            var next = query.Max(p => p.PkCategory) + 1;

            var model = new Category
            {
                Name = data.Name,
                PkCategory = next,
            };

            context.Set<Category>().Add(model);

            context.SaveChanges();

            return model.PkCategory;
        }

        public bool Update(CategoryEntity data)
        {
            Category model = context.Category.Where(x => x.PkCategory == data.Id && x.Active.Value).FirstOrDefault();

            if (model == null)
                return false;

            model.Name = data.Name;
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }

        public bool Delete(long id)
        {
            Category model = context.Category.Where(x => x.PkCategory == id && x.Active.Value).FirstOrDefault();

            if (model == null)
                return false;

            model.Active = false;
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }
    }
}
