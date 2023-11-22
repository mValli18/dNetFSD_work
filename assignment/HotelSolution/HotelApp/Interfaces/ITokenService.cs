using HotelApp.Models.DTOs;

namespace HotelApp.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
