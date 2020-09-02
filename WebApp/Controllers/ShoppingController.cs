using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entity;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApp.Models;
using WebApp.Repositories;
using Models.Request;

namespace WebApp.Controllers
{
    public class ShoppingController : Controller
    {
        public static List<ProductEntity> ShoppingCarList;
        private readonly ILogger<ShoppingController> _logger;

        public ShoppingController(ILogger<ShoppingController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShoppingCar()
        {
            if (ShoppingCarList == null)
                ShoppingCarList = new List<ProductEntity>();

            return View("ShoppingCar", new ShoppingCarViewModel() { ProductList = ShoppingCarList});
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> AddProduct([FromQuery]string accountKey)
        {
            try
            {
                var product = await ProductRepository.Get(accountKey);
                if (ShoppingCarList == null)
                    ShoppingCarList = new List<ProductEntity>();
                ShoppingCarList.Add(product);
            }
            catch (System.Exception)
            {
            }
            return ShoppingCar();
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> DeleteProduct([FromQuery] string accountKey)
        {
            try
            {
                if (ShoppingCarList != null && ShoppingCarList.Count > 0)
                    ShoppingCarList.Remove(ShoppingCarList.Where(x => x.Id == int.Parse(accountKey)).FirstOrDefault());
            }
            catch (System.Exception)
            {
            }
            return ShoppingCar();
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> ConfirmOrder([FromQuery] string accountKey)
        {
            try
            {
                if (ShoppingCarList != null && ShoppingCarList.Count > 0)
                    ShoppingCarList.Remove(ShoppingCarList.Where(x => x.Id == int.Parse(accountKey)).FirstOrDefault());
            }
            catch (System.Exception)
            {
            }
            return ShoppingCar();
        }

        public async System.Threading.Tasks.Task<IActionResult> Save(ShoppingCarViewModel viewModel)
        {
            try
            {
                if (viewModel != null)
                {
                    if (string.IsNullOrEmpty(viewModel.User) || string.IsNullOrEmpty(viewModel.Password))
                    {
                        viewModel.Message = "Enter required values";
                        return View("ShoppingCar", viewModel);
                    }
                    else
                    {
                        var userEntity = await UserRepository.Login(viewModel.User, viewModel.Password);
                        if(userEntity == null)
                        {
                            viewModel.Message = "User and/or password incorrect.";
                            return View("ShoppingCar", viewModel);
                        }
                        else
                        {
                            var orderEntity = await OrderRepository.Create(userEntity.Id.ToString());
                            foreach(var item in ShoppingCarList)
                            {
                                await OrderDetailRepository.Create(new CreateOrderDetailParam()
                                {
                                    Order = orderEntity.Id,
                                    Product = item.Id
                                });
                            }
                            orderEntity.Status = "COMPLETED";
                            orderEntity = await OrderRepository.Update(orderEntity);
                            ShoppingCarList.Clear();
                            return ShoppingCar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                viewModel.Message = ex.Message;
            }
            return View("ShoppingCar", viewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
