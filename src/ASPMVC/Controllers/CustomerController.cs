using CM.Addresss.Business;
using CM.Customers;
using CM.Customers.Business;
using CM.Customers.Business.CustomersService;
using CM.Customers.Entities;
using CM.Customers.Repositories;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ASPMVC.Controllers
{
    public class CustomerController : Controller
    {
        #region Fields
        List<Customer> customers = new List<Customer>();
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addresssService;
        #endregion

        #region Constructors
        public CustomerController()
        {
            _customerService = new CustomerService();
            _addresssService = new AddressService();
        }

        public CustomerController(ICustomerService repository)
        {
            _customerService = repository;
        }
        #endregion

        #region Methods

        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            customers = _customerService.GetAll();
            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            _customerService.Create(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? customerId)
        {
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = _customerService.Read(customerId);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var addresses = _addresssService.GetAll(customerId);
            ViewBag.CustomerAddresses = addresses;

            return View(customer);
        }

        public ActionResult Delete(int? customerId)
        {
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = _customerService.Read(customerId);
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
            _customerService.Delete(customerId);
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int? customerId)
        {
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = _customerService.Read(customerId);
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
            _customerService.Update(customer);
            return RedirectToAction("index");
        }
        #endregion
    }
}