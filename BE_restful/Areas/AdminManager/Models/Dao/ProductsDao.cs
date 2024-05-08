using BE_restful.Areas.AdminManager.Services;
using BE_restful.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class ProductsDao : IProducts
{
    private readonly ArtsContext _context;

    public ProductsDao(ArtsContext context)
    {
        _context = context;
        if (_context.Products.Any())
        {
            _nextProductId = int.Parse(_context.Products.Max(p => p.ProductId)) + 1;
        }
    }
    private static int _nextProductId = 1;
    public bool AddProduct(Product product)
    {
        product.ProductId = _nextProductId.ToString("D2");

        try
        {

            _context.Products.Add(product);
            _context.SaveChanges();


            _nextProductId++;

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding product: {ex.Message}");
            return false;
        }
    }
    public List<Product> GetPro()
    {
        try
        {
            var products = (from product in _context.Products
                            join category in _context.ProductCategories on product.CategoryId equals category.CategoryId into categoryGroup
                            from category in categoryGroup.DefaultIfEmpty()
                            select new Product
                            {
                                ProductId = product.ProductId,
                                ProductName = product.ProductName,
                                Description = product.Description,
                                CategoryId = product.CategoryId,
                                WarrantyPeriod = product.WarrantyPeriod,
                                IsDisplay = product.IsDisplay,
                                Img = product.Img,
                                Price = product.Price,
                                Category = category
                            }).ToList();

            return products;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting products: {ex.Message}");
            return null;
        }
    }


    public bool DeleteProduct(string productId)
    {
        try
        {

            var productToDelete = _context.Products.FirstOrDefault(p => p.ProductId == productId.ToString());

            if (productToDelete == null)
            {
                return false;
            }

            _context.Products.Remove(productToDelete);
            _context.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting product: {ex.Message}");
            return false;
        }
    }



    public bool UpdateProduct(Product product)
    {
        try
        {

            var existingProduct = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);


            if (existingProduct == null)
            {
                return false;
            }


            existingProduct.ProductName = product.ProductName;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.WarrantyPeriod = product.WarrantyPeriod;
            existingProduct.IsDisplay = product.IsDisplay;
            existingProduct.Price = product.Price;
            existingProduct.Img = product.Img;


            _context.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating product: {ex.Message}");
            return false;
        }
    }


}
