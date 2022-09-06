using CM.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Addresss.Business
{
    public interface IAddressService
    {
        Address Create(Address address);
        Address Read(int? entityCode);
        void Update(Address entity);
        void Delete(int entityCode);
        List<Address> GetAll();
        List<Address> GetAll(int? entityCode);
    }
}
