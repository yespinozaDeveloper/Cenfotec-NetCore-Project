using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly ILogger<ShoppingController> _logger;

        public ShoppingController(ILogger<ShoppingController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShoppingCar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
