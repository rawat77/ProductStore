using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
    using System.Collections.Generic;

    public class OrderDTO
    {

        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            public List<OrderData> order { get; set; }

        }
        public List<Customer> Customers { get; set; }
        public class OrderData
        {
            public int Id { get; set; }
            public int OrderNumber { get; set; }
            public DateTime? OrderDate { get; set; }
            public List<ProductData> products { get; set; }

        }
        public class ProductData
        {
            public string Name { get; set; }
            public int? Quantity { get; set; }

        }
    }
}