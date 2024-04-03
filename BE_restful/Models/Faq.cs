using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class Faq
{
    public int Faqid { get; set; }

    public string? Question { get; set; }

    public int? CustomerId { get; set; }

    public string? Answer { get; set; }

    public virtual Customer? Customer { get; set; }
}
