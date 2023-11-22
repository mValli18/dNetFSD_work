using HotelApp.Exceptions;
using HotelApp.Interfaces;
using HotelApp.Models.DTOs;
using HotelApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
            private readonly IHotelService _hotelService;


            public HotelController(IHotelService hotelService)
            {
                _hotelService = hotelService;

            }
            [HttpGet]
            public ActionResult Get()
            {
                string errorMessage = string.Empty;
                try
                {
                    var result = _hotelService.GetHotels();
                    return Ok(result);
                }
                catch (NoRoomsAvailableException e)
                {
                    errorMessage = e.Message;
                }
                return BadRequest(errorMessage);
            }



            [Authorize(Roles = "Admin")]
            [HttpPost]
            public ActionResult Create(HotelDTO hotelDTO)
            {
                string errorMessage = string.Empty;
                try
                {
                    var result = _hotelService.Add(hotelDTO);
                    return Ok(result);
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }
                return BadRequest(errorMessage);
            }
        [Authorize(Roles = "Admin")]
        [HttpPost("Remove/{remove}")]
        public ActionResult Remove( int id)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _hotelService.DeleteHotel(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
        [HttpGet("Location/{location}")]
        public ActionResult GetHotelByLocation(string location)
        {
            string message = string.Empty;
            try
            {
                var result = _hotelService.GetHotelsByLocation(location);
                
                return Ok(result);

            }
            catch (NoHotelsAvailableException ex)
            {
                message = ex.Message;
            }
            
            return BadRequest(message);
        }

        [Authorize]
            [HttpPut("{HotelId}")]
            public IActionResult UpdateHotel(int HotelId, [FromBody] Hotel updatedHotel)
            {
                try
                {
                    
                    if (HotelId != updatedHotel.HotelId)
                    {
                        return BadRequest("Mismatched quizId in the request.");
                    }

                    // Get the existing hotel from the service
                    var existingHotel = _hotelService.GetHotel(HotelId);

                    // Check if the hotel exists
                    if (existingHotel == null)
                    {
                        return NotFound($"Hotel with ID {HotelId} not found.");
                    }

                    // Update the properties of the existing hotel with the values from the updatedHotel
                    existingHotel.Location = updatedHotel.Location;
                    existingHotel.Phone = updatedHotel.Phone;
                    

                    // Update the hotel in the service
                    _hotelService.UpdateHotel(existingHotel);

                    return Ok("Hotel updated successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
    }
