using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public int? WarrantyPeriod { get; set; }

    public int? QuantityAvailable { get; set; }

    public DateOnly? LastStockUpdate { get; set; }

    public string? IsDisplay { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ProductCategory? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
}
