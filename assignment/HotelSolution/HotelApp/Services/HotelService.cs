using HotelApp.Interfaces;
using HotelApp.Models;
using HotelApp.Exceptions;
using HotelApp.Repositories;
using HotelApp.Models.DTOs;

namespace HotelApp.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<int,Hotel> hotelRepository;
        public HotelService(IRepository<int,Hotel> _hotelRepository)
        {
            hotelRepository = _hotelRepository;
        }
        public HotelDTO Add(HotelDTO hotelDTO)
        {
            Hotel hotel = new Hotel()
            {
                Location= hotelDTO.Location,
                Phone = hotelDTO.Phone
            };
            var res= hotelRepository.Add(hotel);
            if (res != null)
            {
                return hotelDTO;
            }
            return null;
            throw new NotImplementedException();
        }
        public Hotel DeleteHotel(int id)
        {
            var result = hotelRepository.GetById(id);
            if (result != null)
            {
                hotelRepository.Delete(id);
                return result;
            }
            return null;
            throw new NotImplementedException();
        }
        public Hotel GetHotel(int id)
        {
            var result = hotelRepository.GetById(id);
            
            return result == null ? throw new NoRoomsAvailableException() : result;
        }

        public List<Hotel> GetHotels()
        {
            var hotels = hotelRepository.GetAll();
            if (hotels.Count != 0)
                return hotels.ToList();
            throw new Exception();
        }
        public void UpdateHotel(Hotel updatedHotel)
        {
            if (updatedHotel == null)
            {
                throw new ArgumentNullException(nameof(updatedHotel), "Updated Hotel data is null.");
            }


            

            
            var existingHotel = hotelRepository.GetById(updatedHotel.HotelId);

            if (existingHotel == null)
            {
                throw new InvalidOperationException($"Quiz with ID {updatedHotel.HotelId} not found.");
            }

            
            existingHotel.Phone = updatedHotel.Phone;
            existingHotel.Location = updatedHotel.Location;
            
            hotelRepository.Update(existingHotel);
        }

        /*public Hotel UpdateHotelPhone(int id, string phone)
        {
            var res = hotelRepository.GetById(id);
            if (res != null)
            {
                res.Phone = phone;
                var result = hotelRepository.Update(res);
                return result;
            }
            else
            {
                throw new InValidUpdateActionException();
            }
            throw new NoSuchRoomsException();
        }

        public Hotel UpdateHotelLocation(int id, string Location)
        {
            var res = hotelRepository.GetById(id);
            if (res != null)
            {
                res.Location = Location;
                var result = hotelRepository.Update(res);
                return result;
            }
            else
            {
                throw new InValidUpdateActionException();
            }
            throw new NoSuchRoomsException();
        }*/
        public List<Hotel> GetHotelsByLocation(string location)
        {
            var hotels = hotelRepository.GetAll().Where(c => c.Location.Contains(location, StringComparison.OrdinalIgnoreCase)).ToList();
            if (hotels != null)
            {
                return hotels;
                    
            }
            throw new NoHotelsAvailableException();
        }
    }
}
