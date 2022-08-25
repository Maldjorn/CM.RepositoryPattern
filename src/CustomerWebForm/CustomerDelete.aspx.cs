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
    public partial class CustomerDelete : System.Web.UI.Page
    {
        public List<Customer> customers { get; set; } = new List<Customer>();
        public IRepository<Customer> _repository;
        public CustomerDelete()
        {
            _repository = new CustomerRepository();
        }
        public CustomerDelete(IRepository<Customer> customer)
        {
            _repository = customer;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customer_ID"]);
            _repository.Delete(customerIdReq);
            Response.Redirect("CustomerList.aspx");
        }
    }
}