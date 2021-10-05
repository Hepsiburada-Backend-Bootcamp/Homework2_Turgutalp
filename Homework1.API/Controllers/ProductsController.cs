using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Homework1.API.DTO;
using Homework1.API.Filters;
using Homework1.Core.Entity;
using Homework1.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Homework1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriesController> _logger;

        public ProductsController(IProductService productService, IMapper mapper, ILogger<CategoriesController> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var products = await _productService.GetByIdAsync(id);
                return Ok(_mapper.Map<ProductDto>(products));
            }
            catch (Exception e)
            {
               _logger.LogWarning(e.Message);
                throw;
            }
        }
        
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            try
            {
                var product = await _productService.GetWithCategoryByIdAsync(id);
                return Ok(_mapper.Map<ProductWithCategoryDto>(product));
            }
            catch (Exception e)
            {
               _logger.LogWarning(e.Message);
                throw;
            }
        }

    
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            try
            {
                var newproduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));
                return Created(string.Empty, _mapper.Map<ProductDto>(newproduct));
            }
            catch (Exception e)
            {
               _logger.LogWarning(e.Message);
                throw;
            }
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            try
            {
                var product = _productService.Update(_mapper.Map<Product>(productDto));
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                var product = _productService.GetByIdAsync(id).Result;
                _productService.Remove(product);
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