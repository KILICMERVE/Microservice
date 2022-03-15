using Core.Utilities.Results;
using OrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAPI.Infrastructure
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<List<Order>> GetAllByCustomerId(Guid customerId);
        IDataResult<Order> GetByOrderId(Guid id);
        IResult Create(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);
        IResult ChangeStatus(Guid id, string status);
    }
}
