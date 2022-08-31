using CM.Customers;
using CM.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVC.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> customers = new List<Customer>();
        IRepository<Customer> repository;
        public ActionResult Index()
        {
            repository = new CustomerRepository();
            customers = repository.GetAll();
            return View(customers);
        }

        public ActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                repository = new CustomerRepository();
                repository.Create(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("","Unable to add customer");
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Details(int? customerId)
        {
            repository = new CustomerRepository();
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = repository.Read(customerId.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}