using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }
        public string Name { get; set; } = "XYZ";
        public string Location { get; set; }
        //public int RoomCount {  get; set; }
        public string Phone {  get; set; }


        public ICollection<Room>Rooms { get; set; }
        
    }
}
