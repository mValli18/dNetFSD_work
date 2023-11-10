using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CustomerRepository : IRepository<string, Customer>
    {
        Dictionary<string, Customer> customers = new Dictionary<string, Customer>();

        public Customer Add(Customer item)
        {
            customers.Add(item.Email, item);
            return item;
            throw new NotImplementedException();
        }
        public Customer Login(string id)
        {
            var customer = customers[id];
            return customer;
        }

        public Customer Delete(string key)
        {
            var customer = Get(key);
            if (customer != null)
            {
                customers.Remove(customer.Email);
                return customer;
            }
            return null;
            throw new NotImplementedException();
        }

        public Customer Get(string key)
        {
            if (customers.ContainsKey(key))
            {
                return customers[key];
            }
            return null;
            throw new NotImplementedException();
        }

        public IList<Customer> GetAll()
        {
            if (customers.Count == 0)
                return null;
            return customers.Values.ToList();
            throw new NotImplementedException();
        }

        public Customer Update(Customer item)
        {
            var customer = Get(item.Email);
            if (customer != null)
            {
                customers[item.Email] = item;
                return item;
            }
            return null;
            throw new NotImplementedException();
        }
    }
}


