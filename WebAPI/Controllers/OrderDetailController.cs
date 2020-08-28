using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entity;
using Models.Request;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly ILogger<OrderDetailController> _logger;
        private readonly ApplicationSettings _settings;
        private readonly OrderDetailRepository _repository;

        public OrderDetailController(ILogger<OrderDetailController> logger,
                                  ApplicationSettings settings,
                                  OrderDetailRepository repository)
        {
            _logger = logger;
            _settings = settings;
            _repository = repository;
        }


        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _repository.Get(id);

            if (result == null)
            {
                return NotFound(new { Message = "No se encuentra el elemento" });
            }
            return Ok(result);
        }


        [HttpGet("GetByOrder/{id}")]
        public IActionResult GetByOrder(int id)
        {
            var result = _repository.GetByOrder(id);

            if (result == null || result.Count == 0)
            {
                return NotFound(new { Message = "No se encontraron elementos" });
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(OrderAddProductRequest param)
        {
            long newProductId = _repository.Save(param);
            var data = _repository.Get(newProductId);
            return CreatedAtAction(nameof(GetById), new { Id = newProductId }, data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var flag = _repository.Delete(id);
            if (flag)
            {
                return Ok();
            }
            else
                return NotFound(new { Message = "No se encuentra el elemento" });
        }
    }
}
