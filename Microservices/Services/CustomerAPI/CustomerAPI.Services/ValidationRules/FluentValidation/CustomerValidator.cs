using CustomerAPI.Infrastructure;
using CustomerAPI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI.Services.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
       

        public CustomerValidator()
        {
            RuleFor(c => c.CustomerName).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.AddressId).NotEmpty();
            RuleFor(c => c.CreatedAt).NotEmpty();
            RuleFor(c => c.UpdatedAt).NotEmpty();

        }

      

      
        
    }
}
