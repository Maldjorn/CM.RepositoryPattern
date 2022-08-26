using CM.Customers;
using CM.Customers.Entities;
using CM.Customers.Repositories;
using System;

namespace CustomerWebForm
{
    public partial class AddressDelete : System.Web.UI.Page
    {
        readonly string connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IRepository<Address> _repository;
        public AddressDelete()
        {
            _repository = new AddressRepository(connectionString);
        }
        public AddressDelete(IRepository<Address> address)
        {
            _repository = address;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var addressIdReq = Convert.ToInt32(Request.QueryString["address_ID"]);
            _repository.Delete(addressIdReq);
            Response.Redirect("CustomerList.aspx");
        }
    }
}