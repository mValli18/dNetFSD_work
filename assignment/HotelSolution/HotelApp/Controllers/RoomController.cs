using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelApp.Interfaces;
using HotelApp.Services;
using HotelApp.Exceptions;
using HotelApp.Models;
using HotelApp.Models.DTOs;

namespace HotelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public ActionResult GetCountofAvailableRooms()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _roomService.GetRoomCount();
                return Ok($"Available Rooms in the Hotel are {result}");
            }
            catch (NoRoomsAvailableException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Create(Room room)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _roomService.Add(room);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
        [HttpPost]
        [Route("BookRoom")]
        public ActionResult BookRoom(int RoomId,string GuestName)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _roomService.Book(RoomId,GuestName);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
        [HttpPost]
        [Route("VacateRoom")]
        public ActionResult VacateRoom(int RoomId, string GuestName)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _roomService.Vacate(RoomId, GuestName);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
        [HttpGet("Fare/{fare}")]
        public ActionResult<IList<Room>> RoomsByFare(float fare)
        {
            try
            {
                var rooms = _roomService.RoomsByFare( fare);
                return Ok(rooms);
            }
            catch (Exception e)
            {
                return BadRequest($"Failed to retrieve rooms. {e.Message}");
            }
        }
    }
}
