using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class ProductCode
{
    public string ProductCode1 { get; set; } = null!;

    public string? ProductId { get; set; }

    public string? Status { get; set; }

    public string? ProductNum { get; set; }

    public int? IventoryId { get; set; }

    public virtual ProductInventory? Iventory { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Product? Product { get; set; }
}
