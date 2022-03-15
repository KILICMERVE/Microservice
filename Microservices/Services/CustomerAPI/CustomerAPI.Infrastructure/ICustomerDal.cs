using CustomerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CustomerAPI.Infrastructure
{
    public interface ICustomerDal
    {
        List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null);
        Customer Get(Expression<Func<Customer, bool>> filter);
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        bool Validate(Guid id);
    }
}
