using CM.Customers;
using CM.Customers.Entities;
using CM.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerWebForm
{
    public partial class AddressesList : System.Web.UI.Page
    {
        public List<Address> addresses { get; set; } = new List<Address>();
        public IRepository<Address> _repository;
        public AddressesList()
        {
            _repository = new AddressRepository();
        }
        public AddressesList(IRepository<Address> customer)
        {
            _repository = customer;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadFromDatabase();
        }

        public void LoadFromDatabase()
        {
            addresses = _repository.GetAll();
        }
    }
}