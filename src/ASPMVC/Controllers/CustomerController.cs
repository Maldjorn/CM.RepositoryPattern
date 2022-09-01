using CM.Customers;
using CM.Customers.Repositories;
using System.Collections.Generic;
using PagedList;
using System.Web.Mvc;

namespace ASPMVC.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> customers = new List<Customer>();
        IRepository<Customer> customerRepository;
        public CustomerController()
        {
            customerRepository = new CustomerRepository();
        }

        public CustomerController(IRepository<Customer> repository)
        {
            customerRepository = repository;
        }
        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            customers = customerRepository.GetAll();
            return View(customers.ToPagedList(pageNumber,pageSize));
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
                customerRepository.Create(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Unable to add customer");
            }
            return View(customer);
        }

        public ActionResult Details(int? customerId)
        {
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = customerRepository.Read(customerId);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Delete(int? customerId)
        {
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = customerRepository.Read(customerId);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int customerId)
        {
            try
            {
                customerRepository.Delete(customerId);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Unable to add customer");
            }
            return View();
        }

        public ActionResult Edit(int? customerId)
        {
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = customerRepository.Read(customerId);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            customerRepository.Update(customer);
            return RedirectToAction("index");
        }
    }
}