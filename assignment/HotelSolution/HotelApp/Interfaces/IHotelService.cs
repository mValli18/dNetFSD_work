using HotelApp.Models;
using Microsoft.EntityFrameworkCore;
using HotelApp.Models.DTOs;

namespace HotelApp.Interfaces

{
    public interface IHotelService
    {
        public HotelDTO Add(HotelDTO hotelDTO);
        public Hotel DeleteHotel(int  id);
        public Hotel GetHotel(int id);
        public List<Hotel> GetHotels();
        void UpdateHotel(Hotel updatedHotel);
        List<Hotel> GetHotelsByLocation(string location);
        

    }
}
