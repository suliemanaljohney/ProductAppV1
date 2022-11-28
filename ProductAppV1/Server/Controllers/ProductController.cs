using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAppV1.Server.Data.AppService.ProductAppService;
using ProductAppV1.Shared.Dto.ProductDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAppV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        [HttpGet("GetAllProducts")]

        public IActionResult GetAllCategories()
        {
            var data = _productAppService.GetAllProducts();
            return Ok(data);
        }



        [HttpGet("GetProductById/{id}")]

        public IActionResult GetSingleProduct(int id)
        {
            var data = _productAppService.GetProductById(id);
            return Ok(data);
        }


        [HttpPost("AddNewProduct")]
        [Authorize(Roles = "administrator")]
        public IActionResult Post([FromBody] CreateProductDto Product)
        {
            var response = _productAppService.AddNewProduct(Product);
            return Ok(response);
        }


        [HttpPut("UpdateProduct/{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult Put(int id,UpdateProductDto Product)
        {
            var response = _productAppService.UpdateProduct(id,Product);
            return Ok(response);
        }


        [HttpDelete("DeleteProduct/{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult Delete(int id)
        {
            var response = _productAppService.DeleteProduct(id);
            return Ok(response);
        }
    }
}
