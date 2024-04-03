using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? Username { get; set; }

    public int? RoleId { get; set; }

    public int? ManagerId { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Employee? Manager { get; set; }

    public virtual ICollection<ProductReturn> ProductReturns { get; set; } = new List<ProductReturn>();

    public virtual Role? Role { get; set; }
}
