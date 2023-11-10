using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class CustomerService : ICustomerService
    {
        IRepository<string, Customer> customerRepository;
        public CustomerService(IRepository<string, Customer> repo)
        {
            customerRepository = repo;
        }
        public bool Login(string email, string password)
        {
            var customer = customerRepository.Get(email);
            if (customer != null)
            {
                if (customer.ComparePassword(password))
                    return true;


            }
            else { Console.WriteLine("unsuccess"); }
            return false;
            throw new NotImplementedException();
        }

        public Customer Register(Customer customer)
        {
            var result = customerRepository.Add(customer);
            if (result != null)
            {
                return result;
            }
            
            throw new NotImplementedException();
        }
    }
}
