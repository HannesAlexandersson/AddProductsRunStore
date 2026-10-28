using System;

namespace Client.Models;

public record OrderRestDb : Order
{
    public string _id { get; set; } = string.Empty;
}
