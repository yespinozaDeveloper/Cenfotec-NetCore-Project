using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ApplicationCacheData
    {
        private static ApplicationCacheData instance { get; set; }
        public UserEntity CurrentUser { get; set; }
        public List<CategoryEntity> Categories { get; set; }
        public List<ProductEntity> Products { get; set; }

        public static ApplicationCacheData getInstance()
        {
            if (instance == null)
                instance = new ApplicationCacheData();
            return instance;
        }

        public ApplicationCacheData()
        {
            this.CurrentUser = null;
            this.Categories = new List<CategoryEntity>();
            this.Products = new List<ProductEntity>();
        }
    }
}
