using CM.Customers;
using CM.Customers.Entities;
using CM.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVC.Controllers
{
   
    public class AddressController : Controller
    {
        private readonly IRepository<Address> _addressRepository;
        public AddressController()
        {
            _addressRepository = new AddressRepository();
        }
        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            if (address == null)
            {
                return HttpNotFound();
            }
            _addressRepository.Create(address);
            return RedirectToAction("Index");
        }
    }
}