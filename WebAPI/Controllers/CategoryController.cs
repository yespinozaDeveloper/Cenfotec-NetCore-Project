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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ApplicationSettings _settings;
        private readonly CategoryRepository _repository;

        public CategoryController(ILogger<CategoryController> logger,
                                  ApplicationSettings settings,
                                  CategoryRepository repository)
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
        [HttpPost]
        public IActionResult Create(CategoryEntity request)
        {
            long newCategoryId = _repository.Save(request);
            var data = _repository.Get(newCategoryId);
            return CreatedAtAction(nameof(GetById), new { Id = newCategoryId }, data);
        }

        [HttpPut]
        public IActionResult Put(CategoryEntity request)
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
