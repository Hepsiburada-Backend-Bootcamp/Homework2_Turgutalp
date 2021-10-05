using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Homework1.API.DTO;
using Homework1.API.LogServices;
using Homework1.Core.Entity;
using Homework1.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Homework1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriesController> _logger;
        
        

        public CategoriesController(ICategoryService categoryService, IMapper mapper,ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            try
            {
                var categories = await _categoryService.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
            }
            catch (Exception e)
            {
               _logger.LogWarning(e.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                return Ok(_mapper.Map<CategoryDto>(category));
            }
            catch (Exception e)
            {
               _logger.LogWarning(e.Message);
                throw;
            }
        }
        
        //parent-child
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            try
            {
                var category = await _categoryService.GetWithProductsByIdAsync(id);
                return Ok(_mapper.Map<CategoryWithProductDto>(category));
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            try
            {
                var newCategory = await _categoryService.AddAsync(
                    _mapper.Map<Category>(categoryDto));

                return Created(string.Empty, _mapper.Map<CategoryDto>(newCategory));
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
        }


        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            try
            {
                var category = _categoryService.Update(_mapper.Map<Category>(categoryDto));
                return NoContent(); // 204
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                var category = _categoryService.GetByIdAsync(id).Result;
                _categoryService.Remove(category);

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
        }

       
    }
}