using Core.Utilities.Results;
using CustomerAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI.Infrastructure
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetByCustomerId(Guid id);
        IResult Create(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IResult Validate(Guid id);
    }
}
