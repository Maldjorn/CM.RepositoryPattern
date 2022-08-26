using CM.Customers;
using CM.Customers.Repositories;
using System;

namespace CustomerWebForm
{
    public partial class CustomerDelete : System.Web.UI.Page
    {
        readonly string connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IRepository<Customer> _repository;
        public CustomerDelete()
        {
            _repository = new CustomerRepository(connectionString);
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