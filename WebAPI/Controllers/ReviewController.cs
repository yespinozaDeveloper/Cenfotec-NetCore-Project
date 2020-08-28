using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entity;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationSettings _settings;
        private readonly ProductRepository _repository;

        public ReviewController(ILogger<ProductController> logger,
                                  ApplicationSettings settings,
                                  ProductRepository repository)
        {
            _logger = logger;
            _settings = settings;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _repository.Get(id);

            if (result == null)
            {
                return NotFound(new { Message = "No se encuentra el elemento" });
            }
            return Ok(result);
        }

        [HttpGet("ByCategory/{id}")]
        public IActionResult GetByCategory(int id)
        {
            var result = _repository.GetByCategory(id);

            if (result == null)
            {
                return NotFound(new { Message = "No se encuentraron elementos" });
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(ProductEntity request)
        {
            long newProductId = _repository.Save(request);
            var data = _repository.Get(newProductId);
            return CreatedAtAction(nameof(GetById), new { Id = newProductId }, data);
        }

        [HttpPut]
        public IActionResult Put(ProductEntity request)
        {
            var flag = _repository.Update(request);
            if (flag)
            {
                return Ok(request);
            }
            else
                return NotFound(new { Message = "No se encuentra el elemento" });
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