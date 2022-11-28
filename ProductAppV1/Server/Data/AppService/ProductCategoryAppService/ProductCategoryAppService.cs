using ProductAppV1.Shared.Dto.ProductCategoryDto;

namespace ProductAppV1.Server.Data.AppService.ProductCategoryAppService
{
    public class ProductCategoryAppService: IProductCategoryAppService
    {
        public readonly DataContext _dataContext;
        public ProductCategoryAppService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<ProductCategoryInfoDto> GetAllProductCategories()
        {

            List<ProductCategoryInfoDto> productcategoriesInfo = new List<ProductCategoryInfoDto>();
            var res = _dataContext.ProductCategories.ToList();

            foreach (var item in res)
            {
                ProductCategoryInfoDto productcategoryInfo = new ProductCategoryInfoDto();
                var product = _dataContext.Products.Where(x => x.Id == item.ProductId).FirstOrDefault();
                var category = _dataContext.Categories.Where(x => x.Id == item.CategoryId).FirstOrDefault();
                productcategoryInfo.Id = item.Id;
                productcategoryInfo.ProductId=item.ProductId;
                productcategoryInfo.Product = product;
                productcategoryInfo.CategoryId= item.CategoryId;
                productcategoryInfo.Category = category;
                productcategoriesInfo.Add(productcategoryInfo);
            }
            return productcategoriesInfo;
        }

        public ProductCategoryInfoDto GetProductCategoryById(int id)
        {
            var productcategory = _dataContext.ProductCategories.Where(x => x.Id == id).FirstOrDefault();
            

            ProductCategoryInfoDto productcategoryInfo = new ProductCategoryInfoDto();
            if (productcategory == null)
            {
                throw new Exception("notfound");
            }
            else
            {
                var category = _dataContext.Categories.Where(x => x.Id == productcategory.CategoryId).FirstOrDefault();
                var product = _dataContext.Products.Where(x => x.Id == productcategory.ProductId).FirstOrDefault();
                productcategoryInfo.Id = productcategory.Id;
                productcategoryInfo.CategoryId= productcategory.CategoryId;
                productcategoryInfo.ProductId= productcategory.ProductId;
                productcategoryInfo.Product = product;
                productcategoryInfo.Category = category;

            }
            return productcategoryInfo;
        }
        public ResponseModel UpdateProductCategory(int Id,UpdateProductCategoryDto productcategory)
        {
            ResponseModel response = new ResponseModel();
            var oldproductcategory = _dataContext.ProductCategories.Where(x => x.Id ==Id).FirstOrDefault();
            if (oldproductcategory == null)
            {
                throw new Exception("itemNotFounde");
            }
            else
            {
                
                oldproductcategory.ProductId = productcategory.ProductId;
                oldproductcategory.CategoryId = productcategory.CategoryId;
                
                _dataContext.ProductCategories.Update(oldproductcategory);
                _dataContext.SaveChanges();

                response.status = true;
                response.message = " item Updated Successfully ";
                return response;
            }

        }

        public ResponseModel AddNewProductCategory(CreateProductCategoryDto productcategory)
        {
            ResponseModel response = new ResponseModel();
            ProductCategory newproductcategory = new ProductCategory();
            
            newproductcategory.ProductId = productcategory.ProductId;
            newproductcategory.CategoryId = productcategory.CategoryId;
            

            _dataContext.ProductCategories.Add(newproductcategory);
            _dataContext.SaveChanges();

            response.status = true;
            response.message = " item Added Successfully ";
            return response;


        }
        public ResponseModel DeleteProductCategory(int id)
        {
            ResponseModel response = new ResponseModel();
            var productcategory = _dataContext.ProductCategories.Where(x => x.Id == id).FirstOrDefault();
            if(productcategory==null)
            {
                throw new Exception("ItemNotFound");

            }
            else
            {
                _dataContext.ProductCategories.Remove(productcategory);
                _dataContext.SaveChanges();
                response.status = true;
                response.message = " item deleted Successfully ";
                return response;
            }
            
            
        }
    }
}
