using CM.Customers;
using CM.Customers.Entities;
using CM.Customers.Repositories;
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
            _addressRepository.Create(address);
            return RedirectToAction("Details", "Customer", new { customerId = address.CustomerID });
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
        #endregion

        public ActionResult Delete(int? addressId)
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
        public ActionResult Delete(Address address)
        {
            var addressObject = _addressRepository.Read(address.AddressID);
            _addressRepository.Delete(address.AddressID);
            return RedirectToAction("Details", "Customer", new { customerId = addressObject.CustomerID });

        }
    }
}