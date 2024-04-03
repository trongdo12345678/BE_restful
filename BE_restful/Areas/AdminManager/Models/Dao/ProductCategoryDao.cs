using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using NuGet.ProjectModel;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class ProductCategoryDao : ProductCategoryService
{
    private readonly ArtsDbContext _context;
    public ProductCategoryDao(ArtsDbContext context)
    {
        _context = context;
    }
    public List<ProductCategory> GetProCate()
    {
        try
        {
            var res = _context.ProductCategories.ToList();
            if (res != null)
            {
                return res;
            }
            return [];
        }
        catch (Exception)
        {

            return [];
        }
    }
    public bool AddProCate(ProductCategory proCate)
    {
        try
        {
            _context.ProductCategories.Add(proCate);
            return _context.SaveChanges() > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public bool DeleteCate(int id)
    {
        try
        {
            var b = _context.ProductCategories.FirstOrDefault(p => p.CategoryId.Equals(id));
            if (b != null)
            {
                _context.ProductCategories.Remove(b);
                return _context.SaveChanges() > 0;
            }
            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }
    public bool UpdateCate(ProductCategory proCate)
    {
        try
        {
            var e = _context.ProductCategories.FirstOrDefault(p => p.CategoryId == proCate.CategoryId);
            if (e != null)
            {

                e.CategoryName = proCate.CategoryName;
                return _context.SaveChanges() > 0;
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

}
