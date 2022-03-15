using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI.Models
{
    public class Customer
    {

        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public Guid AddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
