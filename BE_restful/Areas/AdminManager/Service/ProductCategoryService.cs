using BE_restful.Models;

namespace BE_restful.Areas.AdminManager.Service;

public interface ProductCategoryService
{
    public List<ProductCategory> GetProCate();
    public bool AddProCate(ProductCategory proCate);
    public bool DeleteCate(int id);
    public bool UpdateCate(ProductCategory proCate);
}
