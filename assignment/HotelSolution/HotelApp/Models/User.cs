using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class User
    {
        [Key]
        //public string Picture { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public byte[] Password { get; set; }
        public byte[] Key { get; set; }
        public string Role { get; set; }

    }
}
