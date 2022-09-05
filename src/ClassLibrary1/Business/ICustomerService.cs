using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Customers.Business
{
    public interface ICustomerService
    {
        Customer Create(Customer customer);

    }
}
