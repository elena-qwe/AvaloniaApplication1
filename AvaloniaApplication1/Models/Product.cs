using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int? Count { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Buy> Buys { get; } = new List<Buy>();
}
