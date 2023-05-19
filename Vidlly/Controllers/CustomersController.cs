using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidlly.Models;
using System.Data.Entity;
using Vidlly.ViewModels;

namespace Vidlly.Controllers
{
    
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer Customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = Customer,
                        membershipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if((Customer.id == 0))
            {
                _context.Customers.Add(Customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c=> c.id== Customer.id);
                customerInDb.name = Customer.name;
                customerInDb.Birthdate = Customer.Birthdate;
                customerInDb.MembershipTypeId= Customer.MembershipTypeId;
                customerInDb.isSubscribedToNewsLetter= Customer.isSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }   
        public ActionResult New()
        {
            var membershipType = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                membershipTypes = membershipType
            };
            return View("CustomerForm", viewModel);
        }
        public ViewResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //if (customers == null)
            //{
            //    return View("There exist no customer record");
            //} // 
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.id == id);
            if(customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                membershipTypes = _context.MembershipType.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}