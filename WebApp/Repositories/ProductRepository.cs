using Models.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class ProductRepository
    {
        private const string PRODUCT_CONTROLLER = "Product";
        private const string PRODUCT_BYCATEGORY_CONTROLLER = "Product/ByCategory/{0}";
        private const string PRODUCT_FORMAT = "Product/{0}";

        public static async Task<List<ProductEntity>> Get()
        {
            var productList = await NetworkHelper.getInstance().Get<List<ProductEntity>>(PRODUCT_CONTROLLER);
            ApplicationCacheData.getInstance().Products = productList;
            return productList;
        }

        public static async Task<ProductEntity> Get(string id)
        {
            return await NetworkHelper.getInstance().Get<ProductEntity>(string.Format(PRODUCT_FORMAT, id));
        }

        public static async Task<List<ProductEntity>> GetByCategory(string id)
        {
            return await NetworkHelper.getInstance().Get<List<ProductEntity>>(string.Format(PRODUCT_BYCATEGORY_CONTROLLER, id));
        }

        public static async Task<ProductEntity> Create(ProductEntity param)
        {
            string jsonParam = JsonConvert.SerializeObject(param);
            return await NetworkHelper.getInstance().Post<ProductEntity>(jsonParam, PRODUCT_CONTROLLER);
        }

        public static async Task<ProductEntity> Update(ProductEntity param)
        {
            string jsonParam = JsonConvert.SerializeObject(param);
            return await NetworkHelper.getInstance().Put<ProductEntity>(jsonParam, PRODUCT_CONTROLLER);
        }

        public static async Task<bool> Delete(string param)
        {
            return await NetworkHelper.getInstance().Delete<bool>(string.Format(PRODUCT_FORMAT, param));
        }
    }
}
