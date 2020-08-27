using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("SignIn")]
        public IActionResult SignIn(string user, string password)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("user", user);
            dictionary.Add("password", password);
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
            else if (user != "jey21@live.com" || password != "12345678")
            {
                dictionary.Add("ERROR", "User and/or password incorrect");
                return View("Login",dictionary);
            }
            else
                return Redirect("Product/ProductMaintenance"); ;
        }
    }
}
