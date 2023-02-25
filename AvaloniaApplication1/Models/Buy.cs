using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class Buy
{
    public int Id { get; set; }

    public DateOnly? Data { get; set; }

    public string? TypePayment { get; set; }

    public int? IdProduct { get; set; }

    public int? IdClient { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
