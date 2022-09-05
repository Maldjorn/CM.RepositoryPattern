using CM.Customers;
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
        readonly IRepository<Customer> _customerRepository;
        readonly IRepository<Address> _addressRepository;
        readonly string connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        #endregion

        #region Constructors
        public CustomerController()
        {
            _customerRepository = new CustomerRepository(connectionString);
            _addressRepository = new AddressRepository(connectionString);
        }

        public CustomerController(IRepository<Customer> repository)
        {
            _customerRepository = repository;
        }
        #endregion

        #region Methods

        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            customers = _customerRepository.GetAll();
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
            _customerRepository.Create(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? customerId)
        {
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = _customerRepository.Read(customerId);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var addresses = _addressRepository.GetAll(customerId);
            ViewBag.CustomerAddresses = addresses;

            return View(customer);
        }

        public ActionResult Delete(int? customerId)
        {
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = _customerRepository.Read(customerId);
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
            _customerRepository.Delete(customerId);
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int? customerId)
        {
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = _customerRepository.Read(customerId);
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
            _customerRepository.Update(customer);
            return RedirectToAction("index");
        }
        #endregion
    }
}