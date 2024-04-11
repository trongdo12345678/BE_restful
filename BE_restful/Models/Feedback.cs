using System;
using System.Collections.Generic;

namespace BE_restful.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public DateOnly? FeedbackDate { get; set; }

    public string? OrderId { get; set; }

    public string? FeedbackMessage { get; set; }

    public virtual Order? Order { get; set; }
}
