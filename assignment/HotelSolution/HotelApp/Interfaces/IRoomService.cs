using HotelApp.Models.DTOs;
using HotelApp.Models;

namespace HotelApp.Interfaces
{
    public interface IRoomService
    {
        public int GetRoomCount();
        Room Add(Room room);
        Room Book(int RoomId,string Guestname);

        Room Vacate(int RoomId, string Guestname);

        Room Delete(int RoomId);
        public List<Room> GetAllRooms();
        List<Room> RoomsByFare(float Fare);

    }
}
