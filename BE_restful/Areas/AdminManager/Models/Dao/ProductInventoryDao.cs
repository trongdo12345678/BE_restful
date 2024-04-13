using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BE_restful.Areas.AdminManager.Models.Dao;

public class ProductInventoryDao : ProductInventoryService
{
    private readonly ArtsContext _context;
    public ProductInventoryDao(ArtsContext context)
    {
        _context = context;
    }
    public List<Product> GetPro()
    {
        try
        {
            var res = _context.Products.ToList();
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
    public int? AddProInven(ProductInventory ProInven)
    {
        try
        {
            _context.ProductInventories.Add(ProInven);
            ProInven.DayInventory = DateOnly.FromDateTime(DateTime.Now);
            if(_context.SaveChanges() > 0)
            {
                return _context.ProductInventories.Max(p => p.InventoryId);
            }
            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool InventoryProCode(ProductInventory ProInven)
    {
        try
        {
            // Thêm bản ghi kho sản phẩm với xác thực số lượng
            if (ProInven.Quantity <= 0)
            {
                throw new ArgumentException("Product quantity must be greater than 0.");
            }

            int? idiven = AddProInven(ProInven);
            if (idiven == null)
            {
                return false;
            }

            //Truy xuất kho sản phẩm mới tạo
            ProductInventory iven = _context.ProductInventories.SingleOrDefault(p => p.InventoryId == idiven);
            List<ProductCode> productCodes = new List<ProductCode>((int)iven.Quantity);
            int startingNum = GetProNum(iven.ProductId) ?? 1;
            string productCodePrefix = $"{iven.ProductId}";

            for (int i = 0; i < ProInven.Quantity; i++)
            {
                int uniqueNum = (startingNum + i) + 1;
                string formattedProductNum = uniqueNum.ToString("D5"); // Đệm số 0 đến 5 chữ số

                productCodes.Add(new ProductCode()
                {
                    ProductCode1 = productCodePrefix + formattedProductNum,
                    ProductId = iven.ProductId,
                    ProductNum = formattedProductNum,
                    IventoryId = iven.InventoryId,
                    Status = "ex"
                });
            }

            _context.ProductCodes.AddRange(productCodes);
            return _context.SaveChanges() > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public int? GetProNum(string idpro)
    {
        try
        {
            var maxProNum = _context.ProductCodes
                .Where(p => p.ProductId == idpro)
                .Select(p => p.ProductNum)
                .Max();

           if(maxProNum != null)
            {
                if (int.TryParse(maxProNum, out int result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return 0;
            }
            
            
        }
        catch (Exception)
        {
           return null;
        }
    }

    public List<ProductInventory> GetAllProInven()
    {
        try
        {
            var res = _context.ProductInventories.ToList();
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
    public List<ProductInventory> GetProInven()
    {
        try
        {
            var productInventories = (from pi in _context.ProductInventories
                                      select new ProductInventory
                                      {
                                          InventoryId = pi.InventoryId,
                                          ProductId = pi.ProductId,
                                          Quantity = pi.Quantity,
                                          DayInventory = pi.DayInventory,
                                          Product = (from p in _context.Products
                                                     where p.ProductId == pi.ProductId
                                                     select p).FirstOrDefault()
                                      }).ToList();

            return productInventories;
        }
        catch (Exception)
        {
            return [];
        }
    }




}
