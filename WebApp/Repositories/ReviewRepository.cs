using Models.Entity;
using Models.Request;
using Models.ViewModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class ReviewRepository
    {
        private const string REVIEW_CONTROLLER = "Review";
        private const string REVIEW_BYREVIEW_CONTROLLER = "Review/ByProduct/{0}";
        private const string REVIEW_FORMAT = "Review/{0}";

        public static async Task<List<ReviewEntity>> Get()
        {
            var productList = await NetworkHelper.getInstance().Get<List<ReviewEntity>>(REVIEW_CONTROLLER);
            return productList;
        }

        public static async Task<ReviewEntity> Get(string id)
        {
            return await NetworkHelper.getInstance().Get<ReviewEntity>(string.Format(REVIEW_FORMAT, id));
        }

        public static async Task<List<ReviewEntity>> GetByProduct(string id)
        {
            return await NetworkHelper.getInstance().Get<List<ReviewEntity>>(string.Format(REVIEW_BYREVIEW_CONTROLLER, id));
        }

        public static async Task<ReviewEntity> Create(MaintenanceProductReviewParam param)
        {
            string jsonParam = JsonConvert.SerializeObject(param);
            return await NetworkHelper.getInstance().Post<ReviewEntity>(jsonParam, REVIEW_CONTROLLER);
        }

        public static async Task<ReviewEntity> Update(ReviewEntity param)
        {
            string jsonParam = JsonConvert.SerializeObject(param);
            return await NetworkHelper.getInstance().Put<ReviewEntity>(jsonParam, REVIEW_CONTROLLER);
        }

        public static async Task<bool> Delete(string param)
        {
            return await NetworkHelper.getInstance().Delete<bool>(string.Format(REVIEW_FORMAT, param));
        }
    }
}
