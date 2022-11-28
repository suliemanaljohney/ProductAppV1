using ProductAppV1.Shared.Dto.ProductCategoryDto;

namespace ProductAppV1.Server.Data.AppService.ProductCategoryAppService
{
    public interface IProductCategoryAppService
    {
        List<ProductCategoryInfoDto> GetAllProductCategories();
        ProductCategoryInfoDto GetProductCategoryById(int id);
        ResponseModel UpdateProductCategory(int Id,UpdateProductCategoryDto productcategory);
        ResponseModel AddNewProductCategory(CreateProductCategoryDto productcategory);
        public ResponseModel DeleteProductCategory(int id);
    }
}
