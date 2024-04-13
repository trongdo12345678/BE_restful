namespace BE_restful.Models;

public class Orders
{

    public int? CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int? DeliveryTypeId { get; set; }

    public int? PaymentMethodId { get; set; }

    public bool? IsPaid { get; set; }

    public string? ProductId { get; set; }

    public string? Status { get; set; }

    public double? TotalPaid { get; set; }
}
