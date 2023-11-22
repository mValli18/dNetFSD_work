using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models.DTOs
{
    public class RoomDTO
    {
        [Required(ErrorMessage = "Username is empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "RoomId can to be empty")]
        public int RoomId { get; set; }
        public float Fare {  get; set; } 
       // public string Type { get; set; } 
    }
}
