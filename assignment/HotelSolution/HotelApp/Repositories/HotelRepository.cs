using HotelApp.Context;
using HotelApp.Interfaces;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Repositories
    {
        public class HotelRepository : IRepository<int, Hotel>
        {
            public HotelContext _hotelContext;
            public HotelRepository(HotelContext context)
            {

                _hotelContext = context;
            }

            public Hotel Add(Hotel item)
            {
                _hotelContext.Hotels.Add(item);
                _hotelContext.SaveChanges();
                return item;

            }

            public Hotel Delete(int key)
            {
                var result = GetById(key);
                if (result != null)
                {
                    _hotelContext.Hotels.Remove(result);
                    _hotelContext.SaveChanges();
                    return result;
                }
                return null;
            }

            public IList<Hotel> GetAll()
            {
                if (_hotelContext.Rooms.Count() != 0)
                {
                    return _hotelContext.Hotels.ToList();
                }
                return null;
            }

            public Hotel GetById(int key)
            {
                var res = _hotelContext.Hotels.SingleOrDefault(r => r.HotelId == key);
                return res;
            }

            public Hotel Update(Hotel entity)
            {
                var hotel = GetById(entity.HotelId);
                if (hotel != null)
                {
                    _hotelContext.Entry<Hotel>(hotel).State = EntityState.Modified;
                    _hotelContext.SaveChanges();
                    return hotel;
                }
                return null;
            }
        }


    }

