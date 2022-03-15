using Core.Utilities.Results;
using CoreLayer.Aspects.Autofac.Validation;
using OrderAPI.Infrastructure;
using OrderAPI.Models;
using OrderAPI.Services.ValidationRules.FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAPI.Services
{
    public class OrderService:IOrderService
    {
        IOrderDal _orderDal;

        public OrderService(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult ChangeStatus(Guid id, string status)
        {
            _orderDal.ChangeStatus(id, status);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(OrderValidator))]
        public IResult Create(Order order)
        {
            _orderDal.Create(order);
            return new SuccessResult();
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult();
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());

        }

        //get(uuidv4):Order[] iişlemine karşılıktır.Bir müşteriye ait alışveriş listesi döndürür
        public IDataResult<List<Order>> GetAllByCustomerId(Guid customerId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.CustomerId == customerId), "");
        }

        public IDataResult<Order> GetByOrderId(Guid id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o => o.OrderId == id));
        }



        [ValidationAspect(typeof(OrderValidator))]
        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult();
        }
    }
}
