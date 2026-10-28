using System;
using Client.Models;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Client.Interfaces;

public interface IOrderService
{
    Task Add(Order order);
    Task Delete(string id);
    Task<OrderRestDb> Find(string itemNumber);
    Task<List<Order>> List();
    Task Update(Order order, string _objectId);
}
