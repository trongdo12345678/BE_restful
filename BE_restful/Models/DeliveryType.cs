using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class DeliveryType
{
    public int DeliveryTypeId { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
