using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class ProductInventory
{
    public int InventoryId { get; set; }

    public string? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? DayInventory { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<ProductCode> ProductCodes { get; set; } = new List<ProductCode>();
}
