using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;

namespace ShoppingDAMLibrary
{
    public interface ICustomerrepository
    {
        public Customer Add(Customer customer);
        public Customer Update(Customer customer);
        public Customer Delete(string email);
        public Customer GetByEmail(string email,string password);
        public List<Customer> GetAll();
    }
}
