using ProductAppV1.Shared;
using ProductAppV1.Shared.Dto.CategoryDto;
using System.Net.Http.Json;

namespace ProductAppV1.Client.Service
{
    public class CategoryService:ICategoryService
    {
        private readonly HttpClient _httpclient;
        public CategoryService(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }
        public List<CategoryInfoDto> CategoriesInfos { get; set; }=new List<CategoryInfoDto>();
        public async Task< List<CategoryInfoDto>> GetAllCategories()
        {

            CategoriesInfos= await _httpclient.GetFromJsonAsync<List<CategoryInfoDto>>("api/Category/GetAllCategories");
            return CategoriesInfos;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _httpclient.GetFromJsonAsync<List<Category>>("api/Category/GetCategories");

        }
        //public async List<ResponseModel> AddNewCategory(CategoryInfo categoryInfo)
        //{
        //    var response = await HttpClient.PostAsJsonAsync("api/Category/AddNewCategory", categoryInfo);
        //    return await response.Content.ReadFromJsonAsync<ResponseModel>();
        //}
    }
}
