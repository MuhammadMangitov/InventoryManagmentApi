using InventoryManagement.Domain.DTOs.Category;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagement.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        // GET: api/<CategoriesController>
        public CategoriesController(ICategoryService service) 
        {
            _categoryService = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var result = _categoryService.GetCategories();

            return Ok(result);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> Get(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound($"Category with id: {id} does not exist.");
            }
            return category;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public ActionResult<Category> Post([FromBody] CategoryForCreateDto category)
        {
            var result = _categoryService.Create(category);
            return Created("GetById", result);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CategoryForUpdateDto category)
        {
            if(id != category.Id)
            {
                return BadRequest($"Route id: {id} does not match with category id: {category.Id}");
            }
            _categoryService.Update(category);
            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }
    }
}
