using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Interfaces;
using Shopping.Models.DTOs;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost]
        public IActionResult AddToCart(CartDTO cartDTO)
        {
            var result = _cartService.AddToCart(cartDTO);
            if (result)
                return Ok(cartDTO);
            return BadRequest("Could not add item to cart");
        }
        [HttpPost]
        [Route("RemoveFromCart")]
        public IActionResult RemoveFromCart(CartDTO cartDTO)
        {
            var result = _cartService.RemoveFromCart(cartDTO);
            if (result)
                return Ok(cartDTO);
            return BadRequest("Could not Remove item from cart");
        }
    }
}
