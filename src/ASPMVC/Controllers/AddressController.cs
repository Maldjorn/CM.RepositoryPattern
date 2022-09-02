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
        #region Fields
        private readonly IRepository<Address> _addressRepository;
        readonly string connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        #endregion

        #region Constructors
        public AddressController()
        {
            _addressRepository = new AddressRepository(connectionString);
        }

        public AddressController(IRepository<Address> repository)
        {
            _addressRepository = repository;
        }
        #endregion

        #region Methods
        public ActionResult Index()
        {
            var addresses = _addressRepository.GetAll();
            return View(addresses);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int? addressId)
        {
            if (addressId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var address = _addressRepository.Read(addressId);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
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
        #endregion

        public ActionResult Details(int? addressId)
        {
            if (addressId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var address = _addressRepository.Read(addressId);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }
    }
}