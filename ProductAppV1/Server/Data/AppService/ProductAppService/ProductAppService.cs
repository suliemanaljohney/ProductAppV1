using ProductAppV1.Shared.Dto.ProductDto;

namespace ProductAppV1.Server.Data.AppService.ProductAppService
{
    public class ProductAppService:IProductAppService
    {
        private readonly DataContext _dataContext;
        public ProductAppService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<ProductInfoDto> GetAllProducts()
        {
            
            List<ProductInfoDto> ProductsInfo = new List<ProductInfoDto>();
            
            var res = _dataContext.Products.ToList();

            foreach (var item in res)
            {
                ProductInfoDto ProductInfo = new ProductInfoDto();
                var category = _dataContext.Categories.Where(x => x.Id==item.CategoryId).FirstOrDefault();
                ProductInfo.Id = item.Id;
                ProductInfo.Name = item.Name;
                ProductInfo.Price = item.Price;
                ProductInfo.Category = category;

                ProductsInfo.Add(ProductInfo);
            }
            return ProductsInfo;
        }

        public async Task<ProductInfoDto> GetProductById(int id)
        {
            
            var product = _dataContext.Products.Where(x =>x.Id== id).FirstOrDefault();
            var category = _dataContext.Categories.Where(x => x.Id == product.CategoryId).FirstOrDefault();
            ProductInfoDto ProductInfo = new ProductInfoDto();
            if (product == null)
            {
                throw new Exception("Productnotfound");
            }
            else
            {
                ProductInfo.Id = product.Id;
                ProductInfo.Name = product.Name;
                ProductInfo.Price = product.Price;
                ProductInfo.Description = product.Description;
                ProductInfo.Category = category;

            }
            return ProductInfo;
        }
        public async Task<ResponseModel> UpdateProduct(int Id ,UpdateProductDto Product)
        {
            ResponseModel response = new ResponseModel();
            var oldProduct = _dataContext.Products.Where(x => x.Id ==Id).FirstOrDefault();
            if (oldProduct == null)
            {
                throw new Exception("ProductNotFound");
            }
            else
            {
                
                oldProduct.Name = Product.Name;
                oldProduct.Price = Product.Price;
                oldProduct.Description = Product.Description;
                oldProduct.CategoryId = Product.CategoryId;
                _dataContext.Products.Update(oldProduct);
                _dataContext.SaveChanges();

                response.status = true;
                response.message = " item Updated Successfully ";
                return response;
            }

        }
        public async Task<ResponseModel> AddNewProduct(CreateProductDto Product)
        {
            ResponseModel response = new ResponseModel();
            Product newProduct = new Product();
            newProduct.Name = Product.Name;
            newProduct.Price= Product.Price;
            newProduct.Description=Product.Description;
            newProduct.CategoryId = Product.CategoryId;

            _dataContext.Products.Add(newProduct);
            _dataContext.SaveChanges();

            response.status = true;
            response.message = " Product Added Successfully ";
            return response;


        }
        public async Task<ResponseModel> DeleteProduct(int id)
        {
            ResponseModel response = new ResponseModel();
            var Product = _dataContext.Products.Where(x => x.Id == id).FirstOrDefault();
            if (Product == null)
            {
                throw new Exception("ProductNotFound");

            }
            else
                _dataContext.Products.Remove(Product);
            _dataContext.SaveChanges();

            response.status = true;
            response.message = " Product deleted Successfully ";
            return response;


        }
    }
}
