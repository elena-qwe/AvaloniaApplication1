using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string DataPassport { get; set; } = null!;

    public string HomeAddress { get; set; } = null!;

    public int Phone { get; set; }

    public virtual ICollection<Buy> Buys { get; } = new List<Buy>();
}
