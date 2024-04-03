using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class ProductReturn
{
    public int ReturnId { get; set; }

    public int? OrderId { get; set; }

    public string? ProductId { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string? Reason { get; set; }

    public int? EmployeeId { get; set; }

    public bool? IsRefunded { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Order? Order { get; set; }
}
