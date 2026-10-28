using System;

namespace Client.Models;

public record OrderProduct : Product
{
    public int Quantity { get; set; }
    public int LineSum { get; set; }
}
