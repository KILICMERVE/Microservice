using Core.Utilities.Results;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Validation;
using CustomerAPI.Infrastructure;
using CustomerAPI.Models;
using CustomerAPI.Services.ValidationRules.FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

       [ValidationAspect(typeof(CustomerValidator))]
        public IResult Create(Customer customer)
        {

            var result = _customerDal.Validate(customer.CustomerId);
            if (result)
            {
                throw new Exception();
            }
            _customerDal.Create(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetByCustomerId(Guid id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == id));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            ValidationTool.Validate(new CustomerValidator(), customer);
            _customerDal.Update(customer);
            return new SuccessResult();
        }

        public IResult Validate(Guid id)
        {
            _customerDal.Validate(id);
            return new SuccessResult();
        }
    }
}
