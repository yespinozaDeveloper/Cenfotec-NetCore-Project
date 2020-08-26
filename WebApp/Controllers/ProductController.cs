using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entity;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        public static ProductViewModel viewModel;
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationSettings _settings;

        public ProductController(ILogger<ProductController> logger, ApplicationSettings settings)
        {
            _logger = logger;
            _settings = settings;
             if(viewModel == null)
                viewModel = new ProductViewModel();
        }

        public async System.Threading.Tasks.Task<IActionResult> ProductsAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var webApi = _settings.ServerUrl;
                    _logger.LogInformation("Web Api: {0}", webApi);
                    client.BaseAddress = new Uri(webApi);
                    var resultProduct = await client.GetStringAsync("Product");
                    _logger.LogInformation("Response Products: {0}", resultProduct);
                    var list = JsonSerializer.Deserialize<List<ProductEntity>>(resultProduct);
                    viewModel.ProductList = list;

                    var resultCategories = await client.GetStringAsync("Category");
                    _logger.LogInformation("Response Categories: {0}", resultProduct);
                    var categoryList = JsonSerializer.Deserialize<List<CategoryEntity>>(resultCategories);
                    viewModel.CategoryList = categoryList;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return View(getViewModel());
        }

        public IActionResult Product(int id)
        {
            var productList = getViewModel().ProductList.Where(x => x.Id == id).ToList();
            var viewModel = new ProductViewModel()
            {
                ProductList = productList
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static ProductViewModel getViewModel()
        {
            return viewModel;
        }
    }
}
