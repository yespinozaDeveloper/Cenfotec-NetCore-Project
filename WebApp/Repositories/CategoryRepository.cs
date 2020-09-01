using Models.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class CategoryRepository
    {
        private const string CATEGORY_CONTROLLER = "Category";
        private const string CATEGORY_FORMAT = "Category/{0}";

        public static async Task<List<CategoryEntity>> Get()
        {
            var categoryList = await NetworkHelper.getInstance().Get<List<CategoryEntity>>(CATEGORY_CONTROLLER);
            ApplicationCacheData.getInstance().Categories = categoryList;
            return categoryList;
        }

        public static async Task<CategoryEntity> Get(string id)
        {
            return await NetworkHelper.getInstance().Get<CategoryEntity>(string.Format(CATEGORY_FORMAT, id));
        }

        public static async Task<CategoryEntity> Create(CategoryEntity param)
        {
            string jsonParam = JsonConvert.SerializeObject(param);
            return await NetworkHelper.getInstance().Post<CategoryEntity>(jsonParam, CATEGORY_CONTROLLER);
        }

        public static async Task<CategoryEntity> Update(CategoryEntity param)
        {
            string jsonParam = JsonConvert.SerializeObject(param);
            return await NetworkHelper.getInstance().Put<CategoryEntity>(jsonParam, CATEGORY_CONTROLLER);
        }

        public static async Task<bool> Delete(string param)
        {
            return await NetworkHelper.getInstance().Delete<bool>(string.Format(CATEGORY_FORMAT, param));
        }
    }
}

