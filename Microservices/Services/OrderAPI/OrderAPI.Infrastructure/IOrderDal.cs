using OrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OrderAPI.Infrastructure
{
    public interface IOrderDal
    {
        void Create(Order order);
        void Update(Order order);
        void Delete(Order order);
        List<Order> GetAll(Expression<Func<Order, bool>> filter = null);
        Order Get(Expression<Func<Order, bool>> filter);
        bool ChangeStatus(Guid id, string status);
    }
}
