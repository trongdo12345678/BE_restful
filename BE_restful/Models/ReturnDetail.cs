using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class ReturnDetail
{
    public string? OrderId { get; set; }

    public int ReturnId { get; set; }

    public string? Status { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string? Reason { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Order? Order { get; set; }
}
