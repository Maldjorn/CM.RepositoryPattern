﻿using CM.Addresss.Business;
using CM.Customers;
using CM.Customers.Entities;
using CM.Customers.Repositories;
using System.Web.Mvc;

namespace ASPMVC.Controllers
{

    public class AddressController : Controller
    {
        #region Fields
        private readonly IAddressService _addressService;
        readonly string connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        #endregion

        #region Constructors
        public AddressController()
        {
            _addressService = new AddressService();
        }

        public AddressController(IAddressService service)
        {
            _addressService = service;
        }
        #endregion

        #region Methods
        public ActionResult Index()
        {
            var addresses = _addressService.GetAll();
            return View(addresses);
        }

        public ActionResult Create(int? customerId)
        {
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var address = new Address()
            {
                CustomerID = customerId.Value
            };
            if (address.CustomerID == 0)
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
            _addressService.Create(address);
            return RedirectToAction("Details", "Customer", new { customerId = address.CustomerID });
        }

        public ActionResult Edit(int? addressId)
        {
            if (addressId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var address = _addressService.Read(addressId);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        public ActionResult Details(int? addressId)
        {
            if (addressId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var address = _addressService.Read(addressId);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }
        #endregion

        public ActionResult Delete(int? addressId)
        {
            if (addressId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var address = _addressService.Read(addressId);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Address address)
        {
            var addressObject = _addressService.Read(address.AddressID);
            _addressService.Delete(address.AddressID);
            return RedirectToAction("Details", "Customer", new { customerId = addressObject.CustomerID });

        }
    }
}