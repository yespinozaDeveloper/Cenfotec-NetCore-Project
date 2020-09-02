using Models.Entity;
using Models.Request;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class OrderRepository
    {
        private const string PRODUCT_CONTROLLER = "Order";
        private const string PRODUCT_BYCATEGORY_CONTROLLER = "Order/ByCategory/{0}";
        private const string PRODUCT_FORMAT = "Order/{0}";

        public static async Task<List<OrderEntity>> Get()
        {
            var orderList = await NetworkHelper.getInstance().Get<List<OrderEntity>>(PRODUCT_CONTROLLER);
            return orderList;
        }

        public static async Task<OrderEntity> Get(string id)
        {
            return await NetworkHelper.getInstance().Get<OrderEntity>(string.Format(PRODUCT_FORMAT, id));
        }

        public static async Task<OrderEntity> Create(string user)
        {
            string jsonParam = JsonConvert.SerializeObject(new CreateOrderParam { User = user});
            return await NetworkHelper.getInstance().Post<OrderEntity>(jsonParam, PRODUCT_CONTROLLER);
        }

        public static async Task<OrderEntity> Update(OrderEntity param)
        {
            string jsonParam = JsonConvert.SerializeObject(param);
            return await NetworkHelper.getInstance().Put<OrderEntity>(jsonParam, PRODUCT_CONTROLLER);
        }

        public static async Task<bool> Delete(string param)
        {
            return await NetworkHelper.getInstance().Delete<bool>(string.Format(PRODUCT_FORMAT, param));
        }
    }
}
