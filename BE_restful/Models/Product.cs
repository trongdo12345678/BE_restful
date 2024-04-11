using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public string? Img { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public int? WarrantyPeriod { get; set; }

    public string? IsDisplay { get; set; }

    public decimal? Price { get; set; }

    public virtual ProductCategory? Category { get; set; }

    public virtual ICollection<ProductCode> ProductCodes { get; set; } = new List<ProductCode>();
}
