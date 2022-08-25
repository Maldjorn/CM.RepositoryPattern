using CM.Customers;
using CM.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerWebForm
{
    public partial class CustomerList : System.Web.UI.Page
    {
        public List<Customer> customers { get; set; } = new List<Customer>();
        IRepository<Customer> _repository;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCustomerFromDatabase();
        }
        public CustomerList()
        {
            _repository = new CustomerRepository();
        }
        public CustomerList(IRepository<Customer> customer)
        {
            _repository = customer;
        }
        public void LoadCustomerFromDatabase()
        {
            customers = _repository.GetAll();
        }
    }
}