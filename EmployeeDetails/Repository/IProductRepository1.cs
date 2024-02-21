using EmployeeDetails.Model;

namespace EmployeeDetails.Repository
{
    public interface IProductRepository1
    {
        int AddProduct(ProductModel product);
        List<ProductModel> GetAllProduct();
     
        
    }
}