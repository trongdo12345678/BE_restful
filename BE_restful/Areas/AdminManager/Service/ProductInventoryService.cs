using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Service;

public interface ProductInventoryService
{
    public bool AddProInven(ProductInventory ProInven);
    public List<Product> GetPro();
    public List<ProductInventory> GetAllProInven();
    public List<ProductInventory> GetProInven();
}
