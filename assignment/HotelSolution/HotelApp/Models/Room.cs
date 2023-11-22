using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public string Type { get; set; }

        public float Fare {  get; set; }
        public string? Name { get; set; } = string.Empty;
        
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public string Status { get; set; } = "Avaliable";

        public Room() {

            int Id = 0;
           float Fare = 0.0f;
        }

      
    }
}
