using Models.Entity;
using Models.Request;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class OrderDetailRepository
    {
        private const string ORDERDETAIL_CONTROLLER = "OrderDetail";
        private const string ORDERDETAIL_BYCATEGORY_CONTROLLER = "OrderDetail/ByCategory/{0}";
        private const string ORDERDETAIL_FORMAT = "OrderDetail/{0}";

        public static async Task<List<OrderDetailEntity>> Get()
        {
            var orderDetailList = await NetworkHelper.getInstance().Get<List<OrderDetailEntity>>(ORDERDETAIL_CONTROLLER);
            return orderDetailList;
        }

        public static async Task<OrderDetailEntity> Get(string id)
        {
            return await NetworkHelper.getInstance().Get<OrderDetailEntity>(string.Format(ORDERDETAIL_FORMAT, id));
        }

        public static async Task<OrderDetailEntity> Create(CreateOrderDetailParam param)
        {
            string jsonParam = JsonConvert.SerializeObject(param);
            return await NetworkHelper.getInstance().Post<OrderDetailEntity>(jsonParam, ORDERDETAIL_CONTROLLER);
        }

        public static async Task<OrderDetailEntity> Update(OrderDetailEntity param)
        {
            string jsonParam = JsonConvert.SerializeObject(param);
            return await NetworkHelper.getInstance().Put<OrderDetailEntity>(jsonParam, ORDERDETAIL_CONTROLLER);
        }

        public static async Task<bool> Delete(string param)
        {
            return await NetworkHelper.getInstance().Delete<bool>(string.Format(ORDERDETAIL_FORMAT, param));
        }
    }
}
