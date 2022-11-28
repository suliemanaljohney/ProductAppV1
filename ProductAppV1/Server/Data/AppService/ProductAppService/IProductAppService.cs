using ProductAppV1.Shared.Dto.ProductDto;

namespace ProductAppV1.Server.Data.AppService.ProductAppService
{
    public interface IProductAppService
    {
        List<ProductInfoDto> GetAllProducts();
        Task<ProductInfoDto> GetProductById(int id);
        Task<ResponseModel> AddNewProduct(CreateProductDto Product);
        Task<ResponseModel> UpdateProduct(int Id,UpdateProductDto Product);
        Task<ResponseModel> DeleteProduct(int id);
    }
}
