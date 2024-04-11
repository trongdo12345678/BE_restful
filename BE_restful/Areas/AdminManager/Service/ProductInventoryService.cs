using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Service;

public interface ProductInventoryService
{
    public int? AddProInven(ProductInventory ProInven);
    public List<Product> GetPro();
    public bool InventoryProCode(ProductInventory ProInven);
    public int? GetProNum(string idpro);
    public List<ProductInventory> GetAllProInven();
    public List<ProductInventory> GetProInven();
}
