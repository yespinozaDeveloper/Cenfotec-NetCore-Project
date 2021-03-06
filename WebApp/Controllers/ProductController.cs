﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entity;
using Models.Request;
using Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        public static ProductsViewModel viewModel;
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationSettings _settings;

        public ProductController(ILogger<ProductController> logger, ApplicationSettings settings)
        {
            _logger = logger;
            _settings = settings;
             if(viewModel == null)
                viewModel = new ProductsViewModel();
        }

        public async System.Threading.Tasks.Task<IActionResult> Products()
        {
            try
            {
                _logger.LogInformation("Getting Product List...");
                viewModel.ProductList = await ProductRepository.Get();
                _logger.LogInformation("Getting Category List...");
                viewModel.setCategoryList(await CategoryRepository.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return View(getViewModel());
        }

        public async System.Threading.Tasks.Task<IActionResult> ProductsByCategory(ProductsViewModel viewModel)
        {
            try
            {
                _logger.LogInformation("Getting Product List...");
                if (viewModel != null && !string.IsNullOrEmpty(viewModel.SelectedCategoryId) && viewModel.SelectedCategoryId != "-1")
                    viewModel.ProductList = await ProductRepository.GetByCategory(viewModel.SelectedCategoryId);
                else
                    viewModel.ProductList = await ProductRepository.Get();
                _logger.LogInformation("Getting Category List...");
                viewModel.setCategoryList(await CategoryRepository.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return View("Products",viewModel);
        }

        public async System.Threading.Tasks.Task<IActionResult> Product(long id)
        {
            var product = await ProductRepository.Get(id.ToString());
            var viewModel = new ProductViewModel(product);
            var reviews = await ReviewRepository.GetByProduct(id.ToString());
            viewModel.Reviews = reviews;
            return View("Product", viewModel);
        }

        public async System.Threading.Tasks.Task<IActionResult> Comment(ProductViewModel param)
        {
            var user = await UserRepository.Login(param.User, param.Password);
            if (user == null)
            {

            }
            else
            {
                var request = new MaintenanceProductReviewParam
                {
                    Product = param.Product.Id,
                    User = user.Id,
                    Detail = param.Comment
                };
                await ReviewRepository.Create(request);
                return await Product(param.Product.Id);
            }
            return View("Product", param);
        }

        public async System.Threading.Tasks.Task<IActionResult> ProductMaintenance()
        {
            try
            {
                _logger.LogInformation("Getting Product List...");
                viewModel.ProductList = await ProductRepository.Get();
                _logger.LogInformation("Getting Category List...");
                viewModel.setCategoryList(await CategoryRepository.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return View("ProductMaintenance", getViewModel());
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> Delete([FromQuery]string accountKey)
        {
            try
            {
                _logger.LogInformation("Deleting Product...");
                bool result = await ProductRepository.Delete(accountKey);
                _logger.LogInformation($"Response: {result}!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return await this.ProductMaintenance();
        }

        [HttpGet("Edit")]
        public async System.Threading.Tasks.Task<IActionResult> Edit([FromQuery]string accountKey)
        {
            try
            {
                var product = await ProductRepository.Get(accountKey);
                if (product != null)
                {
                    return await Save(new SaveProductViewModel()
                    {
                        Product = product,
                        isLoading = true
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return await ProductMaintenance();
        }

        public async System.Threading.Tasks.Task<IActionResult> Save(SaveProductViewModel viewModel)
        {
            if(viewModel == null)
                viewModel = new SaveProductViewModel(ApplicationCacheData.getInstance().Categories);
            if(viewModel.CategoryList == null || viewModel.CategoryList.Count() == 0)
                viewModel.setCategoryList(ApplicationCacheData.getInstance().Categories);
            try
            {
                if (!viewModel.isLoading && viewModel.Product != null)
                {
                    viewModel.Product.Category.Id = long.Parse(viewModel.SelectedCategoryId);
                    if (viewModel.Product.Id == -1)
                    {
                        _logger.LogInformation("Adding Product...");
                        await ProductRepository.Create(viewModel.Product);
                    }
                    else
                    {
                        _logger.LogInformation("Editing Product...");
                        await ProductRepository.Update(viewModel.Product);
                    }
                    return await ProductMaintenance();
                }
                else if(viewModel.Product == null)
                    viewModel.Product = new ProductEntity();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                viewModel.Message = ex.Message;
            }
            return View("SaveProduct", viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static ProductsViewModel getViewModel()
        {
            return viewModel;
        }
    }
}
