using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAppV1.Server.Data.AppService.CategoryAppService;
using ProductAppV1.Shared.Dto.CategoryDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAppV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet("GetAllCategories")]
        
        public IActionResult GetAllCategories()
        {
            var data = _categoryAppService.GetAllCategories();
            return Ok(data);
        }


        
        [HttpGet("GetCategoryById/{id}")]
       
        public IActionResult GetSingleCategory(int id)
        {
            var data = _categoryAppService.GetCategoryById(id);
            return Ok(data);
        }

       
        [HttpPost("AddNewCategory")]
        [Authorize(Roles = "administrator")]
        public IActionResult Post([FromBody] CreateCategoryDto category)
        {
            var response = _categoryAppService.AddNewCategory(category);
            return Ok(response);
        }

        
        [HttpPut("UpdateCategory/{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult Put(int id,UpdateCategoryDto category)
        {
            var response = _categoryAppService.UpdateCategory(id,category);
            return Ok(response);
        }

        
        [HttpDelete("DeleteCategory/{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult Delete(int id)
        {
            var response = _categoryAppService.DeleteCategory(id);
            return Ok(response);
        }
    }
}
