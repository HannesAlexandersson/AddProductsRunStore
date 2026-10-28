using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Models;

public class Order
{
    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public DateTime OrderDate { get; set; } = new DateTime();
    public required Customer Customer { get; set; }
    public required List<OrderProduct> Items { get; set; }
    public int TotalSum => Items.Sum(item => item.Price);
}
