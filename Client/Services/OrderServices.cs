using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class OrderServices : IOrderService
{
    public async Task Add(Order order)
    {
        var httpService = new HttpService<Order>();
        await httpService.Post("orders", order);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Order>();
        await httpService.Delete("orders", id);
    }

    public async Task<OrderRestDb> Find(string itemNumber)
    {
        var httpService = new HttpService<OrderRestDb>();
        var searchCriteria = "{\"itemNumber\":" + "\"" + itemNumber + "\"}";
        return await httpService.Get("orders", searchCriteria);
    }

    public async Task<List<Order>> List()
    {
        var httpService = new HttpService<Order>();
        var orders = await httpService.Get("orders");
        return orders;
    }

    public async Task Update(Order order, string _objectId)
    {
        var httpService = new HttpService<Order>();
        await httpService.Put("orders", order, _objectId);
    }


}
