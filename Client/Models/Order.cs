using System;
using System.Collections.Generic;

namespace Client.Models;

public record Order
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public Guid OrderId { get; set; } = Guid.NewGuid();
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public required Customer Customer { get; set; }
    public List<Product> Items { get; set; } = [];
}