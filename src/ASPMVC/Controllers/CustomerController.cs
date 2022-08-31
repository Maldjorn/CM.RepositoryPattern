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
            repository = new CustomerRepository();
            
            return View();
        }
    }
}