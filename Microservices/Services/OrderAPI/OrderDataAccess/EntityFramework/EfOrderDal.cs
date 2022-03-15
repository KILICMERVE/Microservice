using Microsoft.EntityFrameworkCore;
using OrderAPI.Infrastructure;
using OrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OrderDataAccess.EntityFramework
{
    public class EfOrderDal : IOrderDal
    {
        
        public bool ChangeStatus(Guid id, string status)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var result = context.Set<Order>().SingleOrDefault(o => o.OrderId == id);
                result.Status = status;
                return true;
            }
        }

        public void Create(Order order)
        {
            using (DataBaseContext context=new DataBaseContext())
            {
                var createdOrder = context.Entry(order);
                createdOrder.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Order order)
        {
            using (DataBaseContext context=new DataBaseContext())
            {
                var deletedOrder = context.Entry(order);
                deletedOrder.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Order Get(Expression<Func<Order, bool>> filter)
        {
            using (DataBaseContext context=new DataBaseContext())
            {
                return context.Set<Order>().SingleOrDefault(filter);
            }
        }

        public List<Order> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            using (DataBaseContext context=new DataBaseContext())
            {
                return filter == null ?
                    context.Set<Order>().ToList() :
                    context.Set<Order>().Where(filter).ToList();
            }
        }

        public void Update(Order order)
        {
            using (DataBaseContext context=new DataBaseContext())
            {
                var updatedOrder = context.Entry(order);
                updatedOrder.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
