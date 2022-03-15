using CustomerAPI.Infrastructure;
using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CustomerDataAccess.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        public void Create(Customer customer)
        {
            using (DataBaseContext context=new DataBaseContext())
            {
                var createdCustomer = context.Entry(customer);
                createdCustomer.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Customer customer)
        {
            using (DataBaseContext context=new DataBaseContext())
            {
                var deletedCustomer = context.Entry(customer);
                deletedCustomer.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            using (DataBaseContext context=new DataBaseContext())
            {
                return context.Set<Customer>().SingleOrDefault(filter);
            }
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            using (DataBaseContext context=new DataBaseContext())
            {
                return filter == null ?
                    context.Set<Customer>().ToList() :
                    context.Set<Customer>().Where(filter).ToList();
            }
        }

        public void Update(Customer customer)
        {
            using (DataBaseContext context=new DataBaseContext())
            {
                var updatedCustomer = context.Entry(customer);
                updatedCustomer.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public bool Validate(Guid id)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var result = context.Set<Customer>().SingleOrDefault(c => c.CustomerId == id);
                return true;
            }
        }
    }
}
