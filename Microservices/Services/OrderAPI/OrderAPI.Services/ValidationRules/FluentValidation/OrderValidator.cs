using FluentValidation;
using OrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAPI.Services.ValidationRules.FluentValidation
{
    public class OrderValidator: AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.CustomerId).NotEmpty();
            RuleFor(o => o.Quantity).NotEmpty();
            RuleFor(o => o.Price).NotEmpty();
            RuleFor(o => o.Status).NotEmpty();
            RuleFor(o => o.AddressId).NotEmpty();
            RuleFor(o => o.ProductId).NotEmpty();
            RuleFor(o => o.CreatedAt).NotEmpty();
            RuleFor(o => o.UpdatedAt).NotEmpty();
        }
    }
}
