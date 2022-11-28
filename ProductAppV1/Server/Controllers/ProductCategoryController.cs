using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAppV1.Server.Data.AppService.ProductCategoryAppService;
using ProductAppV1.Shared.Dto.ProductCategoryDto;

namespace ProductAppV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryAppService _productCategoryAppService;
        public ProductCategoryController(IProductCategoryAppService productCategoryAppService)
        {
            _productCategoryAppService = productCategoryAppService;
        }
        [HttpGet("GetAllProductCategories")]

        public IActionResult GetAllCategories()
        {
            var data = _productCategoryAppService.GetAllProductCategories();
            return Ok(data);
        }



        [HttpGet("GetProductCategoryById/{id}")]

        public IActionResult GetProductCategory(int id)
        {
            var data = _productCategoryAppService.GetProductCategoryById(id);
            return Ok(data);
        }


        [HttpPost("AddNewProductCategory")]
        [Authorize(Roles = "administrator")]
        public IActionResult Post([FromBody] CreateProductCategoryDto productcategory)
        {
            var response = _productCategoryAppService.AddNewProductCategory(productcategory);
            return Ok(response);
        }


        [HttpPut("UpdateProductCategory/{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult Put(int id,UpdateProductCategoryDto productcategory)
        {
            var response = _productCategoryAppService.UpdateProductCategory( id,productcategory);
            return Ok(response);
        }


        [HttpDelete("DeleteProductCategory/{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult Delete(int id)
        {
            var response = _productCategoryAppService.DeleteProductCategory(id);
            return Ok(response);
        }
    }
}
