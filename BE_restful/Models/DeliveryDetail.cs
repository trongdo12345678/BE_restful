using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class DeliveryDetail
{
    public int DeliveryId { get; set; }

    public int? OrderId { get; set; }

    public DateOnly? Date { get; set; }

    public string? DeliveryStatus { get; set; }

    public virtual Order? Order { get; set; }
}
