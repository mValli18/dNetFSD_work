using Shopping.Models.DTOs;

namespace Shopping.Interfaces
{
    public interface ICartService
    {
        bool AddToCart(CartDTO cartDTO);
        bool RemoveFromCart(CartDTO cartDTO);
    }
}
