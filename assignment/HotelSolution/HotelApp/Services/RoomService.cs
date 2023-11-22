using HotelApp.Context;
using HotelApp.Interfaces;
using HotelApp.Models;
using HotelApp.Models.DTOs;
using HotelApp.Exceptions;

using HotelApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Services

{
    public class RoomService : IRoomService
    {
        private readonly IRepository<int, Room> roomRepository;
        public HotelContext _hotelContext;

        public RoomService(IRepository<int, Room> _roomRepository,HotelContext hotelContext)
        {
            roomRepository = _roomRepository;
            _hotelContext = hotelContext;
        }
        
        
        public Room Add(Room room)
        {
            var res = roomRepository.Add(room);
            if (res != null)
            {
                return res;
            }
            return null;
            throw new NotImplementedException();
        }

        public Room Book(int RoomId, string Guestname)
        {
            var res = roomRepository.GetById(RoomId);
            if (res != null)
            {
                if (res.Status.Equals("Available", StringComparison.OrdinalIgnoreCase))
                {
                    // Update room properties
                    res.Status = "Booked";
                    res.Name = Guestname;

                    // You can perform additional actions or validations if needed

                    // Return true indicating successful booking
                    return res;
                }
                else
                    throw new NoRoomsAvailableException();

            }
            throw new NotImplementedException();
        }

        public Room Delete(int RoomId)
        {
            var res = roomRepository.GetById(RoomId);
            if (res != null)
            {
                roomRepository.Delete(RoomId);
                return res;
            }
            throw new NotImplementedException();
        }

        public int GetRoomCount()
        {
            if (_hotelContext.Rooms.Count() != 0)
            {

                return _hotelContext.Rooms.AsEnumerable().Count(room => room.Status.Equals("Available", StringComparison.OrdinalIgnoreCase));

            }
            return 0;
        }

        public Room Vacate(int RoomId, string Guestname)
        {
            var res = roomRepository.GetById(RoomId);
            try
            {
                if (res != null)
                {
                    if (res.Status.Equals("Booked", StringComparison.OrdinalIgnoreCase))
                    {
                        // Update room properties
                        res.Status = "Available";
                        res.Name =null;


                        

                        // Return true indicating successful booking
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NoRoomsAvailableException();
            }
            throw new NotImplementedException();
        }
        public List<Room> GetAllRooms()
        {
            var res = roomRepository.GetAll();
            if (res != null)
            {
                return res.ToList();
            }
            return null;
        }
        public List<Room> RoomsByFare(float fare)
        {
            var rooms = roomRepository.GetAll();
            if (rooms != null)
            {
                return rooms
            .Where(room => room.Status == "Available" && room.Fare <= fare)
            .ToList();
            }
            throw new NoRoomsAvailableException();
        }
    }
}
