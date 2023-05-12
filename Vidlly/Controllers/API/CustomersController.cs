using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Vidlly.Dtos;
using Vidlly.Models;
using HttpDeleteAttribute = System.Web.Mvc.HttpDeleteAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;

namespace Vidlly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/cutomers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }
        // GET /api/cutomer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=> c.id == id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.id = customer.id;
            return Created(new Uri(Request.RequestUri + "/" + customer.id), customerDto);
        }
        // Put /api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
          if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var CustomerInDb = _context.Customers.SingleOrDefault(c => c.id == id);
                if(CustomerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, CustomerInDb);

            _context.SaveChanges();
            return Ok();
        }
        // DELETE /api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var CustomerInDb = _context.Customers.SingleOrDefault(c=>c.id == id);
            if(CustomerInDb == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(CustomerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
