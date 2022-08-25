using CM.Customers;
using CM.Customers.Repositories;
using System;

namespace CustomerWebForm
{
    public partial class CustomerDelete : System.Web.UI.Page
    {
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