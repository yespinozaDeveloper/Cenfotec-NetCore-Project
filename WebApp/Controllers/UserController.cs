using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entity;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationSettings _settings;

        public UserController(ILogger<UserController> logger, ApplicationSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("SignIn")]
        public async System.Threading.Tasks.Task<IActionResult> SignIn(string user, string password)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("user", user);
            dictionary.Add("password", password);
            try
            {
                if (string.IsNullOrEmpty(user))
                {
                    dictionary.Add("ERROR", "User is required");
                    return View("Login", dictionary);
                }
                else if (string.IsNullOrEmpty(password))
                {
                    dictionary.Add("ERROR", "Password is required");
                    return View("Login", dictionary);
                }
                else
                {
                    var userEntity = UserRepository.Login(user, password);
                    if (userEntity == null)
                    {
                        dictionary.Add("ERROR", "User and/or password incorrect");
                        return View("Login", dictionary);
                    }
                    else
                    {
                        return Redirect("Product/ProductMaintenance"); ;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,ex.StackTrace);
                dictionary.Add("ERROR", "User and/or password incorrect");
                return View("Login", dictionary);
            }
        }

        public async System.Threading.Tasks.Task<IActionResult> Logout()
        {
            ApplicationCacheData.getInstance().CurrentUser = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
