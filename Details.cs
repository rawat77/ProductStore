using ProductStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductStore
{
    public class DetailsController : ApiController
    {
        // GET api/<controller>
        public List<OrderDTO.Customer> Get()
        {
            SampleDBEntities sb = new SampleDBEntities();
            OrderDTO dto = new OrderDTO();
            //var q = (from pd in sb.Products
            //         join od in sb.OrderDetails on pd.id equals od.ProductId
            //         join ct in sb.Customers on od.CustomerID equals ct.Id
            //         join or in sb.Orders on od.OrderId equals or.id
            //         orderby od.OrderId
            //         select new
            //         {
            //             ct.Id,
            //             ct.Name,
            //             ct.Email,
            //             or.id,
            //             od.OrderId,
            //             or.OrderDate,
            //             od.ProductId,
            //             //pd.Name,
            //             od.Quantity,
            //             Customer = ct.Name //define anonymous type Customer
            //         }).ToList();
            dto.Customers= (from  dct in sb.Customers 
                    select new OrderDTO.Customer()
                    {
                        Id = dct.Id,
                        Name = dct.Name,
                        Email = dct.Email,
                        order = (from  or in sb.Orders join d in (from orde in sb.OrderDetails select new { orderid = orde.OrderId,customerid=orde.CustomerID }).Distinct() on or.id equals d.orderid  where d.customerid==dct.Id
                                 select new OrderDTO.OrderData()
                                 {
                                     Id = or.id,
                                     OrderNumber = or.OrderDetailID,
                                     OrderDate = or.OrderDate,
                                     products = (from p in sb.Products join de in sb.OrderDetails on p.id equals de.ProductId where de.OrderId==d.orderid
                                                 select new OrderDTO.ProductData()
                                                 { Name = p.Name, Quantity = de.Quantity }).ToList()
                                 }).ToList()
                    }).ToList();

            return dto.Customers;
            
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}