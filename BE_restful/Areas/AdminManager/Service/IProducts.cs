using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Services;

public interface IProducts
{
    List<Product> GetPro();
    bool AddProduct(Product product);
    bool DeleteProduct(string productId);
    bool UpdateProduct(Product product);

}
