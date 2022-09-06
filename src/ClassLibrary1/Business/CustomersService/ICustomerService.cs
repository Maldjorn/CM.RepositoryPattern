using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Customers.Business.CustomersService
{
    public interface ICustomerService
    {
        Customer Create(Customer customer);
        Customer Read(int? entityCode);
        void Update(Customer entity);
        void Delete(int entityCode);
        List<Customer> GetAll();
        List<Customer> GetAll(int? entityCode);
    }
}
