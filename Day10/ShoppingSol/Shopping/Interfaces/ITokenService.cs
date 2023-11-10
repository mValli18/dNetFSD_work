using Shopping.Models.DTOs;

namespace Shopping.Interfaces
{
    public interface ITokenService
    {
        string? GetToken(UserDTO userDTO);

        public interface ITokenService
        {
            string  GetToken(UserDTO user);
        }
    }
}
