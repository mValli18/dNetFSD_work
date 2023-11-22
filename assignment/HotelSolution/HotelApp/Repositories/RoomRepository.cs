using HotelApp.Context;
using HotelApp.Interfaces;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Repositories
{
    public class RoomRepository :IRepository<int,Room>
    {
        public HotelContext _hotelContext;
        public RoomRepository(HotelContext context) {

            _hotelContext = context;
        }

        public Room Add(Room item)
        {
            _hotelContext.Rooms.Add(item);
            _hotelContext.SaveChanges();
            return item;

        }

        public Room Delete(int key)
        {
            var result = GetById(key);
            if (result != null)
            {
                _hotelContext.Rooms.Remove(result);
                _hotelContext.SaveChanges();
                return result;
            }
            return null;
        }

        public IList<Room> GetAll()
        {
            if (_hotelContext.Rooms.Count()!=0)
            {
                return _hotelContext.Rooms.ToList();
            }
            return null;
        }
        
        public Room GetById(int key)
        {
            var res=_hotelContext.Rooms.SingleOrDefault(r => r.Id == key);
            return res;
        }

        public Room Update(Room entity)
        {
            var room = GetById(entity.Id);
            if (room != null)
            {
                _hotelContext.Entry<Room>(room).State = EntityState.Modified;
                _hotelContext.SaveChanges();
                return room;
            }
            return null;
        }
    }

    
}
