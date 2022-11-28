using ProductAppV1.Shared.Dto.CategoryDto;

namespace ProductAppV1.Server.Data.AppService.CategoryAppService
{
    public interface ICategoryAppService
    {
        List<CategoryInfoDto> GetAllCategories();
        CategoryInfoDto GetCategoryById(int id);
        ResponseModel AddNewCategory(CreateCategoryDto category);
        ResponseModel UpdateCategory(int Id,UpdateCategoryDto category);
        ResponseModel DeleteCategory(int id);
    }
}
