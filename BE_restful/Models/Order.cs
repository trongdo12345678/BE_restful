using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public int? CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int? DeliveryTypeId { get; set; }

    public int? PaymentMethodId { get; set; }

    public bool? IsPaid { get; set; }

    public string? ProductId { get; set; }

    public string? ProductCode { get; set; }

    public int? EmployeeId { get; set; }

    public string? Status { get; set; }

    public double? TotalPaid { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; } = new List<DeliveryDetail>();

    public virtual DeliveryType? DeliveryType { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual ProductCode? ProductCodeNavigation { get; set; }

    public virtual ICollection<ReturnDetail> ReturnDetails { get; set; } = new List<ReturnDetail>();
}
