using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entity;
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
    public class CategoryController : Controller
    {
        public static CategoryViewModel viewModel;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
             if(viewModel == null)
                viewModel = new CategoryViewModel();
        }

        public async System.Threading.Tasks.Task<IActionResult> Categories()
        {
            try
            {
                _logger.LogInformation("Getting Category List...");
                viewModel.CategoryList = await CategoryRepository.Get();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return View(getViewModel());
        }

        public IActionResult Category(int id)
        {
            var list = getViewModel().CategoryList.Where(x => x.Id == id).ToList();
            var viewModel = new CategoryViewModel()
            {
                CategoryList = list
            };
            return View(viewModel);
        }

        public async System.Threading.Tasks.Task<IActionResult> CategoryMaintenance()
        {
            try
            {
                _logger.LogInformation("Getting Category List...");
                viewModel.CategoryList = await CategoryRepository.Get();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return View("CategoryMaintenance", getViewModel());
        }

        [HttpGet("DeleteCategory")]
        public async System.Threading.Tasks.Task<IActionResult> DeleteCategory([FromQuery]string accountKey)
        {
            try
            {
                _logger.LogInformation("Deleting Category...");
                bool result = await CategoryRepository.Delete(accountKey);
                _logger.LogInformation($"Response: {result}!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return await this.CategoryMaintenance();
        }

        [HttpGet("EditCategory")]
        public async System.Threading.Tasks.Task<IActionResult> EditCategory([FromQuery]string accountKey)
        {
            try
            {
                var item = await CategoryRepository.Get(accountKey);
                if (item != null)
                {
                    return await Save(new SaveCategoryViewModel()
                    {
                        Category = item,
                        isLoading = true
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return await CategoryMaintenance();
        }

        public async System.Threading.Tasks.Task<IActionResult> Save(SaveCategoryViewModel viewModel)
        {
            if(viewModel == null)
                viewModel = new SaveCategoryViewModel();
            try
            {
                if (!viewModel.isLoading && viewModel.Category != null && !string.IsNullOrEmpty(viewModel.Category.Name))
                {
                    if (viewModel.Category.Id == -1)
                    {
                        _logger.LogInformation("Adding Category...");
                        await CategoryRepository.Create(viewModel.Category);
                    }
                    else
                    {
                        _logger.LogInformation("Editing Category...");
                        await CategoryRepository.Update(viewModel.Category);
                    }
                    return await CategoryMaintenance();
                }
                else if(viewModel.Category == null)
                    viewModel.Category = new CategoryEntity();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                viewModel.Message = ex.Message;
            }
            return View("SaveCategory", viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static CategoryViewModel getViewModel()
        {
            return viewModel;
        }
    }
}
