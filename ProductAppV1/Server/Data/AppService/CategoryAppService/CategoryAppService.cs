using ProductAppV1.Shared.Dto.CategoryDto;

namespace ProductAppV1.Server.Data.AppService.CategoryAppService
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly DataContext _dataContext;
        public CategoryAppService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public  List<CategoryInfoDto>  GetAllCategories()
        {     
            
            List<CategoryInfoDto> categoryInfos = new List<CategoryInfoDto>();
            var res= _dataContext.Categories.ToList();
            
            foreach (var item in res)
            {
                CategoryInfoDto categoryInfo = new CategoryInfoDto();
                var products = _dataContext.Products.Where(x => x.CategoryId == item.Id).ToList();
                categoryInfo.Id=item.Id;
                categoryInfo.Name = item.Name;
                categoryInfo.Products= products;
                categoryInfos.Add(categoryInfo);
            }
            return categoryInfos;
        }
        
        public CategoryInfoDto GetCategoryById(int id) 
        {
            var result = _dataContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            var products = _dataContext.Products.Where(x => x.CategoryId ==id).ToList();

            CategoryInfoDto categoryInfo = new CategoryInfoDto();
            if (result==null)
                    {
                throw new Exception("notfound");
            }
            else
            {
                categoryInfo.Id = result.Id;
                categoryInfo.Name = result.Name;
                categoryInfo.Products= products;
                
            }
            return categoryInfo;
        }
        public  ResponseModel UpdateCategory(int Id,UpdateCategoryDto category)
        {
            ResponseModel response = new ResponseModel();
            var oldcategory = _dataContext.Categories.Where(x => x.Id == Id).FirstOrDefault();
            if(category==null)
            {
                throw new Exception("CategoryNotFounde");
            }
            else
            {
                oldcategory.Name = category.Name;
                _dataContext.Categories.Update(oldcategory);
                _dataContext.SaveChanges();

                response.status = true;
                response.message = " item Updated Successfully ";
                return response;
            }
          
        }

        public  ResponseModel AddNewCategory(CreateCategoryDto category)
        {
            ResponseModel response = new ResponseModel();
            
            
            Category newcategory=new Category();
                  newcategory.Name = category.Name;
            _dataContext.Categories.Add(newcategory);
            _dataContext.SaveChanges();

            
            List<Product>products = new List<Product>();
            foreach (var item in category.Products)
            {
                Product product = new Product();
                product.Name = item.Name;
                product.Price = item.Price;
                product.Description=item.Description;
                product.CategoryId = newcategory.Id;
                products.Add(product);


            }
            foreach (var item in products)
            {
                _dataContext.Products.Add(item);
                _dataContext.SaveChanges();
            }
            



            response.status = true;
            response.message = " item Added Successfully ";
            return response;


        }
        public  ResponseModel DeleteCategory(int id)
        {
            ResponseModel response=new ResponseModel();
            var category = _dataContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            var products = _dataContext.Products.Where(x => x.CategoryId == category.Id).ToList();
            if (category == null)
            {
                throw new Exception("CagtegoryNotFound");

            }
            else
                foreach(var product in products)
                {
                    _dataContext.Products.Remove(product);
                    _dataContext.SaveChanges();
                }
             _dataContext.Categories.Remove(category);
            _dataContext.SaveChanges();

            response.status = true;
            response.message = " item deleted Successfully ";
            return response;


        }


    }
}
