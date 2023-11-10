using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ICustomerService
    {
        public Customer Register(Customer customer);
        public bool Login(string email, string password);
    }
}
