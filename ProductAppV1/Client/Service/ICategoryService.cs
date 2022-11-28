using ProductAppV1.Shared;
using ProductAppV1.Shared.Dto.CategoryDto;

namespace ProductAppV1.Client.Service
{
    public interface ICategoryService
    {
        Task<List<CategoryInfoDto>> GetAllCategories();
        List<CategoryInfoDto> CategoriesInfos { get; set; }
        Task<List<Category>> GetCategories();
    }
}
