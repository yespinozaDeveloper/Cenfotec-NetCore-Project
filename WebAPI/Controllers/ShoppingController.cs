using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly ILogger<ShoppingController> _logger;

        public ShoppingController(ILogger<ShoppingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
