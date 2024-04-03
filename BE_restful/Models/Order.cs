using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int? DeliveryTypeId { get; set; }

    public int? PaymentMethodId { get; set; }

    public bool? IsPaid { get; set; }

    public double? TotalPaid { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; } = new List<DeliveryDetail>();

    public virtual DeliveryType? DeliveryType { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual ICollection<ProductReturn> ProductReturns { get; set; } = new List<ProductReturn>();
}
